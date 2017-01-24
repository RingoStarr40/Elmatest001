using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calcspace;
using Web.Models;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using Calc;
using Services;
using System.Diagnostics;
using DomainModel.Helpers;
using Models;

namespace Web.Controllers
{
    public class CalcController : Controller
    {
        private IOperationResultRepository repository { get; set; }

        public CalcController()
        {
            repository = new NHOperationResultRepository();
        }
        // GET: Calc
        public ActionResult Index()
        {
            var opers = CalcService.GetInstance().Calculator.GetOperationNames().Select(o => new SelectListItem() { Text = o, Value = o });
            ViewBag.Operations = opers;
            return View(new OperationModel());
        }

        public ActionResult Execute(OperationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = CalcService.GetInstance().Calculator.Execute(model.Name, model.GetParameters());
            stopWatch.Stop();

            var operResult = repository.Create();
            operResult.ArgumentCount = model.GetParameters().Count();
            operResult.Arguments = string.Join(",", model.GetParameters());
            operResult.Operation = repository.FindOperByName(model.Name); //реализовать;
            operResult.Result = result.ToString();
            operResult.ExecTimeMs = stopWatch.ElapsedMilliseconds;
            repository.Update(operResult);

            using (var session = NHibernateHelper.OpenSession()) //Это надо реализовать в репозитории, это способы получения данных
            {
                operResult.Author = session.Get<UserTable>(1);

                /*session.Load<UserTable>(1);

                var sql = session.CreateSQLQuery("select * from UserTable where ID = ?");
                sql.SetParameter(0, 1);
                sql.UniqueResult<UserTable>();

                //session.CreateCriteria

                session.QueryOver<UserTable>()
                    .And(x => x.Id == 1)
                    .List<UserTable>()
                    .FirstOrDefault();*/
            }


                ViewData.Model = $"result = {result}";
            return View();
        }

        
    }
}