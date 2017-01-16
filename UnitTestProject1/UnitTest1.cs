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
            var result = calc.Execute("Sum", new object[] { 5, 4 });
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void SubTest()
        {
            var calc = new Calc(new Calcspace.IOperation[]
                {new Calcspace.SubOperation() });
            var result = calc.Execute("Sub", new object[] { 5, 4 });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void MultTest()
        {
            var calc = new Calc(new Calcspace.IOperation[]
                {new Calcspace.MultOperation() });
            var result = calc.Execute("Mult", new object[] { 5, 4 });
            Assert.AreEqual(result, 20);

        }

        [TestMethod]
        public void FactTest()
        {
            var calc = new Calc(new Calcspace.IOperation[]
                {new Calcspace.FactOperation() });
            var result = calc.Execute("Fact", new object[] { 5 });
            Assert.AreEqual(result, 120);

        }

        [TestMethod]
        public void PiTest()
        {
            var calc = new Calc(new Calcspace.IOperation[]
                {new Calcspace.PiOperation() });
            var result = calc.Execute("Pi", null);
            Assert.AreEqual(result, (float)Math.PI);

        }
    }


}
