﻿using NHibernate.NodaTime.Linq;
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
    public class OffsetAsInt32SecondsType : AbstractOffsetType<int, Int32Type>
    {
        protected override Offset Unwrap(int value) => Offset.FromSeconds(value);

        protected override int Wrap(Offset value) => value.Seconds;

        //public override Expression<Func<Offset, int>>[] ExpressionsExposingPersisted => new Expression<Func<Offset, int>>[] {
        //    x => x.Seconds
        //};

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers => new[] {
            SupportedQueryMember.ForProperty<Offset,long>(x=>x.Ticks,new MultiplicationTransformer(NodaConstants.TicksPerSecond)),
            SupportedQueryMember.ForMethod<Offset,TimeSpan>(x=>x.ToTimeSpan(),new MultiplicationTransformer(NodaConstants.TicksPerSecond) > new LoadAsTransformer(NHibernateUtil.TimeSpan))
         };
    }

}