using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="Interval"/> as two <see cref="Instant"/>s, using <see cref="{TInstantType}"/>
    /// </summary>
    public abstract class AbstractIntervalAsInstantsType<TInstantType> : AbstractTwoPropertyStructType<Interval, Instant?, Instant?, CustomType<TInstantType>, CustomType<TInstantType>>
    where TInstantType : IUserType
    {
        protected override string Property1Name => nameof(Interval.Start);
        protected override string Property2Name => nameof(Interval.End);

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
