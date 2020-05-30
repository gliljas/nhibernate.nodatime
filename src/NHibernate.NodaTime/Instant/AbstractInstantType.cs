using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractInstantType<TPersisted, TNullableType> : VersionedAbstractStructType<Instant, TPersisted, TNullableType>
        where TNullableType : NullableType, IVersionType, new()
    {
        protected override Instant Cast(object value)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                return Instant.FromDateTimeOffset(dateTimeOffset);
            }
            if (value is DateTime dateTime)
            {
                return Instant.FromDateTimeUtc(dateTime);
            }
            return base.Cast(value);
        }
    }
}