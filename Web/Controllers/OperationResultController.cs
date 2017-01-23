using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Web.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepository repository { get; set; }

        public OperationResultController()
        {
            repository = new NHOperationResultRepository();
        }
        // GET: OperationResult
        public ActionResult Index()
        {
            //нужно фильтровать операции - выводить только те, которые выполнялись дольше 1 секунды
            //var operations = repository.GetAll().OrderByDescending(it => it.Id).Take(20);
            var operations = repository.GetAll();
            return View(operations);
        }
    }
}