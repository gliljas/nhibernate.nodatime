using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    public abstract class AbstractDateIntervalAsLocalDatesType<TLocalDateType> : AbstractTwoPropertyStructType<DateInterval, LocalDate, LocalDate>
    {
        protected override string Property1Name => "Start";
        protected override string Property2Name => "End";

        protected override IType Property1Type => new CustomType(typeof(TLocalDateType), null);
        protected override IType Property2Type => new CustomType(typeof(TLocalDateType), null);

        protected override int Property1ColumnSpan => 1;
        protected override int Property2ColumnSpan => 1;

        protected override DateInterval Unwrap(LocalDate property1Value, LocalDate property2Value) => new DateInterval(property1Value, property2Value);

        protected override LocalDate GetProperty1Value(DateInterval value) => value.Start;

        protected override LocalDate GetProperty2Value(DateInterval value) => value.End;
    }
}
