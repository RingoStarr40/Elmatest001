﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DomainModel.Helpers
{
    public class NHibernateHelper
    {
       // private static ISessionFactory _sessionFactory;

       /* private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Operation).Assembly); //добавление сборки
                    new SchemaUpdate(configuration).Execute(true, false);
                    _sessionFactory = configuration.BuildSessionFactory();

                }
                return _sessionFactory;
            }
        }*/

        public static ISession OpenSession()
        {

            ISessionFactory sessionFactory = Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ringo\Documents\Elma\Elmatest001\Web\App_Data\Database.mdf;Integrated Security=True").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Operation>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
