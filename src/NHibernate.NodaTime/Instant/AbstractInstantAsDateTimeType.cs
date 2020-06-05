using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
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

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers
        {
            get
            {
                // yield return new SupportedQueryMethod<Instant>(x => x.Plus(default), new PlusDurationTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, DateTimeOffset>(x => x.ToDateTimeOffset(), new ToDateTimeOffsetTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, DateTime>(x => x.ToDateTimeUtc(), new ToDateTimeUtcTransformer());
                //yield return SupportedQueryMethod.For<Instant, double>(x => x.ToJulianDate(), new ToDateTimeUtcTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, long>(x => x.ToUnixTimeMilliseconds(), new ToUnixTimeMillisecondsTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, OffsetDateTime>(x => x.WithOffset(default), new WithOffsetGenerator());
                yield return SupportedQueryMember.ForMethod<Instant, ZonedDateTime>(x => x.InUtc(), new InUtcGenerator());
                //yield return SupportedQueryMethod.For<Instant, OffsetDateTime>(x => x.WithOffsetSeconds(default), new GenericConversionTransformer<CustomType<OffsetDateAsDateTimeOffsetType>>());

            }
        }
    }
}