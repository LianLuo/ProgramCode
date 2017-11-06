using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace HW.AppStore.Common
{
    public sealed class ValidateLicense
    {
        public static bool ValidateCode(string mac, string license)
        {
            bool result = false;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                string publicKey = GetPublicKey();
                rsa.FromXmlString(publicKey);
                byte[] signedData = Convert.FromBase64String(license);
                result = rsa.VerifyData(Encoding.UTF8.GetBytes(mac), "SHA1", signedData);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return result;
        }

        public static bool ValidateCodeByDate(string mac, string license)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                string publicKey = GetPublicKey();
                rsa.FromXmlString(publicKey);
                byte[] signedData = Convert.FromBase64String(license);
                bool isToday = rsa.VerifyData(
                    Encoding.UTF8.GetBytes(string.Format("[{0}][{1:yyyy-MM-dd}]", mac, DateTime.Now)),
                    "SHA1", signedData);
                bool matchineToday = rsa.VerifyData(
                    Encoding.UTF8.GetBytes(string.Format("[{0}][{1:yyyy-MM-dd}]", mac, DateTime.Now)),
                    "SHA1", signedData);
                bool isForever = rsa.VerifyData(
                    Encoding.UTF8.GetBytes(string.Format("[{0}][{1}]", mac, Environment.MachineName)), "SHA1",
                    signedData);
                return isToday || matchineToday || isForever;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        private static string GetPublicKey()
        {
            string result = SetUIConst.PublicKey;
            return result;
        }
    }

    public sealed class CreateLicense
    {
        /// <summary>
        /// 功能描述:创建注册码
        /// 创建日期:2017-11-03 
        /// 创建作者:luolian
        /// </summary>
        /// <param name="mac">mac地址</param>
        /// <returns></returns>
        public static string GetLicense(string mac)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey = GetPrivateKey();
            rsa.FromXmlString(privateKey);
            byte[] regCodeBytes = rsa.SignData(Encoding.UTF8.GetBytes(mac), "SHA1");
            string licese = Convert.ToBase64String(regCodeBytes);
            return licese;
        }

        public static string GetLicense(string mac, DateTime date)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey = GetPrivateKey();
            rsa.FromXmlString(privateKey);
            byte[] regCodeBytes = rsa.SignData(
                Encoding.UTF8.GetBytes(string.Format("[{0}][{1:yyyy-MM-dd}]", mac, date)), "SHA1");
            string license = Convert.ToBase64String(regCodeBytes);
            return license;
        }

        private static string GetPrivateKey()
        {
            string result = SetUIConst.SoftwarePrivateKey;
            return result;
        }
    }
}
