using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public abstract class DurationAsTimeSpanType<TNullableType> : AbstractDurationType<TimeSpan, TimeSpanType>
        where TNullableType : NullableType, new()
    {
        protected override Duration Unwrap(TimeSpan value) => Duration.FromTimeSpan(value);

        protected override TimeSpan Wrap(Duration value) => value.ToTimeSpan();

        //public override Expression<Func<Duration, TimeSpan>>[] ExpressionsExposingPersisted => new Expression<Func<Duration, TimeSpan>>[]
        //{
        //    x => x.ToTimeSpan()
        //};
    }
}