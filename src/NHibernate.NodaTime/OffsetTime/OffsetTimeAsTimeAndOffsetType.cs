using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetTimeAsTimeAndOffsetType : AbstractTwoPropertyStructType<OffsetTime, TimeSpan, Offset>
    {
        protected override IType Property1Type => NHibernateUtil.TimeAsTimeSpan;
        protected override IType Property2Type => new CustomType(typeof(OffsetAsInt32SecondsType), null);

        protected override string Property1Name => "Time";
        protected override string Property2Name => "Offset";

        protected override TimeSpan GetProperty1Value(OffsetTime value) => TimeSpan.FromTicks(value.TimeOfDay.TickOfDay);

        protected override Offset GetProperty2Value(OffsetTime value) => value.Offset;

        protected override OffsetTime Unwrap(TimeSpan property1Value, Offset property2Value) => new OffsetTime(LocalTime.FromTicksSinceMidnight(property1Value.Ticks), property2Value);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

    }
}
