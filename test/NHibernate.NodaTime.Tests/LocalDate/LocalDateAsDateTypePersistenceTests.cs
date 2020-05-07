using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class LocalDateAsDateTypePersistenceTests : AbstractLocalDatePersistenceTests<LocalDateAsDateType>
    {
        public LocalDateAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
