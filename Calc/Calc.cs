using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcspace
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            return (int)Execute("Sum", new object[] { x, y }); //
        }

        public Calc(IOperation[] opers)
        {
            operations = opers; //задавание операции
        }

        public Calc()
        {
        }

        private IOperation[] operations { get; set; } //массив всех операций, которые может делать калькулятор

        public object Execute(string name, object[] args) //имя и параметры операции
        {
            var oper = operations.FirstOrDefault(o => o.Name == name); //ищем операцию
            return oper.Execute(args); //нашли - мы ее вызываем
        }
    }

    public interface IOperation //интерфейс
    {
        string Name { get; } //имя операции
        object Execute(object[] args); //результат и входные данные
    }

    public class SumOperation : IOperation //здесь написаное - что SumOperation - реализация IOperation
    {
        public string Name { get { return "Sum"; } } //get - другой класс запрашивает значение. set - задавание операции
        public object Execute(object[] args)
        {
            return (int)args[0] + (int)args[1];
        }
    }
}
