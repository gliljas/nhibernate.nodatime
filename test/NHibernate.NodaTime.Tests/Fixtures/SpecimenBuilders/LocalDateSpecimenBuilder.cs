using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class LocalDateSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<LocalDate>
    {
        public override LocalDate CreateFromDateTimeOffset(DateTimeOffset dateTime) => LocalDate.FromDateTime(dateTime.DateTime);
    }
}