using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTime"/>, using <see cref="UtcDateTimeType"/>
    /// </summary>
    public class InstantAsUtcDateTimeType : AbstractInstantAsDateTimeType<UtcDateTimeType>
    {

    }
}