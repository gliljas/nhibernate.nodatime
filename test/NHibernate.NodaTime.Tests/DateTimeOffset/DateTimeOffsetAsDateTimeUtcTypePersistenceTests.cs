using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class DateTimeOffsetAsDateTimeUtcTypePersistenceTests : AbstractPersistenceTests<DateTimeOffset, DateTimeOffsetAsDateTimeUtcType>
    {
        public DateTimeOffsetAsDateTimeUtcTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        protected override DateTimeOffset AdjustValue(DateTimeOffset value) => value.ToUniversalTime();
    }

   
}
