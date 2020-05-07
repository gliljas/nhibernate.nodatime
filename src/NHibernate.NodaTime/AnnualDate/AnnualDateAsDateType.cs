using NHibernate.NodaTime.Linq;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;

namespace NHibernate.NodaTime
{
    public class AnnualDateAsDateType : AbstractStructType<AnnualDate, DateTime, DateType>
    {
        int _baseYear = 1970;
        protected override AnnualDate Unwrap(DateTime value) => new AnnualDate(value.Month, value.Day);
        protected override DateTime Wrap(AnnualDate value) => value.InYear(_baseYear).ToDateTimeUnspecified();

        public override void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                if (parameters.TryGetValue("BaseYear", out var baseYearString) && int.TryParse(baseYearString, out int baseYear))
                {
                    _baseYear = baseYear;
                }
                base.SetParameterValues(parameters);
            }
        }

        public override IEnumerable<SupportedQueryProperty<AnnualDate>> SupportedQueryProperties => new[] { 
            new SupportedQueryProperty<AnnualDate>(x=>x.Month, new FunctionTransformer("month")),
            new SupportedQueryProperty<AnnualDate>(x=>x.Day, new FunctionTransformer("day")),
        };


    }


}
