﻿using NHibernate.Type;
using NodaTime;

namespace NHibernate.NodaTime
{
    public abstract class AbstractIntervalAsInstantsType<TInstantType> : AbstractTwoPropertyStructType<Interval, Instant?, Instant?>
    {
        protected override string Property1Name => "Start";
        protected override string Property2Name => "End";

        protected override IType Property1Type => new CustomType(typeof(TInstantType), null);
        protected override IType Property2Type => new CustomType(typeof(TInstantType), null);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

        protected override Interval Unwrap(Instant? property1Value, Instant? property2Value)
        {
            return new Interval(property1Value, property2Value);
        }

        protected override Instant? GetProperty1Value(Interval value) => value.HasStart ? value.Start : (Instant?)null;

        protected override Instant? GetProperty2Value(Interval value) => value.HasEnd ? value.End : (Instant?)null;
    }
}