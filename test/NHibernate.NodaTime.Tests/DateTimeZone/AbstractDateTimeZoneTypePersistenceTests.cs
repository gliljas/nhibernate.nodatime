using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractDateTimeZoneTypePersistenceTests<TDateTimeZoneType> : AbstractPersistenceTests<DateTimeZone, TDateTimeZoneType>
         where TDateTimeZoneType : new()
    {
        protected AbstractDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAtLeniently(LocalDateTime localDateTime)
        {
            Skip.If(true, "Not supported");
            SupportsPropertyOrMethod(x => x.AtLeniently(localDateTime));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAtStartOfDay(LocalDate localDate)
        {
            Skip.If(true, "Not supported");
            SupportsPropertyOrMethod(x => x.AtStartOfDay(localDate));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAtStrictly(LocalDateTime localDateTime)
        {
            Skip.If(true, "Not supported");
            SupportsPropertyOrMethod(x => x.AtStrictly(localDateTime));
        }

        [SkippableFact]
        public virtual void SupportsId()
        {
            SupportsPropertyOrMethod(x => x.Id);
        }

        [SkippableFact]
        public virtual void SupportsMaxOffset()
        {
            Skip.If(true, "Not supported");
            SupportsPropertyOrMethod(x => x.MaxOffset);
        }

        [SkippableFact]
        public virtual void SupportsMinOffset()
        {
            Skip.If(true, "Not supported");
            SupportsPropertyOrMethod(x => x.MinOffset);
        }

        [SkippableFact]
        public virtual void SupportsToString()
        {
            SupportsPropertyOrMethod(x => x.ToString());
        }
    }
}