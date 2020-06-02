using NHibernate.NodaTime.Tests.Fixtures;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.NodaTime.Tests
{
    public class TzdbDateTimeZoneTypePersistenceTests : AbstractDateTimeZoneTypePersistenceTests<TzdbDateTimeZoneType>
    {
        public TzdbDateTimeZoneTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }
    }
}