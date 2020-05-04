using NHibernate.NodaTime.Tests.Fixtures;
using System;

namespace NHibernate.NodaTime.Tests
{
    public class DateTimeOffsetAsDateTimeUtcNoMsTypePersistenceTests : AbstractPersistenceTests<DateTimeOffset, DateTimeOffsetAsDateTimeUtcNoMsType>
    {
        public DateTimeOffsetAsDateTimeUtcNoMsTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
