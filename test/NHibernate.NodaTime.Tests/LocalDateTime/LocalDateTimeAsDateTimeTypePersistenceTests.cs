using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class LocalDateTimeAsDateTimeTypePersistenceTests : AbstractLocalDateTimePersistenceTests<LocalDateTimeAsDateTimeType>
    {
        public LocalDateTimeAsDateTimeTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}