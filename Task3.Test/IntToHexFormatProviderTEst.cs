using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;
namespace Task3.Test
{
    [TestClass]
    public class IntToHexFormatProviderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var intToHexProvider = new IntToHexFormatProvider();
            Assert.AreEqual(String.Format(intToHexProvider, "{0:H}", 88), "0x58");
            Assert.AreEqual(String.Format(intToHexProvider, "{0:H}", 172), "0xAC");
            Assert.AreEqual(String.Format(intToHexProvider, "{0:H}", 489), "0x1E9");
        }
    }
}
