using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="YearMonth"/> as a <see cref="DateTime"/>, using <see cref="DateType"/>
    /// </summary>
    public class YearMonthAsDateType : AbstractYearMonthType<DateTime, DateType>
    {
        int _dayOfMonth = 1;

        protected override YearMonth Unwrap(DateTime value) => new YearMonth(value.Year, value.Month);
        protected override DateTime Wrap(YearMonth value)
        {
            if (_dayOfMonth > 28)
            {
                var lastDay = value.ToDateInterval().End.Day;
                if (lastDay < _dayOfMonth)
                {
                    return value.OnDayOfMonth(lastDay).ToDateTimeUnspecified();
                }
            }
            return value.OnDayOfMonth(_dayOfMonth).ToDateTimeUnspecified();
        }

        protected override YearMonth Cast(object value)
        {
            if (value is DateTime dateTime)
            {
                return Unwrap(dateTime);
            }
            if (value is DateTimeOffset dateTimeOffset)
            {
                return Unwrap(dateTimeOffset.UtcDateTime);
            }
            return base.Cast(value);
        }

        public override void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                if (parameters.TryGetValue("DayOfMonth", out var dayOfMonthString))
                {
                    if (!int.TryParse(dayOfMonthString, out int dayOfMonth) || dayOfMonth < 1 || dayOfMonth > 31)
                    {
                        throw new ArgumentOutOfRangeException("Invalid DayOfMonth parameter. Must be between 1 and 31.");
                    }
                    _dayOfMonth = dayOfMonth;
                }
                base.SetParameterValues(parameters);
            }
        }


    }


}
