using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateSample.Mapping;

namespace NHibernateSample
{
    public static class NHibernateHelper
    {
        private static ISessionFactory? _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.Standard.ConnectionString("Host=localhost;Port=5432;Database=test_api;Username=postgres;Password=1"))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookMapping>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }
    }
}