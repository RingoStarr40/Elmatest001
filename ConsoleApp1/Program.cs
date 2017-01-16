using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Calcspace; //алиас для Calc

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new C.Calc(new Calcspace.IOperation[]
                {new Calcspace.SubOperation(), new Calcspace.SumOperation(),
                new Calcspace.MultOperation(), new Calcspace.FactOperation(),
                new Calcspace.PiOperation()});
            //int result = calc.Sum(1, 2);
            var result1 = calc.Execute("Sum", new object[] { 5, 4 });
            var result2 = calc.Execute("Sub", new object[] { 5, 4 });
            var result3 = calc.Execute("Mult", new object[] { 5, 4 });
            var result4 = calc.Execute("Fact", new object[] { 5 });
            var result5 = calc.Execute("Pi", new object[] { null });
            Console.WriteLine($"sum = {result1}");
            Console.WriteLine($"sub = {result2}");
            Console.WriteLine($"Mult = {result3}");
            Console.WriteLine($"Fact = {result4}");
            Console.WriteLine($"Pi = {result5}");
            Console.ReadKey();
        }
    }
}
