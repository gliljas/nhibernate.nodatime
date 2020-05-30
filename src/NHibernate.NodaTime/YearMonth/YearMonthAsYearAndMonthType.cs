using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="YearMonth"/> as two <see cref="Int16Type"/> columns
    /// </summary>
    public class YearMonthAsYearAndMonthType : AbstractTwoPropertyStructType<YearMonth, short, short, Int16Type, Int16Type>
    {
        protected override string Property1Name => nameof(YearMonth.Year);

        protected override string Property2Name => nameof(YearMonth.Month);

        protected override short GetProperty1Value(YearMonth value) => (short)value.Year;

        protected override short GetProperty2Value(YearMonth value) => (short)value.Month;

        protected override YearMonth Unwrap(short property1Value, short property2Value) => new YearMonth(property1Value, property2Value);

        protected override YearMonth Cast(object value)
        {
            if (value is DateTime dateTime)
            {
                return Unwrap((short)dateTime.Year, (short)dateTime.Month);
            }
            if (value is DateTimeOffset dateTimeOffset)
            {
                return Unwrap((short)dateTimeOffset.Year, (short)dateTimeOffset.Month);
            }
            return base.Cast(value);
        }
    }
}