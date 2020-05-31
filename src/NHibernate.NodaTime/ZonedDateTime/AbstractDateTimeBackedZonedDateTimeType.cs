using NHibernate.Type;
using NHibernate.UserTypes;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a UTC <see cref="DateTime"/> and a <see cref="DateTimeZone"/>, using <see cref="TDateTimeType"/> and <see cref="TDateTimeZoneType"/>
    /// </summary>
    /// <typeparam name="TDateTimeType"></typeparam>
    /// <typeparam name="TDateTimeZoneType"></typeparam>
    public abstract class AbstractDateTimeBackedZonedDateTimeType<TDateTimeType, TDateTimeZoneType> : AbstractZonedDateTimeType<DateTime, TDateTimeType, TDateTimeZoneType>
        where TDateTimeType : AbstractDateTimeType, new()
        where TDateTimeZoneType : IUserType
    {
        protected override string Property1Name => "DateTime";
        protected override int Property1ColumnSpan => 1;

        protected override ZonedDateTime Unwrap(DateTime property1Value, DateTimeZone property2Value) => Instant.FromDateTimeUtc(property1Value).InZone(property2Value);

        protected override DateTime GetProperty1Value(ZonedDateTime value) => value.ToDateTimeUtc();
    }


}