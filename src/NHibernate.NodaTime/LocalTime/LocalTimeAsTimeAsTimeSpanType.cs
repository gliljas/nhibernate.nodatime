﻿using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class LocalTimeAsTimeAsTimeSpanType : AbstractLocalTimeType<TimeSpan, TimeAsTimeSpanType>
    {
        protected override LocalTime Unwrap(TimeSpan value) => LocalTime.FromTicksSinceMidnight(value.Ticks);

        protected override TimeSpan Wrap(LocalTime value) => TimeSpan.FromTicks(value.TickOfDay);

    }
}
