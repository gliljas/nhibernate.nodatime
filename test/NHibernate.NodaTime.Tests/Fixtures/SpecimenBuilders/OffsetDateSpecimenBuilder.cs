using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetDateSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetDate>
    {
        public override OffsetDate CreateFromDateTimeOffset(DateTimeOffset dateTime) => OffsetDateTime.FromDateTimeOffset(dateTime).ToOffsetDate();
    }
}