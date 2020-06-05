using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetDate"/> as a <see cref="DateTimeOffset"/>, using <see cref="EnhancedDateTimeOffsetType"/>
    /// </summary>
    public class OffsetDateAsDateTimeOffsetType : AbstractOffsetDateType<DateTimeOffset, EnhancedDateTimeOffsetType>
    {
        protected override OffsetDate Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value).ToOffsetDate();

        protected override DateTimeOffset Wrap(OffsetDate value) => value.At(LocalTime.MinValue).ToDateTimeOffset();

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers => new[] {
            SupportedQueryMember.ForProperty<OffsetDate,int>(x=>x.Day,new FunctionTransformer("day")),
            SupportedQueryMember.ForProperty<OffsetDate,int>(x=>x.Month,new FunctionTransformer("month")),
            SupportedQueryMember.ForProperty<OffsetDate,int>(x=>x.Year,new FunctionTransformer("year")),
            //SupportedQueryMember.ForProperty<OffsetDateTime,LocalDateTime>(x=>x.LocalDateTime,new LoadAsTransformer(new CustomType<LocalDateTimeAsDateTimeType>())),
            //SupportedQueryMember.ForProperty<OffsetDateTime,long>(x=>x.TickOfDay,
            //    (new FunctionTransformer("hour") * NodaConstants.TicksPerHour) +
            //    (new FunctionTransformer("minute") * NodaConstants.TicksPerMinute) +
            //    (new FunctionTransformer("second") * NodaConstants.TicksPerSecond) +
            //    (new FunctionTransformer("nanosecond") / NodaConstants.NanosecondsPerTick)
            //    ),
            //SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.TickOfSecond, new FunctionTransformer("nanosecond") / NodaConstants.NanosecondsPerTick),
            //SupportedQueryMember.ForProperty<OffsetDateTime,LocalTime>(x=>x.TimeOfDay, new FunctionTransformer("nodatimefromdatetimeoffset") > new LoadAsTransformer(new CustomType<LocalTimeAsTimeType>()))
         };

        //public override Expression<Func<OffsetDate, DateTimeOffset>>[] ExpressionsExposingPersisted => new Expression<Func<OffsetDate, DateTimeOffset>>[] { 
        //    x=>x.ToDateTimeOffset()
        //};

    }
}