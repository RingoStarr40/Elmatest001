using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using Calcspace;

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
            var calc = new Calc(new Calcspace.IOperation[]
                {new Calcspace.SumOperation() });
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3); 
        }
    }
}
