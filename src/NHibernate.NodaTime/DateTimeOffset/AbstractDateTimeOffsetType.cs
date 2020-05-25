using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="DateTimeOffset"/> as a <see cref="TPersisted"/>, using <see cref="TNullableType"/>.
    /// The offset will be baked into the value (normalized to UTC).
    /// </summary>
    /// <typeparam name="TPersisted"></typeparam>
    /// <typeparam name="TNullableType"></typeparam>
    public abstract class AbstractDateTimeOffsetType<TPersisted,TNullableType> : VersionedAbstractStructType<DateTimeOffset, TPersisted, TNullableType>
        where TNullableType : NullableType, IVersionType, new()
    {

    }
}
