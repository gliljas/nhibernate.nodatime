using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDurationType<TPersisted, TNullableType> : AbstractStructType<Duration, TPersisted, TNullableType>
        where TNullableType : NullableType, new()
    {
        protected override Duration Cast(object value)
        {
            if (value is TimeSpan timeSpan)
            {
                return Duration.FromTimeSpan(timeSpan);
            }
            if (value is long nanoSeconds)
            {
                return Duration.FromNanoseconds(nanoSeconds);
            }
            return base.Cast(value);
        }
    }
}