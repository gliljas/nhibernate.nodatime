using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetPersistenceTests<TUserType> : AbstractPersistenceTests<Offset, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(Offset offset)
        {
            SupportsPropertyOrMethod(x => x.Equals(offset));
        }

        [SkippableFact]
        public virtual void SupportsMilliseconds()
        {
            SupportsPropertyOrMethod(x => x.Milliseconds);
        }

        [SkippableFact]
        public virtual void SupportsNanoseconds()
        {
            SupportsPropertyOrMethod(x => x.Nanoseconds);
        }

        [SkippableFact]
        public virtual void SupportsSeconds()
        {
            SupportsPropertyOrMethod(x => x.Seconds);
        }
        [SkippableFact]
        public virtual void SupportsTicks()
        {
            SupportsPropertyOrMethod(x => x.Ticks);
        }
        [SkippableFact]
        public virtual void SupportsToTimeSpan()
        {
            SupportsPropertyOrMethod(x => x.ToTimeSpan());
        }

    }
}