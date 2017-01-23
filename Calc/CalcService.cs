using Calcspace;
using System;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Calc
{
    public class CalcService
    {
        private static readonly Lazy<CalcService> lazy =
            new Lazy<CalcService>(() => new CalcService());

        public string Name { get; private set; }

        public Calcspace.Calc Calculator { get; private set; }

        private CalcService()
        {
            Name = System.Guid.NewGuid().ToString();
            //var path = ConfigurationManager.AppSettings["pathToDll"];
            LoadOperations(HostingEnvironment.MapPath("//App_Data"));
        }

        //получение операций
        private void LoadOperations(string pathToDll)
        {
            var operations = new List<IOperation>();
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(pathToDll, "*.dll");

            //загрузить их
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
                {
                    // найти реализацюию интерфейса IOperation
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }

             Calculator = new Calcspace.Calc(operations);
        }

        public static CalcService GetInstance()
        {
            return lazy.Value;
        }
    }
}
