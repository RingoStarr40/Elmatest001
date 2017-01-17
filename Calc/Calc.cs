using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcspace
{
    public class Calc
    {
        public Calc(IEnumerable<IOperation> opers) //позволяет создавать множество видов списков 
        {
            operations = opers; //задавание операции

        }

        public Calc(IOperation[] opers)
        {
            operations = opers; //задавание операции
        }

        
        private IEnumerable<IOperation> operations { get; set; } //массив всех операций, которые может делать калькулятор

        public object Execute(string name, object[] args) //имя и параметры операции
        {
            name = name.ToLower();
            var oper = operations.FirstOrDefault(o => o.Name == name); //ищем операцию
            if (oper == null)
                return $"Operation \"{name}\" not found";
            return oper.Execute(args); //нашли - мы ее вызываем
        }

        public IEnumerable<string> GetOperationNames()
        {
            return operations.Select(o => o.Name); //у каждой операции берем только имя
        }
    }

    public interface IOperation //интерфейс
    {
        string Name { get; } //имя операции
        object Execute(object[] args); //результат и входные данные
    }

    public class SumOperation : IOperation //здесь написаное - что SumOperation - реализация IOperation
    {
        public string Name { get { return "sum"; } } //get - другой класс запрашивает значение. set - задавание операции
        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);
            var y = Convert.ToInt32(args[1]);
            return x + y;
        }
    }

    public class SubOperation : IOperation
    {
        public string Name { get { return "sub"; } }

        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]) - Convert.ToInt32(args[1]);
        }
    }

    public class MultOperation : IOperation
    {
        public string Name { get { return "mult"; } }

        public object Execute(object[] args)
        {
            return (int)args[0] * (int)args[1];
        }
    }

    public class FactOperation : IOperation
    {
        public string Name { get { return "fact"; } }

        public object Execute(object[] args)
        {
            int result = 1;
            for (int i = 1; i <= (int)args[0]; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    public class PiOperation : IOperation
    {
        public string Name { get { return "pi"; } }
        public object Execute(object[] args)
        {
            return (float)Math.PI;
        } 
    }
}
