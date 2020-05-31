using NHibernate.Type;
using NHibernate.UserTypes;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a <see cref="DateTimeOffset"/> and a <see cref="DateTimeZone"/>, using <see cref="TDateTimeOffsetType"/> and <see cref="TDateTimeZoneType"/>
    /// </summary>
    /// <typeparam name="TDateTimeType"></typeparam>
    /// <typeparam name="TDateTimeZoneType"></typeparam>
    public abstract class AbstractDateTimeOffsetBackedZonedDateTimeType<TDateTimeOffsetType, TDateTimeZoneType> : AbstractZonedDateTimeType<DateTimeOffset, TDateTimeOffsetType, TDateTimeZoneType>
        where TDateTimeOffsetType : DateTimeOffsetType, new()
        where TDateTimeZoneType : IUserType
    {
        protected override string Property1Name => "DateTimeOffset";
        protected override int Property1ColumnSpan => 1;

        protected override ZonedDateTime Unwrap(DateTimeOffset property1Value, DateTimeZone property2Value) => Instant.FromDateTimeOffset(property1Value).InZone(property2Value);

        protected override DateTimeOffset GetProperty1Value(ZonedDateTime value) => value.ToDateTimeOffset();
    }
}