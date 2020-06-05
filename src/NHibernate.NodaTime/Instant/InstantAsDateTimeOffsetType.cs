using NHibernate.NodaTime.Extensions;
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTimeOffset"/>, using <see cref="EnhancedDateTimeOffsetType"/>
    /// </summary>
    public class InstantAsDateTimeOffsetType : AbstractInstantType<DateTimeOffset, EnhancedDateTimeOffsetType>
    {
        protected override Instant Unwrap(DateTimeOffset value) => Instant.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(Instant value) => value.ToDateTimeOffset();

        public override Expression<Func<Instant, DateTimeOffset>>[] ExpressionsExposingPersisted => new Expression<Func<Instant, DateTimeOffset>>[]
        {
            x => x.ToDateTimeOffset()
        };

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers
        {
            get
            {
                // yield return new SupportedQueryMethod<Instant>(x => x.Plus(default), new PlusDurationTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, DateTimeOffset>(x => x.ToDateTimeOffset(), new ToDateTimeOffsetTransformer());
                yield return SupportedQueryMember.ForMethod<Instant,DateTime>(x => x.ToDateTimeUtc(), new ToDateTimeUtcTransformer());
                //yield return SupportedQueryMethod.For<Instant, double>(x => x.ToJulianDate(), new ToDateTimeUtcTransformer());
                yield return SupportedQueryMember.ForMethod<Instant, long>(x => x.ToUnixTimeMilliseconds(), new ToUnixTimeMillisecondsTransformer());
                //yield return SupportedQueryMethod.For<Instant, OffsetDateTime>(x => x.WithOffset(default), new DateTimeOffset);
                //yield return SupportedQueryMethod.For<Instant, OffsetDateTime>(x => x.WithOffsetSeconds(default), new GenericConversionTransformer<CustomType<OffsetDateAsDateTimeOffsetType>>());

            }
        }
    }
}