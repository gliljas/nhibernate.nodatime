using AutoFixture.Kernel;
using NodaTime;
using NodaTime.Extensions;
using System;
using System.Linq;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class DateTimeZoneSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(DateTimeZone).Equals(request))
            {
                return new NoSpecimen();
            }
            var zones = DateTimeZoneProviders.Tzdb.GetAllZones().ToArray();

            return zones[new Random().Next(0, zones.Length - 1)];
        }
    }
}