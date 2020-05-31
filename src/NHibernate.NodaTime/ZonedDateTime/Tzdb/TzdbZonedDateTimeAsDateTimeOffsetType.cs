using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a <see cref="DateTimeOffset"/> and a <see cref="Offset"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This type preserves the offset from the <see cref="ZonedDateTime"/>
    /// </para>
    /// </remarks>
    public class TzdbZonedDateTimeAsDateTimeOffsetType : AbstractDateTimeOffsetBackedZonedDateTimeType<EnhancedDateTimeOffsetType, TzdbDateTimeZoneType>
    {

    }

    /// <summary>
    /// Persists a <see cref="ZonedDateTime"/> as a <see cref="DateTimeOffset"/> and a <see cref="Offset"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This type preserves the offset from the <see cref="ZonedDateTime"/>
    /// </para>
    /// </remarks>
    public class TzdbZonedDateTimeAsDateTimeOffsetNoMsType : AbstractDateTimeOffsetBackedZonedDateTimeType<EnhancedDateTimeOffsetNoMsType, TzdbDateTimeZoneType>
    {

    }
}