using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.AppStore.Common
{
    public class SetUIConst
    {
        /// <summary>
        /// 软件过期时间
        /// </summary>
        public static string ApplicationExpiredDate = "12/29/2017";
        /// <summary>
        /// 隔离存储的地址
        /// </summary>
        public static string IsolatedStorageDirectoryName = Environment.UserName;
        /// <summary>
        /// 隔离存储的加盐
        /// </summary>
        public static string IsolatedStorageEncryptKey = "ngqL1JTIW6OLkIipwMdrtG0";
        /// <summary>
        /// 公钥
        /// </summary>
        public static string PublicKey = "";
        /// <summary>
        /// 过期时间
        /// </summary>
        public static int SoftwarePorbationDay = 30;
        /// <summary>
        /// 软件名称
        /// </summary>
        public static string SoftwareProductName = "HW.AppStore";
        /// <summary>
        /// 版本号
        /// </summary>
        public static string SoftwareVersion = "1.0";
        /// <summary>
        /// 注册表地址
        /// </summary>
        public static string SoftwareRegistryKey = string.Format("SOFTWARE\\Microsoft\\{0}\\{1}",SoftwareProductName,SoftwareVersion);
        /// <summary>
        /// web注册地址
        /// </summary>
        public static string WebRegisterUri = "http://github.com/LianLuo";
        /// <summary>
        /// 隔离存储
        /// </summary>
        public static string IsolatedStorage = System.IO.Path.Combine(Environment.UserName, string.Format("{0}.cfg",SoftwareProductName));
        /// <summary>
        /// 设置全局系统值
        /// </summary>
        /// <param name="expiredDate">过期时间</param>
        /// <param name="version">版本编号</param>
        /// <param name="name">产品名称</param>
        /// <param name="publicKey">公钥</param>
        public static void SetValue(string expiredDate, string version, string name, string publicKey)
        {
            ApplicationExpiredDate = expiredDate;
            SoftwareVersion = version;
            SoftwareRegistryKey = string.Format("SOFTWARE\\Microsoft\\{0}\\{1}", name, version);
            IsolatedStorage = string.Format("{0}\\{1}", Environment.UserName, name);
            PublicKey = publicKey;
        }
    }
}
