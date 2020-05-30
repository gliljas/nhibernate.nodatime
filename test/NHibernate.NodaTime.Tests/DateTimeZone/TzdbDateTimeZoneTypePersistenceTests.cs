using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class TzdbDateTimeZoneTypePersistenceTests : AbstractPersistenceTests<DateTimeZone, TzdbDateTimeZoneType>
    {
        public TzdbDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAtLeniently(LocalDateTime localDateTime)
        {
            SupportsPropertyOrMethod(x => x.AtLeniently(localDateTime));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsAtStartOfDay(LocalDate localDate)
        {
            SupportsPropertyOrMethod(x => x.AtStartOfDay(localDate));
        }

        [SkippableFact]
        public virtual void SupportsAtStrictly(LocalDateTime localDateTime)
        {
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
            SupportsPropertyOrMethod(x => x.MaxOffset);
        }

        [SkippableFact]
        public virtual void SupportsMinOffset()
        {
            SupportsPropertyOrMethod(x => x.MinOffset);
        }
    }
}