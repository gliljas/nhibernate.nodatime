using NHibernate.NodaTime.Tests.Fixtures;
using System;

namespace NHibernate.NodaTime.Tests
{
    public class DateTimeOffsetAsDateTimeUtcTypePersistenceTests : AbstractPersistenceTests<DateTimeOffset, DateTimeOffsetAsUtcDateTimeType>
    {
        public DateTimeOffsetAsDateTimeUtcTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        protected override DateTimeOffset AdjustValue(DateTimeOffset value) => new DateTimeOffset(value.DateTime.Year,value.DateTime.Month,value.DateTime.Day,value.DateTime.Hour,value.DateTime.Minute,value.DateTime.Second,value.DateTime.Millisecond,value.Offset);
    }

   
}
