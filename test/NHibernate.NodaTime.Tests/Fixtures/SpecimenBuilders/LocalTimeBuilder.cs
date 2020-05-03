using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalTimeBuilder : AbstractDateTimeOffsetBasedBuilder<LocalTime>
    {
        public override LocalTime CreateFromDateTime(DateTimeOffset dateTime) => new LocalTime(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }
}
