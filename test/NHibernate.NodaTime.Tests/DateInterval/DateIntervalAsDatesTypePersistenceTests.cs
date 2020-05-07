using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class DateIntervalAsDatesTypePersistenceTests : AbstractDateIntervalPersistenceTests<DateIntervalAsDatesType>
    {
        public DateIntervalAsDatesTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
