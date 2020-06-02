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

        public override IEnumerable<ISupportedQueryMethod<Instant>> SupportedQueryMethods { get {
               // yield return new SupportedQueryMethod<Instant>(x => x.Plus(default), new PlusDurationTransformer());
                yield return new SupportedQueryMethod<Instant>(x => x.ToDateTimeOffset(), new ToDateTimeOffsetTransformer());

            }
        }
    }
}