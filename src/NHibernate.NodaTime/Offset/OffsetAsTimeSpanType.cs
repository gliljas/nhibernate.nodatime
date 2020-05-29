using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persist an <see cref="Offset"/> as its corresponding number of seconds, using <see cref="Int32Type"/>
    /// </summary>
    public class OffsetAsTimeSpanType : AbstractOffsetType<TimeSpan, TimeSpanType>
    {
        protected override Offset Unwrap(TimeSpan value) => Offset.FromTimeSpan(value);

        protected override TimeSpan Wrap(Offset value) => value.ToTimeSpan();

        public override Expression<Func<Offset, TimeSpan>>[] ExpressionsExposingPersisted => new Expression<Func<Offset, TimeSpan>>[] {
            x => x.ToTimeSpan()
        };
    }

}
