using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using DomainModel.Helpers;
using NHibernate.Criterion;
using System;

namespace Services
{
    public class NHOperationResultRepository : IOperationResultRepository
    {
        public OperationResult Create()
        {
            return new OperationResult() { Id = 0 };
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
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    try
                    {
                        session.Save(operResult);
                       
                    }
                    catch (Exception ex)
                    {
                        //вывод нашего ex в лог
                        transaction.Rollback();
                        return;
                    }
                    transaction.Commit();
                }                 
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();

            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria (typeof (OperationResult)); //создание новой критерии. Создание запроса к базе по нашему классу
                //criteria.Add(Restrictions.Ge("Id", 3));
                operations = criteria.List<OperationResult>().ToList();
            }

            return operations;
        }

        public Operation FindOperByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Operation)); //создание новой критерии. Создание запроса к базе по нашему классу
                criteria.Add(Restrictions.Eq("Name", name));
                criteria.SetMaxResults(1);
                return criteria.List<Operation>().FirstOrDefault();
            }

           
        }
    }
}