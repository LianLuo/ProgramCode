using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HW.AppStore.Common
{
    public sealed class MD5Util
    {
        /// <summary>
        /// 获取字符串的MD5值
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="length">需要几位</param>
        /// <returns></returns>
        public static string GetMD5(string input,int length)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            switch (length)
            {
                case 16:
                    return sb.ToString().Substring(8, 16);
                case 8:
                    return sb.ToString().Substring(8, 8);
                case 4:
                    return sb.ToString().Substring(8, 4);
            }
            return sb.ToString();
        }

        public static bool CheckMD5(string path)
        {
            try
            {
                FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.Read);
                byte[] hash = new byte[fs.Length];
                fs.Read(hash, 0, hash.Length);
                fs.Close();
                string result = MD5Buffer(hash, 0, hash.Length - 32);
                string md5 = Encoding.ASCII.GetString(hash, hash.Length - 32, 32);
                return result == md5;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public static bool ValidateValue(string input)
        {
            bool res = false;
            if (input.Length >= 4)
            {
                string temp = input.Substring(4);
                if (input.Substring(0, 4) == GetMD5(temp, 4))
                {
                    res = true;
                }
            }
            return res;
        }

        public static string AddMDProfix(string input)
        {
            return GetMD5(input, 4) + input;
        }

        public static string RemoveMD5Profix(string input)
        {
            return input.Substring(4);
        }

        private static string MD5Buffer(byte[] streamBytes, int index, int count)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(streamBytes, index, count);
            string result = BitConverter.ToString(hash);
            result = result.Replace("-", "");
            return result;
        }
    }
}
