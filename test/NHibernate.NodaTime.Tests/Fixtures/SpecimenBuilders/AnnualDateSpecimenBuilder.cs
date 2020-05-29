using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class AnnualDateSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<AnnualDate>
    {
        public override AnnualDate CreateFromDateTimeOffset(DateTimeOffset dateTimeOffset) => new AnnualDate(dateTimeOffset.Month, dateTimeOffset.Day);
    }
}
