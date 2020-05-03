using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetDateBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetDate>
    {
        public override OffsetDate CreateFromDateTime(DateTimeOffset dateTime) => OffsetDateTime.FromDateTimeOffset(dateTime).ToOffsetDate();
    }
}
