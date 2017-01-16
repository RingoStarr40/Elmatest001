using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestProject1
{
    /// <summary>
    /// test Calc
    /// </summary>
    [TestClass] //атрибут тестового класса
    public class CalcUnitTest 
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new Calc();
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3); 
        }
    }
}
