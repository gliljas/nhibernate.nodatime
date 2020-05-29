using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public class DurationAsInt64NanosecondsType : AbstractDurationType<long, Int64Type>
    {
        protected override Duration Unwrap(long value) => Duration.FromNanoseconds(value);

        protected override long Wrap(Duration value) => value.ToInt64Nanoseconds();

        public override Expression<Func<Duration, long>>[] ExpressionsExposingPersisted => new Expression<Func<Duration, long>>[]
        {
            x => x.ToInt64Nanoseconds()
        };

    }

    public class DurationAsTicksType : AbstractDurationType<long, Int64Type>
    {
        protected override Duration Unwrap(long value) => Duration.FromTicks(value);

        protected override long Wrap(Duration value) => value.BclCompatibleTicks;

        public override Expression<Func<Duration, long>>[] ExpressionsExposingPersisted => new Expression<Func<Duration, long>>[]
        {
            x => (long)x.BclCompatibleTicks
        };

    }

}
