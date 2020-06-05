using NHibernate.NodaTime.Tests.Fixtures;
using NHibernate.Type;
using NodaTime;
using System;

namespace NHibernate.NodaTime.Tests
{
    public class InstantAsUtcDateTimeNoMsTypePersistenceTests : AbstractInstantPersistenceTests<InstantAsUtcDateTimeNoMsType>
    {
        public InstantAsUtcDateTimeNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        protected override Instant AdjustValue(Instant value)
        {
            var dateTime = value.ToDateTimeUtc();
            return Instant.FromDateTimeUtc(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second,DateTimeKind.Utc));
        }
    }
}