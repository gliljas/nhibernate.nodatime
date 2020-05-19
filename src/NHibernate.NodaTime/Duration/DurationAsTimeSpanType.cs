using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class DurationAsTimeSpanType<TNullableType> : AbstractDurationType<TimeSpan, TimeSpanType>
        where TNullableType : NullableType, new()
    {
        protected override Duration Unwrap(TimeSpan value) => Duration.FromTimeSpan(value);

        protected override TimeSpan Wrap(Duration value) => value.ToTimeSpan();
    }

}
