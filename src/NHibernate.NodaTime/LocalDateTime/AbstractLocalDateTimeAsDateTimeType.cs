using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public abstract class AbstractLocalDateTimeAsDateTimeType<TDateTimeType> : AbstractStructType<LocalDateTime, DateTime, TDateTimeType>
        where TDateTimeType : NullableType, new()
    {
        protected override LocalDateTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value);

        protected override DateTime Wrap(LocalDateTime value) => value.ToDateTimeUnspecified();

        public override Expression<Func<LocalDateTime, DateTime>>[] ExpressionsExposingPersisted => new Expression<Func<LocalDateTime, DateTime>>[]
        {
            x => x.ToDateTimeUnspecified()
        };
    }
}