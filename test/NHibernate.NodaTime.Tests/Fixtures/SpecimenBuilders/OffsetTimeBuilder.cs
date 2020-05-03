using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetTimeBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetTime>
    {
        public override OffsetTime CreateFromDateTime(DateTimeOffset dateTimeOffset) => OffsetDateTime.FromDateTimeOffset(dateTimeOffset).ToOffsetTime();
    }

}
