using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class YearMonthSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<YearMonth>
    {
        public override YearMonth CreateFromDateTimeOffset(DateTimeOffset dateTimeOffset) => new YearMonth(dateTimeOffset.Year, dateTimeOffset.Month);
    }
}