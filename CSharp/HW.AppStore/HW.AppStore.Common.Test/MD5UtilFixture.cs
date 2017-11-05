using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HW.AppStore.Common.Test
{
    [TestFixture]
    public class MD5UtilFixture
    {
        [Test]
        public void GetMD5Test()
        {
            string val4 = MD5Util.GetMD5("Hello", 4);
            string val8 = MD5Util.GetMD5("Hello", 8);
            string val16 = MD5Util.GetMD5("Hello", 16);

            Assert.AreEqual(val4, "c461");
            Assert.AreEqual(val8, "c4611296");
            Assert.AreEqual(val16, "c4611296a827abf8");
        }

        [Test]
        public void ValidateValueTest()
        {
            bool result = MD5Util.ValidateValue("c461Hello");
            Assert.IsTrue(result);
        }

        [Test]
        public void AddMDProfixTest()
        {
            string result = MD5Util.AddMDProfix("Hello");

            Assert.AreEqual(result, "c461Hello");
        }

        [Test]
        public void RemoveMD5ProfixTest()
        {
            string result = MD5Util.RemoveMD5Profix("c461Hello");

            Assert.AreEqual("Hello",result);
        }
    }
}
