using DllCulculationDiscount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTestCalculationDiscount
{
    /// <summary>
    /// Summary description for TestDiscount
    /// </summary>
    [TestClass]
    public class TestDiscount
    {
        CalculationDiscount calculationDiscount = new CalculationDiscount();
        [TestMethod]
        public void TestCalculationNull()
        {
            Assert.AreEqual(calculationDiscount.CalculationsDiscount(0,0),0);
        }
        public void TestCalculationNullPrice()
        {
            Assert.AreEqual(calculationDiscount.CalculationsDiscount(10, 0),0);
        }
        public void TestCalculationNullCountBook()
        {
            Assert.AreEqual(calculationDiscount.CalculationsDiscount(0, 1200), 0);

        }
        public void TestCalculation()
        {
            Assert.AreEqual(calculationDiscount.CalculationsDiscount(5, 500), 6);
        }
      
    }
}