using NHibernate.Cfg;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NHibernateFixture
    {
        private Lazy<ISessionFactory> _sessionFactory;
        private Lazy<Configuration> _configuration;

        public NHibernateFixture()
        {
            _configuration = new Lazy<Configuration>(() => CreateConfiguration());
            _sessionFactory = new Lazy<ISessionFactory>(() => CreateSessionFactory());

        }

        private ISessionFactory CreateSessionFactory()
        {
            return _configuration.Value.BuildSessionFactory();
        }

        private Configuration CreateConfiguration()
        {
            var configuration = new Configuration();

            Configure(configuration);

            return configuration;
        }

        public virtual void Configure(Configuration configuration)
        { 
        }

        public ISessionFactory SessionFactory => _sessionFactory.Value;
    }
}
