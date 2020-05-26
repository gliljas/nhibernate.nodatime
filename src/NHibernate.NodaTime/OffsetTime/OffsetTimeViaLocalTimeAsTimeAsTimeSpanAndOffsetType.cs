using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="OffsetTime"/> using two columns.
    /// One for the time, stored as a <see cref="LocalTime"/>, using <see cref="LocalTimeAsTimeAsTimeSpanType"/>.
    /// One for the offset, stored as seconds, using <see cref="OffsetAsInt32SecondsType"/>
    /// </summary>
    public class OffsetTimeViaLocalTimeAsTimeAsTimeSpanAndOffsetType : AbstractTwoPropertyStructType<OffsetTime, LocalTime, Offset, CustomType<LocalTimeAsTimeAsTimeSpanType>, CustomType<OffsetAsInt32SecondsType>>
    {
        protected override string Property1Name => nameof(OffsetTime.TimeOfDay);
        protected override string Property2Name => nameof(OffsetTime.Offset);

        protected override LocalTime GetProperty1Value(OffsetTime value) => value.TimeOfDay;

        protected override Offset GetProperty2Value(OffsetTime value) => value.Offset;

        protected override OffsetTime Unwrap(LocalTime property1Value, Offset property2Value) => new OffsetTime(property1Value, property2Value);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

    }
}
