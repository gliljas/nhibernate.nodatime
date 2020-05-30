using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetTime"/> as a <see cref="DateTimeOffset"/>, using <see cref="EnhancedDateTimeOffsetType"/>
    /// The date portion is set to the Unix Epoch date
    /// </summary>
    public class OffsetTimeAsDateTimeOffsetType : AbstractOffsetTimeType<DateTimeOffset, EnhancedDateTimeOffsetType>
    {
        protected override OffsetTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetTime();

        protected override DateTimeOffset Wrap(OffsetTime value) => value.On(new LocalDate(1970, 1, 1)).ToDateTimeOffset();
    }
}