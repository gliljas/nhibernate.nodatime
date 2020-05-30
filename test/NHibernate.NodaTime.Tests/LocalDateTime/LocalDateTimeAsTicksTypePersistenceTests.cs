using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class LocalDateTimeAsTicksTypePersistenceTests : AbstractLocalDateTimePersistenceTests<LocalDateTimeAsTicksType>
    {
        public LocalDateTimeAsTicksTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}