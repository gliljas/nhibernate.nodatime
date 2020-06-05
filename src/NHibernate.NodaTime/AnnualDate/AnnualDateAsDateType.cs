using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists an <see cref="AnnualDate"/> as a <see cref="DateTime"/>, using <see cref="DateType"/>
    /// </summary>
    public class AnnualDateAsDateType : AbstractAnnualDateType<DateTime, DateType>
    {
        private int _baseYear = 1970;

        protected override AnnualDate Unwrap(DateTime value) => new AnnualDate(value.Month, value.Day);

        protected override DateTime Wrap(AnnualDate value) => value.InYear(_baseYear).ToDateTimeUnspecified();

        protected override AnnualDate Cast(object value)
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
                if (parameters.TryGetValue("BaseYear", out var baseYearString))
                {
                    if (!int.TryParse(baseYearString, out int baseYear))
                    {
                        throw new ArgumentException("Invalid BaseYear");
                    }
                    _baseYear = baseYear;
                }
                base.SetParameterValues(parameters);
            }
        }

        public override IEnumerable<ISupportedQueryMember> SupportedQueryMembers => new[] {
            SupportedQueryMember.ForProperty<AnnualDate,int>(x=>x.Month, new FunctionTransformer("month")),
            SupportedQueryMember.ForProperty<AnnualDate,int>(x=>x.Day, new FunctionTransformer("day")),
        };

        //public override IEnumerable<ISupportedQueryMember> SupportedQueryMethods => new[] {
        //    //SupportedQueryMethod.For<AnnualDate,LocalDate>(x=>x.InYear(0)), new Da("month")),
        //    //SupportedQueryMember.ForProperty<AnnualDate,int>(x=>x.Day, new FunctionTransformer("day")),
        //};
    }
}