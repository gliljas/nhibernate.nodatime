using NHibernate.Type;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateTimeOffsetAsDateTimeType<TDateTimeType> : AbstractDateTimeOffsetType<DateTime, TDateTimeType>
        where TDateTimeType : AbstractDateTimeType, IVersionType, new()
    {
        protected override DateTimeOffset Unwrap(DateTime value) => DateTime.SpecifyKind(value, DateTimeKind.Utc);
        protected override DateTime Wrap(DateTimeOffset value) => value.UtcDateTime;

        public override Expression<Func<DateTimeOffset, DateTime>>[] ExpressionsExposingPersisted => new Expression<Func<DateTimeOffset, DateTime>>[]
        {
            x => x.UtcDateTime
        };
    }
}
