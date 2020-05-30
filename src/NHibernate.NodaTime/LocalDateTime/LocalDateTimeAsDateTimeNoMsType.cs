using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalDateTime"/> as a <see cref="DateTime"/>, using <see cref="DateTimeNoMsType"/>
    /// </summary>
    public class LocalDateTimeAsDateTimeNoMsType : AbstractLocalDateTimeAsDateTimeType<DateTimeNoMsType>
    {
    }
}