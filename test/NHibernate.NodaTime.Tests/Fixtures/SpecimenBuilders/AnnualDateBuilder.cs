using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class AnnualDateBuilder : AbstractDateTimeOffsetBasedBuilder<AnnualDate>
    {
        public override AnnualDate CreateFromDateTime(DateTimeOffset dateTimeOffset) => new AnnualDate(dateTimeOffset.Month, dateTimeOffset.Day);
    }
}
