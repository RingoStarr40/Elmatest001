using Calcspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PiOperation : IOperation
    {
        public string Name { get { return "Pi"; } }
        public object Execute(object[] args)
        {
            return (float)Math.PI;
        }
    }
}
