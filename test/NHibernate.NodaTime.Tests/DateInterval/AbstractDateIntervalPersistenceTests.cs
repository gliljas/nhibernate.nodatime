using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateIntervalPersistenceTests<TUserType> : AbstractPersistenceTests<DateInterval, TUserType>
        where TUserType : ICompositeUserType, new()
    {
        protected AbstractDateIntervalPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
