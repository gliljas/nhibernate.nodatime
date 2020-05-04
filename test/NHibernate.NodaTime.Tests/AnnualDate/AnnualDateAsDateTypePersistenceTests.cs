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
    public class AnnualDateAsDateTypePersistenceTests : AbstractPersistenceTests<AnnualDate, AnnualDateAsDateType>
    {
        public AnnualDateAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }
    }
}
