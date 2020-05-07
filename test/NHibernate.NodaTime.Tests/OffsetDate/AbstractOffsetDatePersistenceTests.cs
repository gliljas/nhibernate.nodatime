using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDatePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDate, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
