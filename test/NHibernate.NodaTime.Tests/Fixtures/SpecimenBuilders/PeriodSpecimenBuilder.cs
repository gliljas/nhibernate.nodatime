using AutoFixture;
using AutoFixture.Kernel;
using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class PeriodSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(Period).Equals(request))
            {
                return new NoSpecimen();
            }

            return Period.FromSeconds(context.Create<long>());
        }
    }
}