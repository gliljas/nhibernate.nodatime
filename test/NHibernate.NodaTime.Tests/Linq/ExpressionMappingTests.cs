using FluentAssertions;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Mapping.ByCode;
using NHibernate.NodaTime.Linq;
using NodaTime;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NHibernate.NodaTime.Tests.Linq
{
    public class ExpressionMappingTests
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ExpressionMapping _sut;

        public ExpressionMappingTests()
        {
            var cfg = new Configuration();
            cfg.Properties[Cfg.Environment.Dialect] = typeof(SQLiteDialect).AssemblyQualifiedName;
            cfg.Properties[Cfg.Environment.ConnectionString] = "Data Source=:memory:;Version=3;New=True;";
            var mapper = new ModelMapper();
            mapper.Class<MappingTestClass>(cm =>
            {
                cm.Id(x => x.Id, m => m.Generator(Generators.Assigned));
            });

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            cfg.AddMapping(mapping);

            _sessionFactory = cfg.BuildSessionFactory();

            _sut = new ExpressionMapping(_sessionFactory as ISessionFactoryImplementor);
        }

        [Fact]
        public void GetsTypeFromProperty()
        {
            var expression = GetExpression(x => x.TestProperty);
            var result = _sut.TryGetMappedTypesFromExpression(expression);
            result.Should().HaveCount(1);
            //result[0].Should().Be()

            //  type.Should().BeOfType<NHibernate.Type.CustomType>();
        }

        private Expression GetExpression<T>(Expression<Func<MappingTestClass, T>> expression)
        {
            var queryable = _sessionFactory.OpenSession().Query<MappingTestClass>();
            var query = queryable.Select(expression);

            return query.Expression;
        }

        private T Extract<T>(T instance) => instance;

        public class MappingTestClass
        {
            public virtual int Id { get; set; }

            public virtual Instant TestProperty { get; set; }
            public virtual Instant TestProperty2 { get; set; }
        }
    }
}