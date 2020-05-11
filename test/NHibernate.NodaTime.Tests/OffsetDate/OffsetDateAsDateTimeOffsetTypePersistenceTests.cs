using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class OffsetDateAsDateTimeOffsetTypePersistenceTests : AbstractOffsetDatePersistenceTests<OffsetDateAsDateTimeOffsetType>
    {
        public OffsetDateAsDateTimeOffsetTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        
    }
}
