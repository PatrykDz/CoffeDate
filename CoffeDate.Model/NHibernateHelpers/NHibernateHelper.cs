using CoffeDate.Model.NHibernateMappingFiles;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeDate.Model.NHibernateHelpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    Configuration nhibernateConfig = new Configuration();
                    nhibernateConfig.DataBaseIntegration(x =>
                    {
                        x.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                        x.Driver<NHibernate.Driver.SqlClientDriver>();
                        x.ConnectionString =
                        System.Configuration.ConfigurationManager.ConnectionStrings["STACJONARNYConnectionString"].ConnectionString;
                        x.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                        x.BatchSize = 100;
                        x.LogSqlInConsole = false;
                        x.SchemaAction = SchemaAutoAction.Update;
                    });
                    //nhibernateConfig.AddInputStream(HbmSerializer.Default.Serialize(typeof(User)));
                    nhibernateConfig.AddAssembly(typeof(User).Assembly);
                    _sessionFactory = nhibernateConfig.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }


    }
}