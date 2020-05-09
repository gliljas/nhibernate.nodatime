using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeOffsetType<TPersisted,TNullableType> : VersionedAbstractStructType<DateTimeOffset, TPersisted, TNullableType>
        where TNullableType : NullableType, IVersionType, new()
    {

    }
}
