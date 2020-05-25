using NHibernate.SqlTypes;
using NHibernate.Type;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalTime"/> as a <see cref="DateTime"/>, using <see cref="TimeType"/>
    /// </summary>
    public class LocalTimeAsTimeType : AbstractLocalTimeType<DateTime, TimeType>
    {
        protected override LocalTime Unwrap(DateTime value) => LocalDateTime.FromDateTime(value).TimeOfDay;

        protected override DateTime Wrap(LocalTime value) => DateTime.Now;

    }
}
