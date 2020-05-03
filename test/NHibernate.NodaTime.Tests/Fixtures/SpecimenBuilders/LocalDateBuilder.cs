using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalDateBuilder : AbstractDateTimeOffsetBasedBuilder<LocalDate>
    {
        public override LocalDate CreateFromDateTime(DateTimeOffset dateTime) => LocalDate.FromDateTime(dateTime.DateTime);
    }
}
