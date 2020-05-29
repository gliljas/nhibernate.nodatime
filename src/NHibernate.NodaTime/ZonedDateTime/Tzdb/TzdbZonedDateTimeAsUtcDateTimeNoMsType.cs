using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a UTC <see cref="DateTime"/> and a <see cref="DateTimeZone"/>, using <see cref="UtcDateTimeNoMsType"/> and <see cref="TzdbDateTimeZoneType"/>
    /// </summary>
    public class TzdbZonedDateTimeAsUtcDateTimeNoMsType : AbstractDateTimeBackedZonedDateTimeType<UtcDateTimeNoMsType, TzdbDateTimeZoneType>
    {
    }
}
