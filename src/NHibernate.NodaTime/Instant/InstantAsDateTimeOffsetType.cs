using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Instant"/> as a <see cref="DateTimeOffset"/>, using <see cref="DateTimeOffsetType"/>
    /// </summary>
    public class InstantAsDateTimeOffsetType : AbstractInstantType<DateTimeOffset, DateTimeOffsetType>
    {
        protected override Instant Unwrap(DateTimeOffset value) => Instant.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(Instant value) => value.ToDateTimeOffset();

        public override Expression<Func<Instant, DateTimeOffset>>[] ExpressionsExposingPersisted => new Expression<Func<Instant, DateTimeOffset>>[]
        {
            x => x.ToDateTimeOffset()
        };
    }
}
