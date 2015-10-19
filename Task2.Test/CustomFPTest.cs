using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace Task2.Test
{
    [TestClass]
    public class CustomerTest
    {
        Customer c = new Customer("Sai", "+375505", 50);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestWrongFormat()
        {
            var pr = new CustomerFormatProvider();
            Assert.AreEqual(String.Format("{0:Q}", c), "Sai");
            Assert.AreEqual(String.Format(pr,"{0:Q}", c), "Sai");
        }
        [TestMethod]
        public void TestFormats()
        {
            Assert.AreEqual(String.Format("{0:N}", c), c.Name.ToString());
            Assert.AreEqual(String.Format("{0:N,R}", c), String.Format("{0} {1}",c.Name,c.Revenue));
            Assert.AreEqual(String.Format("{0:N} {0:R}", c), String.Format("{0} {1}", c.Name, c.Revenue));
            Assert.AreEqual(String.Format("{0:N,P}", c), String.Format("{0} {1}", c.Name, c.ContactPhone));
            Assert.AreEqual(String.Format("{0:N,p,R}", c), String.Format("{0} {1} {2}", c.Name, c.ContactPhone,c.Revenue));
            var pr = new CustomerFormatProvider();
            Assert.AreEqual(String.Format(pr, "{0:UN}", c), c.Name.ToUpperInvariant());







        }
    }
}
