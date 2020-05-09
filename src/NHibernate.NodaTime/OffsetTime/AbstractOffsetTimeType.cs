using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractOffsetTimeType<TPersisted, TNullableType> : AbstractStructType<OffsetTime, TPersisted, TNullableType>
         where TNullableType : NullableType, new()
    {
        protected override OffsetTime Cast(object value)
        {
            if (value is OffsetTime offsetTime)
            {
                return offsetTime;
            }
            if (value is DateTimeOffset dateTimeOffset)
            {
                return OffsetDateTime.FromDateTimeOffset(dateTimeOffset).ToOffsetTime();
            }
            return base.Cast(value);
        }
    }
}
