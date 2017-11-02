using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HW.AppStore.Common
{
    public sealed class EncodingHelper
    {
        private const string DEFAULT_ENCRYPT_KEY = "ngqL1JTI";

        public static string DesDecrypt(string strText)
        {
            try
            {
                return DesDecrypt(strText, DEFAULT_ENCRYPT_KEY);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="saltKey">密钥</param>
        /// <returns></returns>
        public static string DesDecrypt(string strText, string saltKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            byte[] buffer = new byte[strText.Length];
            rgbKey = Encoding.UTF8.GetBytes(saltKey.Substring(0, 8));
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            buffer = Convert.FromBase64String(strText);
            MemoryStream stream = new MemoryStream();
            CryptoStream cs = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cs.Write(buffer, 0, buffer.Length);
            cs.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(stream.ToArray());
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="saltKey">密钥</param>
        /// <returns></returns>
        public static string DesEncrypt(string strText, string saltKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            rgbKey = Encoding.UTF8.GetBytes(saltKey.Substring(0, 8));
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(strText);
            MemoryStream stream = new MemoryStream();
            CryptoStream cs = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }

        public static string DesEncrypt(string strText)
        {
            try
            {
                return DesEncrypt(strText, DEFAULT_ENCRYPT_KEY);
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
