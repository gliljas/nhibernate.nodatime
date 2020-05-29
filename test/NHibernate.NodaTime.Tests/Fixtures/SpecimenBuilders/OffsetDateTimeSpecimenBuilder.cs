using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetDateTimeSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetDateTime>
    {
        public override OffsetDateTime CreateFromDateTimeOffset(DateTimeOffset dateTime) => OffsetDateTime.FromDateTimeOffset(dateTime);
    }
}
