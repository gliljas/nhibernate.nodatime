using NHibernate.NodaTime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractPersistenceTests : IClassFixture<NHibernateFixture>
    {
        private readonly NHibernateFixture _nhibernateFixture;

        protected AbstractPersistenceTests(NHibernateFixture nhibernateFixture)
        {
            _nhibernateFixture = nhibernateFixture;
        }

    }
}
