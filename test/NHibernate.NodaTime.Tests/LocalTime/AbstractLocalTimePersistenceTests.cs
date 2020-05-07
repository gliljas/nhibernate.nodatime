using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalTimePersistenceTests<TUserType> : AbstractPersistenceTests<LocalTime, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
