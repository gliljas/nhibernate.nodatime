using AutoFixture.Kernel;
using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class DateIntervalSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(DateInterval).Equals(request))
            {
                return new NoSpecimen();
            }

            var localDateBuilder = new LocalDateSpecimenBuilder();
            var periodBuilder = new PeriodSpecimenBuilder();

            var localDate = (LocalDate)localDateBuilder.Create(typeof(LocalDate), context);
            var period = (Period)periodBuilder.Create(typeof(Period), context);

            return new DateInterval(localDate, localDate.PlusDays(period.Days));
        }
    }
}
