using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class OffsetDateSpecimenBuilder : AbstractDateTimeOffsetBasedBuilder<OffsetDate>
    {
        public override OffsetDate CreateFromDateTime(DateTimeOffset dateTime) => OffsetDateTime.FromDateTimeOffset(dateTime).ToOffsetDate();
    }
}
