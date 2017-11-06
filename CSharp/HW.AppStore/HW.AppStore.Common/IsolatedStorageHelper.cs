using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HW.AppStore.Common
{
    public sealed class IsolatedStorageHelper
    {
        private const IsolatedStorageScope SCEOP = IsolatedStorageScope.User | IsolatedStorageScope.Domain |
                                                           IsolatedStorageScope.Assembly;
        /// <summary>
        /// 加密保存到指定的路径下面，用";"分割
        /// </summary>
        public static void SaveDateTime()
        {
            SaveDateTime(DateTime.Now);
        }

        public static void SaveDateTime(DateTime fromDate)
        {
            string fromDateTime = fromDate.ToString("MM-dd-yyyy HH:mm:ss");
            string oldTime = GetDateTime().Trim();
            if (!string.IsNullOrEmpty(oldTime))
            {
                fromDateTime = string.Format("{0};{1}", oldTime, fromDateTime);
            }

            fromDateTime = EncodingHelper.DesEncrypt(fromDateTime,SetUIConst.IsolatedStorageEncryptKey);//加密后
            // 按照用户，域，命名空间划分独立的存储空间
            IsolatedStorageFile isolatedStorage =
                IsolatedStorageFile.GetStore(SCEOP, null, null);
            // 查看是否有文件夹
            string[] myUserName = isolatedStorage.GetDirectoryNames(SetUIConst.IsolatedStorageDirectoryName);
            if (myUserName.Length == 0)
            {
                isolatedStorage.CreateDirectory(SetUIConst.IsolatedStorageDirectoryName);
                IsolatedStorageSave(fromDateTime,isolatedStorage,FileMode.Create);
            }
            else
            {
                // 查看是否有文件
                myUserName = isolatedStorage.GetFileNames(SetUIConst.IsolatedStorage);
                IsolatedStorageSave(fromDateTime, isolatedStorage,myUserName.Length == 0 ? FileMode.Create : FileMode.Open);
            }
        }

        private static void IsolatedStorageSave(string info,IsolatedStorageFile isolatedStorage,FileMode fileMode)
        {
            using (var fs = new IsolatedStorageFileStream(SetUIConst.IsolatedStorage, fileMode, isolatedStorage))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(info);
                }
            }
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime()
        {
            string fromDateTime;
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(SCEOP, null,null);
            string[] myusername = isoStore.GetDirectoryNames(SetUIConst.IsolatedStorageDirectoryName);
            if (myusername.Length == 0)
            {
                return string.Empty;
            }
            myusername = isoStore.GetFileNames(SetUIConst.IsolatedStorage);
            if (myusername.Length == 0)
            {
                return string.Empty;
            }
            using (IsolatedStorageFileStream fs =
                new IsolatedStorageFileStream(SetUIConst.IsolatedStorage, FileMode.Open, isoStore))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    fromDateTime = reader.ReadLine();
                }
            }
            if (!string.IsNullOrEmpty(fromDateTime))
            {
                //对fromDateTime进行解密
                fromDateTime = EncodingHelper.DesDecrypt(fromDateTime, SetUIConst.IsolatedStorageEncryptKey);
            }
            return fromDateTime;
        }

        /// <summary>
        /// 保存对象到独立的储存区
        /// </summary>
        /// <param name="objToSave"></param>
        /// <param name="key"></param>
        public static void Save(object objToSave, string key)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(SCEOP, null, null))
            {
                using (IsolatedStorageFileStream stream =
                    new IsolatedStorageFileStream(key, FileMode.Create, FileAccess.Write, store))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream,objToSave);
                }
            }
        }

        /// <summary>
        /// 根据键值加载独立储存区的内容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue(string key)
        {
            try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(SCEOP, null, null))
                {
                    using (IsolatedStorageFileStream stream =
                        new IsolatedStorageFileStream(key, FileMode.Open, FileAccess.Read, store))
                    {
                        stream.Position = 0;
                        BinaryFormatter deserializer = new BinaryFormatter();
                        return deserializer.Deserialize(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 从指定文件中读取数据
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="fileName"></param>
        public static void LoadFromUserStoreForDomain(IDictionary dictionary, string fileName)
        {
            Load(dictionary,SCEOP,fileName);
        }

        private static void Load(IDictionary dictionary, IsolatedStorageScope scope, string fileName)
        {
            dictionary.Clear();
            using (IsolatedStorageFile storeage = IsolatedStorageFile.GetStore(scope,null,null))
            {
                string[] files = storeage.GetFileNames(fileName);
                if (files.Length > 0 && files[0] == fileName)
                {
                    using (Stream stream = new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, storeage))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        IDictionary data = (IDictionary) formatter.Deserialize(stream);
                        IDictionaryEnumerator enumerator = data.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            dictionary.Add(enumerator.Key,enumerator.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将对象集合保存在指定文件中
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="fileName"></param>
        public static void SaveToUserStoreForDomain(IDictionary dictionary, string fileName)
        {
            Save(dictionary,SCEOP,fileName);
        }

        private static void Save(IDictionary dictionary, IsolatedStorageScope scope, string fileName)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetStore(scope,null,null);
            using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(fileName, FileMode.Create, storage))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fs,dictionary);
            }
        }

        /// <summary>
        /// 删除指定区域中的储存内容
        /// </summary>
        /// <param name="fileName"></param>
        public static void Delete(string fileName)
        {
            try
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetStore(SCEOP, null, null))
                {
                    if (!string.IsNullOrEmpty(fileName) && storage.GetFileNames(fileName).Length > 0)
                    {
                        storage.DeleteFile(fileName);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("无法删除存储区域中的文件.",e);
            }
        }
        /// <summary>
        /// 在储存区域中创建一个文件夹
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="dirName"></param>
        public static void CreateDirectory(IsolatedStorageFile storage, string dirName)
        {
            try
            {
                if (!string.IsNullOrEmpty(dirName) && storage.GetDirectoryNames(dirName).Length <= 0)
                {
                    storage.CreateDirectory(dirName);
                }
            }
            catch (Exception e)
            {
                throw new Exception("无法在储存区内创建目录",e);
            }
        }

        /// <summary>
        /// 删除储存区域中的文件夹
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="dirName"></param>
        public static void DeleteDirectory(IsolatedStorageFile storage, string dirName)
        {
            try
            {
                if (!string.IsNullOrEmpty(dirName) && storage.GetDirectoryNames(dirName).Length > 0)
                {
                    storage.DeleteDirectory(dirName);
                }
            }
            catch (Exception e)
            {
                throw new Exception("无法在储存区内删除目录", e);
            }
        }
    }
}
