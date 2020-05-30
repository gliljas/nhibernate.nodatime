using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractOffsetDateTimeType<TPersisted, TNullableType> : VersionedAbstractStructType<OffsetDateTime, TPersisted, TNullableType>
        where TNullableType : NullableType, IVersionType, new()

    {
        protected override OffsetDateTime Cast(object value)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                return OffsetDateTime.FromDateTimeOffset(dateTimeOffset);
            }
            if (value is DateTime dateTime)
            {
                return LocalDateTime.FromDateTime(dateTime).WithOffset(Offset.Zero);
            }
            return base.Cast(value);
        }
    }
}