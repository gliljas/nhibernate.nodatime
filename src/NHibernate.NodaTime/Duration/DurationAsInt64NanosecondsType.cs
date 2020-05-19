using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public abstract class DurationAsInt64NanosecondsType<TNullableType> : AbstractDurationType<long, Int64Type>
        where TNullableType : NullableType, new()
    {
        protected override Duration Unwrap(long value) => Duration.FromNanoseconds(value);

        protected override long Wrap(Duration value) => value.ToInt64Nanoseconds();

    }

}
