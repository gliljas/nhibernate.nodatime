using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.UserTypes;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateIntervalPersistenceTests<TUserType> : AbstractPersistenceTests<DateInterval, TUserType>
        where TUserType : ICompositeUserType, new()
    {
        protected AbstractDateIntervalPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsContains(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.Contains(localDate));
        }

        [SkippableFact]
        public virtual void SupportsEnd()
        {
            SupportsPropertyOrMethod(x => x.End);
        }
        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsIntersection(DateInterval dateInterval)
        {
            SupportsPropertyOrMethod(x => x.Intersection(dateInterval));
        }

        [SkippableFact]
        public virtual void SupportsLength()
        {
            SupportsPropertyOrMethod(x => x.Length);
        }

        [SkippableFact]
        public virtual void SupportsStart()
        {
            SupportsPropertyOrMethod(x => x.Start);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsUnion(DateInterval dateInterval)
        {
            SupportsPropertyOrMethod(x => x.Union(dateInterval));
        }
    }
}