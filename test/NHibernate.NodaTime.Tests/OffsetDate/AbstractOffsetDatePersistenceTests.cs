﻿using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractOffsetDatePersistenceTests<TUserType> : AbstractPersistenceTests<OffsetDate, TUserType>
    where TUserType : new()
    {
        protected AbstractOffsetDatePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByLocalDate(TestEntity<OffsetDate> testValue)
        {
            var date = testValue.TestProperty.Date;

            AddToDatabase(testValue);

            using (var session = SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var list = session.Query<TestEntity<OffsetDate>>().Where(x => x.TestProperty.Date == date).ToList();
                    list.Should().HaveCount(1);
                }
            }
        }

        [Theory]
        [NodaTimeAutoData]
        public void CanQueryByWithOffset(TestEntity<OffsetDate> testValue)
        {
            var date = testValue.TestProperty.Date.WithOffset(Offset.FromHours(3));

            AddToDatabase(testValue);

            using (var session = SessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var list = session.Query<TestEntity<OffsetDate>>().Where(x => x.TestProperty.Date.WithOffset(Offset.FromHours(3)) == date).ToList();
                    list.Should().HaveCount(1);
                }
            }
        }

    }
}
