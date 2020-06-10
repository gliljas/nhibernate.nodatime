using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
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

        //public override Expression<Func<Offset, TimeSpan>>[] ExpressionsExposingPersisted => new Expression<Func<Offset, TimeSpan>>[] {
        //    x => x.ToTimeSpan()
        //};

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers => new[] {
            SupportedQueryMember.ForProperty<Offset,int>(x=>x.Seconds,new DivisionTransformer(NodaConstants.TicksPerSecond) > new CastTransformer(typeof(int))),
            SupportedQueryMember.ForProperty<Offset,long>(x=>x.Ticks,new CastTransformer(typeof(long))),
            SupportedQueryMember.ForMethod<Offset,TimeSpan>(x=>x.ToTimeSpan(),new LoadAsTransformer(NHibernateUtil.TimeSpan))
         };
    }
}