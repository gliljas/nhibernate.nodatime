using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using System.Linq.Expressions;

namespace NHibernate.NodaTime.Tests
{
    public class DateIntervalAsDateTimesTypePersistenceTests : AbstractDateIntervalPersistenceTests<DateIntervalAsDateTimesType>
    {
        public DateIntervalAsDateTimesTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
           
        }


    }

}
