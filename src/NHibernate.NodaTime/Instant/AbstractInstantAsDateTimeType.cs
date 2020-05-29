using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    public abstract class AbstractInstantAsDateTimeType<DateTimeType> : AbstractInstantType<DateTime, DateTimeType>
        where DateTimeType : AbstractDateTimeType, IVersionType, new()
    {
        protected override Instant Unwrap(DateTime value) => Instant.FromDateTimeUtc(DateTime.SpecifyKind(value, DateTimeKind.Utc));

        protected override DateTime Wrap(Instant value) => value.ToDateTimeUtc();

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

        public override Expression<Func<Instant, DateTime>>[] ExpressionsExposingPersisted => new Expression<Func<Instant, DateTime>>[]
        {
            x => x.ToDateTimeUtc()
        };
    }

}
