using AutoFixture;
using AutoFixture.Kernel;
using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class DurationSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(Duration).Equals(request))
            {
                return new NoSpecimen();
            }

            return Duration.FromHours(context.Create<int>()).Plus(Duration.FromSeconds(context.Create<long>()));//.Plus(Duration.FromTimeSpan(context.Create<TimeSpan>()));
        }


    }
}