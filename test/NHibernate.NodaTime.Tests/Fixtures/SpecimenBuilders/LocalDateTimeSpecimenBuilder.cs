using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalDateTimeSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<LocalDateTime>
    {
        public override LocalDateTime CreateFromDateTime(DateTimeOffset dateTime)=> LocalDateTime.FromDateTime(dateTime.DateTime);
    }
}
