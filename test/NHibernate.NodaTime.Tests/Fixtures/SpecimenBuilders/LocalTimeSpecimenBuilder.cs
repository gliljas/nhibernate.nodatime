using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalTimeSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<LocalTime>
    {
        public override LocalTime CreateFromDateTime(DateTimeOffset dateTime) => new LocalTime(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }
}
