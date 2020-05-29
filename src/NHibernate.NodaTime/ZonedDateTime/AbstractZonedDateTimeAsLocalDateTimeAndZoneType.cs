using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a <see cref="LocalDateTime"/> and a <see cref="DateTimeZone"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// 
    /// </para>
    /// </remarks>
    /// <typeparam name="TLocalDateTimeType"></typeparam>
    /// <typeparam name="TDateTimeZoneType"></typeparam>
    public abstract class AbstractZonedDateTimeAsLocalDateTimeAndZoneType<TLocalDateTimeType, TDateTimeZoneType> : AbstractZonedDateTimeType<LocalDateTime, CustomType<TLocalDateTimeType>, TDateTimeZoneType>
        where TLocalDateTimeType : IUserType
        where TDateTimeZoneType : IUserType
    {
        protected override string Property1Name => nameof(ZonedDateTime.LocalDateTime);
        protected override int Property1ColumnSpan => 1;
        protected override ZonedDateTime Unwrap(LocalDateTime property1Value, DateTimeZone property2Value) => property1Value.InZoneLeniently(property2Value);
        protected override LocalDateTime GetProperty1Value(ZonedDateTime value) => value.LocalDateTime;
    }
}
