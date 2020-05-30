using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetDate"/> as a <see cref="DateTimeOffset"/>, using <see cref="EnhancedDateTimeOffsetType"/>
    /// </summary>
    public class OffsetDateAsDateTimeOffsetType : AbstractOffsetDateType<DateTimeOffset, EnhancedDateTimeOffsetType>
    {
        protected override OffsetDate Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetDate();

        protected override DateTimeOffset Wrap(OffsetDate value) => value.At(LocalTime.MinValue).ToDateTimeOffset();
    }
}