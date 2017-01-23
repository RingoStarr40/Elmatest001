using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;

namespace Services
{
    public class OperationResultRepository : IOperationResultRepository
    {
        public OperationResult Create()
        {
            using (var db = new CalcContext())
            {
                return db.OperationResult.Create();
            }
        }

        public bool Delete(int Id)
        {
            var item = Load(Id);
            if (item == null)
                return false;
            using (var db = new CalcContext())
            {
                db.OperationResult.Remove(item);
                db.SaveChanges();
            }
            return true;
        }

        public OperationResult Load(int Id)
        {
            using (var db = new CalcContext())
            {
                return db.OperationResult.FirstOrDefault(o => o.Id == Id);
            }
        }

        public void Update(OperationResult operResult)
        {
            using (var db = new CalcContext())
            {
                db.Entry<OperationResult>(operResult).State =
                    operResult.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();

            using (var db = new CalcContext())
            {
                operations = db.OperationResult
                    .Include("Operation")
                    .AsNoTracking() // не следить за изменениями
                    .ToList();

                // все данные вытаскиваем и затем на клиенте фильтруеем
                //IEnumerable<OperationResult> ops = db.OperationResults;
                //var result = operations.Where(o => o.Id > 3);

                // данные фильтрует БД
                //IQueryable<OperationResult> qops = db.OperationResults;
                //var qresult = qops.Where(o => o.Id > 3);

            }

            return operations;
        }

        public Operation FindOperByName(string name)
        {
            using (var db = new CalcContext())
            {
                return db.Operations.FirstOrDefault(o => o.Name == name);
            }
        }
    }
}