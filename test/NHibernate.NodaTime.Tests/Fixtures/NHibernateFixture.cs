using Microsoft.Extensions.Configuration;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NHibernateFixture
    {
        private Lazy<ISessionFactory> _sessionFactory;
        private Lazy<Configuration> _configuration;
        private Action<Configuration> _configurationAction;

        public NHibernateFixture()
        {
            _configuration = new Lazy<Configuration>(() => CreateConfiguration());
            _sessionFactory = new Lazy<ISessionFactory>(() => CreateSessionFactory());
        }

        private ISessionFactory CreateSessionFactory()
        {
            var cfg = _configuration.Value;
            var exporter = new SchemaExport(cfg);
            exporter.Create(true, true);
            return _configuration.Value.BuildSessionFactory();
        }

        private Configuration CreateConfiguration()
        {
            var configuration = new Configuration();

            var configRoot = TestConfiguration.GetConfigurationRoot();

            var nhibernateSection = configRoot.GetSection("nhibernate");

            nhibernateSection.Bind(configuration.Properties);

            _configurationAction?.Invoke(configuration);

            return configuration;
        }

        public void Configure(Action<Configuration> configurationAction)
        {
            _configurationAction = configurationAction;
        }

        public ISessionFactory SessionFactory => _sessionFactory.Value;
    }
}