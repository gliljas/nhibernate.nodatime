using NHibernate.UserTypes;
using NodaTime;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="DateInterval"/> as two <see cref="LocalDate"/>s, using <see cref="TLocalDateType"/>
    /// </summary>
    /// <typeparam name="TLocalDateType"></typeparam>
    public abstract class AbstractDateIntervalAsLocalDatesType<TLocalDateType> : AbstractTwoPropertyStructType<DateInterval, LocalDate, LocalDate, CustomType<TLocalDateType>, CustomType<TLocalDateType>>
        where TLocalDateType : IUserType
    {
        protected override string Property1Name => nameof(DateInterval.Start);
        protected override string Property2Name => nameof(DateInterval.End);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

        protected override DateInterval Unwrap(LocalDate property1Value, LocalDate property2Value) => new DateInterval(property1Value, property2Value);

        protected override LocalDate GetProperty1Value(DateInterval value) => value.Start;

        protected override LocalDate GetProperty2Value(DateInterval value) => value.End;

        protected override DateInterval Cast(object value)
        {
            if (value is DateIntervalWrapper wrapper)
            {
                return (DateInterval)wrapper;
            }
            return base.Cast(value);
        }
    }
}
