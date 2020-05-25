using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTimeOffset"/>, using <see cref="DateTimeOffsetType"/>
    /// </summary>
    public class InstantAsDateTimeOffsetType : AbstractInstantType<DateTimeOffset, DateTimeOffsetType>
    {
        protected override Instant Unwrap(DateTimeOffset value) => Instant.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(Instant value) => value.ToDateTimeOffset();
    }
}
