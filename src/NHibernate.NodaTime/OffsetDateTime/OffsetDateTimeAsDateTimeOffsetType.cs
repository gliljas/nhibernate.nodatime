using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetDateTime"/> as a <see cref="DateTimeOffset"/>, using <see cref="DateTimeOffsetType"/>
    /// </summary>
    public class OffsetDateTimeAsDateTimeOffsetType : AbstractOffsetDateTimeType<DateTimeOffset, DateTimeOffsetType>
    {
        protected override OffsetDateTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(OffsetDateTime value) => value.ToDateTimeOffset();

        public override Expression<Func<OffsetDateTime, DateTimeOffset>>[] ExpressionsExposingPersisted => new Expression<Func<OffsetDateTime, DateTimeOffset>>[] {
            x => x.ToDateTimeOffset()
        };
    }
}