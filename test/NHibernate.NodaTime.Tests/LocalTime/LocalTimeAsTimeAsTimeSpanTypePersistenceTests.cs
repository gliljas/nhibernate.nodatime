﻿using NHibernate.NodaTime.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Tests
{
    public class LocalTimeAsTimeAsTimeSpanTypePersistenceTests : AbstractLocalTimePersistenceTests<LocalTimeAsTimeAsTimeSpanType>
    {
        public LocalTimeAsTimeAsTimeSpanTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

    }
}
