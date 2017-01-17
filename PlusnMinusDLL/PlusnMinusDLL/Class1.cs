using Calcspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusnMinusDLL
{
    public class Plus : IOperation
    {
        public string Name { get {return "plus"; } }

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]);
        }
    }

    public class Minus : IOperation
    {
        public string Name { get { return "minus"; } }
        
        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) - Convert.ToInt32(args[1]);
        }
    }
}
