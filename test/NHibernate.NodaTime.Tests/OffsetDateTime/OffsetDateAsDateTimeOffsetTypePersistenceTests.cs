using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetDateTimeAsDateTimeOffsetTypePersistenceTests : AbstractOffsetDateTimePersistenceTests<OffsetDateTimeAsDateTimeOffsetType>
    {
        public OffsetDateTimeAsDateTimeOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        
    }
}
