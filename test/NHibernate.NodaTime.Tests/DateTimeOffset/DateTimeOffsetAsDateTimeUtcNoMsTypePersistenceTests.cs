using NHibernate.NodaTime.Tests.Fixtures;
using System;

namespace NHibernate.NodaTime.Tests
{
    public class DateTimeOffsetAsDateTimeUtcNoMsTypePersistenceTests : AbstractDateTimeOffsetPersistenceTests<DateTimeOffsetAsUtcDateTimeNoMsType>
    {
        public DateTimeOffsetAsDateTimeUtcNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        protected override DateTimeOffset AdjustValue(DateTimeOffset value)
        {
            return new DateTimeOffset(value.DateTime.Ticks - (value.DateTime.Ticks % TimeSpan.TicksPerSecond), value.Offset);
        }
    }
}