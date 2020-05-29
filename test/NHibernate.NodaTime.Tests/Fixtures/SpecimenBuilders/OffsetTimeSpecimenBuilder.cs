using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetTimeSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetTime>
    {
        public override OffsetTime CreateFromDateTimeOffset(DateTimeOffset dateTimeOffset) => OffsetDateTime.FromDateTimeOffset(dateTimeOffset).ToOffsetTime();
    }

}
