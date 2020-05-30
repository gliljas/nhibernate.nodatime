using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalTime"/> as a <see cref="DateTime"/>, using <see cref="TimeType"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A more appropriate choice is the <see cref="LocalTimeAsTimeAsTimeSpanType"/>.
    /// The underlying <see cref="DbType.Time"/> tends to be handled differently by different
    /// DataProviders.
    /// </para>
    /// </remarks>
    public class LocalTimeAsTimeType : AbstractLocalTimeType<DateTime, TimeType>
    {
        protected override LocalTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value).TimeOfDay;

        protected override DateTime Wrap(LocalTime value) => value.On(new LocalDate(1970, 1, 1)).ToDateTimeUnspecified();
    }
}