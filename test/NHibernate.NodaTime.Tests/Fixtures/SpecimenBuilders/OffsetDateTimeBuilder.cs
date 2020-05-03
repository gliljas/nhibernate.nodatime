using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetDateTimeBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetDateTime>
    {
        public override OffsetDateTime CreateFromDateTime(DateTimeOffset dateTime) => OffsetDateTime.FromDateTimeOffset(dateTime);
    }
}
