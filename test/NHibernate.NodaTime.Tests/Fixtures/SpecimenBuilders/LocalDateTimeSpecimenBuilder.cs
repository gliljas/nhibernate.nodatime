using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalDateTimeSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<LocalDateTime>
    {
        public override LocalDateTime CreateFromDateTimeOffset(DateTimeOffset dateTime)=> LocalDateTime.FromDateTime(dateTime.DateTime);
    }
}
