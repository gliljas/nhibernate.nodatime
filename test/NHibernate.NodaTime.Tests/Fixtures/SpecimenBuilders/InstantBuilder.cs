using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class InstantBuilder : AbstractDateTimeOffsetBasedBuilder<Instant>
    {
        public override Instant CreateFromDateTimeOffset(DateTimeOffset dateTimeOffset) => Instant.FromDateTimeOffset(dateTimeOffset);
    }
}