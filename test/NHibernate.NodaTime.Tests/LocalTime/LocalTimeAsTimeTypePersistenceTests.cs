using NHibernate.NodaTime.Tests.Fixtures;

namespace NHibernate.NodaTime.Tests
{
    public class LocalTimeAsTimeTypePersistenceTests : AbstractLocalTimePersistenceTests<LocalTimeAsTimeAsTimeSpanType>
    {
        public LocalTimeAsTimeTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
