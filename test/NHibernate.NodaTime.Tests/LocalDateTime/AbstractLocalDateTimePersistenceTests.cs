using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractLocalDateTimePersistenceTests<TUserType> : AbstractPersistenceTests<LocalDateTime, TUserType>
    where TUserType : new()
    {
        protected AbstractLocalDateTimePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
