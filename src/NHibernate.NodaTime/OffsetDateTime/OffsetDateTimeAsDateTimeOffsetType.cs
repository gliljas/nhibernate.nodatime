using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetDateTime"/> as a <see cref="DateTimeOffset"/>, using <see cref="EnhancedDateTimeOffsetType"/>
    /// </summary>
    public class OffsetDateTimeAsDateTimeOffsetType : AbstractOffsetDateTimeType<DateTimeOffset, EnhancedDateTimeOffsetType>
    {
        protected override OffsetDateTime Unwrap(DateTimeOffset value) => OffsetDateTime.FromDateTimeOffset(value);

        protected override DateTimeOffset Wrap(OffsetDateTime value) => value.ToDateTimeOffset();

        //public override Expression<Func<OffsetDateTime, DateTimeOffset>>[] ExpressionsExposingPersisted => new Expression<Func<OffsetDateTime, DateTimeOffset>>[] {
        //    x => x.ToDateTimeOffset()
        //};

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers => new[] {
            SupportedQueryMember.ForMethod<OffsetDateTime,Instant>(x=>x.ToInstant(),new LoadAsTransformer(new CustomType<InstantAsDateTimeOffsetType>())),
            SupportedQueryMember.ForMethod<OffsetDateTime,OffsetDate>(x=>x.ToOffsetDate(),new RemoveTimeFromDateTimeOffsetTransformer() > new LoadAsTransformer(new CustomType<OffsetDateAsDateTimeOffsetType>())),
            SupportedQueryMember.ForMethod<OffsetDateTime,OffsetTime>(x=>x.ToOffsetTime(),new RemoveDateFromDateTimeOffsetTransformer() > new LoadAsTransformer(new CustomType<OffsetTimeAsDateTimeOffsetType>())),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.NanosecondOfSecond,new FunctionTransformer("nanosecond")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Millisecond,new FunctionTransformer("millisecond")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Second,new FunctionTransformer("second")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Minute,new FunctionTransformer("minute")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Hour,new FunctionTransformer("hour")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Day,new FunctionTransformer("day")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Month,new FunctionTransformer("month")),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.Year,new FunctionTransformer("year")),
            SupportedQueryMember.ForProperty<OffsetDateTime,LocalDateTime>(x=>x.LocalDateTime,new LoadAsTransformer(new CustomType<LocalDateTimeAsDateTimeType>())),
            SupportedQueryMember.ForProperty<OffsetDateTime,long>(x=>x.TickOfDay, 
                (new FunctionTransformer("hour") * NodaConstants.TicksPerHour) +
                (new FunctionTransformer("minute") * NodaConstants.TicksPerMinute) +
                (new FunctionTransformer("second") * NodaConstants.TicksPerSecond) +
                (new FunctionTransformer("nanosecond") / NodaConstants.NanosecondsPerTick)
                ),
            SupportedQueryMember.ForProperty<OffsetDateTime,int>(x=>x.TickOfSecond, new FunctionTransformer("nanosecond") / NodaConstants.NanosecondsPerTick),
            SupportedQueryMember.ForProperty<OffsetDateTime,LocalTime>(x=>x.TimeOfDay, new FunctionTransformer("nodatimefromdatetimeoffset") > new LoadAsTransformer(new CustomType<LocalTimeAsTimeType>()))
         };
    }
}