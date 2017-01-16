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
                {new Calcspace.SumOperation() });
            int result = calc.Sum(1, 2);
            var result2 = calc.Execute("Sum", new object[] { 1, 2 });
            Console.WriteLine($"Result = {result}");
            Console.ReadKey();
        }
    }
}
