using Calcspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using C = Calcspace; //алиас для Calc

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any()) //проверка на количество аргументов
            {
                Console.WriteLine("calc.exe \"sum\" \"1\" \"2\"");
                Console.ReadKey();
                return;
            }
            #region Получение всех возможных операций
            var operations = new List<IOperation>();
            //найти файлы .dll и .exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //загрузить их
            foreach (var file in files)
            {
                //создать экземпляр класса
                //и все эти экземпляры передаём в Calc

                var assembly = Assembly.LoadFile(file); //получаем сборку
                var types = assembly.GetTypes();
                //пустой список IOperation-ов
                foreach (var type in types)
                {
                    //Console.WriteLine(type.Name); //вывод на экран типов и даже интерфейсов
                    var interfaces = type.GetInterfaces();
                    //найти реализацию интерфейса
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation; //приведение типов более безопасно, так ничего не крашится
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                   
                }
            }

            #endregion

            var Calc = new C.Calc(operations);
            var activeoper = args[0];
            var parameters = args.Skip(1).ToArray(); //Select(a => (object)a).ToArray(); - это не всю сущность, а некоторые типы
            
                var result1 = Calc.Execute(activeoper, parameters);
            Console.WriteLine($"result = {result1}");
            Console.ReadKey();
        }
    }
}
