using Calcspace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperOperaions
{
    public class Therma : IOperation
    {
        public string Name { get { return "Therma"; } }

        public object Execute(object[] args)
        {
            int result = 1;
            for (int i = 1; i <= Convert.ToInt32(args[0]); i++)
            {
                result *= i;
            }
            return Convert.ToInt32(result);
        }
    }
}
