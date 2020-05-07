using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime
{
    public class AnnualDateAsDateType : AbstractStructType<AnnualDate, DateTime, DateType>
    {
        protected override AnnualDate Unwrap(DateTime value) => new AnnualDate(value.Month, value.Day);
        protected override DateTime Wrap(AnnualDate value) => value.InYear(2000).ToDateTimeUnspecified();
    }
}
