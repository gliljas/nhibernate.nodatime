﻿using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class OffsetTimeAsTimeAsTimeSpanAndOffsetType : AbstractTwoPropertyStructType<OffsetTime, TimeSpan, Offset, TimeAsTimeSpanType, CustomType<OffsetAsInt32SecondsType>>
    {
        protected override string Property1Name => "TimeSpan";
        protected override string Property2Name => "Offset";

        protected override TimeSpan GetProperty1Value(OffsetTime value) => TimeSpan.FromTicks(value.TimeOfDay.TickOfDay);

        protected override Offset GetProperty2Value(OffsetTime value) => value.Offset;

        protected override OffsetTime Unwrap(TimeSpan property1Value, Offset property2Value) => new OffsetTime(LocalTime.FromTicksSinceMidnight(property1Value.Ticks), property2Value);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

    }
}