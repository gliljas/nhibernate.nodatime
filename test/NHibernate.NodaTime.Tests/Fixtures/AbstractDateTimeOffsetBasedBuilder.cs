using AutoFixture;
using AutoFixture.Kernel;
using System;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public abstract class AbstractDateTimeOffsetBasedBuilder<T> : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof(T).Equals(request))
            {
                return new NoSpecimen();
            }

            var dateTime = context.Create<DateTimeOffset>();
            return CreateFromDateTime(dateTime);
        }

        public abstract T CreateFromDateTime(DateTimeOffset dateTimeOffset);

    }
}
