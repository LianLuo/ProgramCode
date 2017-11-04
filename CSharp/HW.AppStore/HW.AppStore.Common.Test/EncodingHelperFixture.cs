using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HW.AppStore.Common.Test
{
    [TestFixture]
    public class EncodingHelperFixture
    {
        [Test]
        public void When_Input_Hello_DesEncrypt()
        {
            string result = EncodingHelper.DesEncrypt("Hello");
            Assert.AreEqual(result, "JdXwfK8OolI=");
        }

        [Test]
        public void When_Input_Key_DesDecrypt()
        {
            string result = EncodingHelper.DesDecrypt("JdXwfK8OolI=");
            Assert.AreEqual("Hello",result);
        }

        [Test]
        public void When_LengthNotEnough_DescDecrypt()
        {
            // 长度不够会抛异常，返回值为string.Empty;
            string result = EncodingHelper.DesDecrypt("Hello");
            Assert.AreEqual("", result);
        }

        [TestCase("Hello", "12345678", Result = "Nd77QnD0jT0=")]
        [TestCase("Hello World", "12345678", Result = "nxtE7ZlF1fu2KvziGJKPpA==")]
        public string When_HasSalt_DesEncrypt(string input,string salt)
        {
            string result = EncodingHelper.DesEncrypt(input,salt);
            return result;
        }

        [TestCase("Nd77QnD0jT0=", "12345678", Result = "Hello")]
        [TestCase("nxtE7ZlF1fu2KvziGJKPpA==", "12345678", Result = "Hello World")]
        public string When_HasSalt_DesDecrypt(string input, string salt)
        {
            string result = EncodingHelper.DesDecrypt(input, salt);
            return result;
        }
    }
}
