using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetDateTimeAsDateTimeOffsetType : VersionedAbstractStructType<OffsetDateTime, DateTimeOffset, DateTimeOffsetType>
    {
        protected override OffsetDateTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(OffsetDateTime value) => value.ToDateTimeOffset();

    }
}
