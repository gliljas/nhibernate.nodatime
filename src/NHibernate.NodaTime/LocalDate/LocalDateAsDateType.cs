using NHibernate.Type;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime
{
    /// <summary>
    /// Persists a <see cref="LocalDate"/> as a <see cref="DateTime"/>, using <see cref="DateType"/>
    /// </summary>
    public class LocalDateAsDateType : AbstractStructType<LocalDate, DateTime, DateType>
    {
        protected override LocalDate Unwrap(DateTime value) => LocalDate.FromDateTime(value);

        protected override DateTime Wrap(LocalDate value) => value.ToDateTimeUnspecified();

        public override Expression<Func<LocalDate, DateTime>>[] ExpressionsExposingPersisted => new Expression<Func<LocalDate, DateTime>>[]
        {
            x => x.ToDateTimeUnspecified()
        };
    }
}
