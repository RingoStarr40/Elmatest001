using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Calc; //алиас для Calc

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new C.Calc();
            int result = calc.Sum(1, 2); 
            Console.WriteLine($"{result}");
            Console.ReadKey();
        }
    }
}
