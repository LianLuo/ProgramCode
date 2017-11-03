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
        public static string PublicKey = "<RSAKeyValue><Modulus>3S3VOvI0cHUK464JJRueus0dkdXNq6R1bU4uRuiBInF/kExcuidYbVvWJlEZ5po+AaJDO8qyb15vHZ/z7Vht1kKy3ttJOU7f4mcgqKPzTUda7Z/1yekq9Hh/k/EwPRQFnukzmDzOLkAITI+fCr6gZAMcg/xvXoWG3bvOajpb7Vk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
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

        public static string SoftwarePrivateKey = "<RSAKeyValue><Modulus>3S3VOvI0cHUK464JJRueus0dkdXNq6R1bU4uRuiBInF/kExcuidYbVvWJlEZ5po+AaJDO8qyb15vHZ/z7Vht1kKy3ttJOU7f4mcgqKPzTUda7Z/1yekq9Hh/k/EwPRQFnukzmDzOLkAITI+fCr6gZAMcg/xvXoWG3bvOajpb7Vk=</Modulus><Exponent>AQAB</Exponent><P>78xYIo06YB5AV0bwk3GjeKQZ6OPul5yOtKMcbUjeifOfaDAhDmNWccu5tQf+5LktdnWjoykH2hpqS9SexhPXKw==</P><Q>7B9xae0d1QH0NR2WAmvhiFrYEaRoi8TpXAZeutPCqrHx5ujNDAU6e4mDmRqiVdxU1GAQnGMRIvTPH4kGKmXLiw==</Q><DP>KYh0D2/0l2dF75fq3S7GiIOrtSmdTocgNGs35jnDyZL3nh0P7KUJ+OW3QYKkBEuKc0UG1aCqqnz+wimOYnJXRw==</DP><DQ>toXHwb4NZW7RO43XO5/xAtpWU6znM8PPL9esunae8BwFhh1HA5e3EW/HTj6MZhqfaFup+3mI8aCTyyi8n2F46Q==</DQ><InverseQ>UVG4f/yMdadnLODLOedh095J7vKWpq/MkopA1byn2IeEi6/n1LFWwrVJYblgz7lVYo/RDjXyV8Bib3mwa40xYQ==</InverseQ><D>mZt6Kl0J9EwlCujUaxQaketgLOdK1nj6ILaaRx60iIJAsKuH/rTSoeiU+rl6foACrknN3dmxQM1Z6D4tP1oZtNjITNEVtpmWWJy/6frUP+o1ebhzIbGhdCf9Net4Fdn1sJylBiGrZq6HswGs8O8GS6saaq3pPWJAjTpch3f/lA0=</D></RSAKeyValue>";
    }
}
