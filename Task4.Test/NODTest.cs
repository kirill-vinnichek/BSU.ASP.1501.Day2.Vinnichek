using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;
using System.Diagnostics;
namespace Task4.Test
{
    [TestClass]
    public class NODTest
    {
        [TestMethod]
        public void EuclideanTest()
        {
            long ticks=0;
            Assert.AreEqual(NOD.Euclidean(125, 100), 25);
            Assert.AreEqual(NOD.Euclidean(out ticks,1256,648,1232, 12312), 8);
            Debug.WriteLine("Euclidean - {0}", ticks);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanArgumentTest()    
        {
            Assert.AreEqual(NOD.Euclidean(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EuclideanNullArgumentTest()
        {
            Assert.AreEqual(NOD.Euclidean(null), 0);
        }

        [TestMethod]
        public void SteinTest()
        {
            long ticks = 0;
            Assert.AreEqual(NOD.Stein(125, 100), 25);
            Assert.AreEqual(NOD.Stein(125, 1), 1);
            Assert.AreEqual(NOD.Stein(out ticks, 1256, 648, 1232, 12312), 8);
            Debug.WriteLine("Stein - {0}", ticks);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinArgumentTest()
        {
            Assert.AreEqual(NOD.Stein(), 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SteinNullArgumentTest()
        {
            Assert.AreEqual(NOD.Stein(null), 0);
        }
    }
}
