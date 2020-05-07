using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class InstantAsDateTimeOffsetType : VersionedAbstractStructType<Instant, DateTimeOffset, DateTimeOffsetType>
    {
        protected override Instant Unwrap(DateTimeOffset value) => Instant.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(Instant value) => value.ToDateTimeOffset();
    }
}
