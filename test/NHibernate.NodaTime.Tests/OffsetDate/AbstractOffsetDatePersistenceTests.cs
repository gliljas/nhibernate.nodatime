﻿using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDatePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDate, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsToDateTimeOffset(LocalTime time)
        {
            SupportsPropertyOrMethod(x => x.At(time));
        }

        [SkippableFact]
        public virtual void SupportsDate()
        {
            SupportsPropertyOrMethod(x => x.Date);
        }

        [SkippableFact]
        public virtual void SupportsDay()
        {
            SupportsPropertyOrMethod(x => x.Day);
        }

        [SkippableFact]
        public virtual void SupportsDayOfWeek()
        {
            SupportsPropertyOrMethod(x => x.DayOfWeek);
        }

        [SkippableFact]
        public virtual void SupportsEra()
        {
            SupportsPropertyOrMethod(x => x.Era);
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }

        [SkippableFact]
        public virtual void SupportsYear()
        {
            SupportsPropertyOrMethod(x => x.Year);
        }

        [SkippableFact]
        public virtual void SupportsYearOfEra()
        {
            SupportsPropertyOrMethod(x => x.YearOfEra);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsEquals(OffsetDate offsetDate)
        {
            SupportsPropertyOrMethod(x => x.Equals(offsetDate));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsWithOffset(Offset offset)
        {
            SupportsPropertyOrMethod(x => x.WithOffset(offset));
        }

    }
}
