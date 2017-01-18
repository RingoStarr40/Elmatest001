using Calcspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new OperationModel());
        }

        public ActionResult Execute(OperationModel model)
        {
            #region Получение всех возможных операций
            var operations = new List<IOperation>();

            
            var files = Directory.GetFiles(Server.MapPath("\\App_Data"), "*.exe")
                .Union(Directory.GetFiles(Server.MapPath("\\App_Data"), "*.dll"));


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

            var calc = new Calcspace.Calc(operations);
            var result = calc.Execute(model.Name, model.GetParameters());
            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}