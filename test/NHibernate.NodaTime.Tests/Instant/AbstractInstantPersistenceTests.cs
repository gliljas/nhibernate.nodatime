using FluentAssertions;
using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public abstract class AbstractInstantPersistenceTests<TUserType> : AbstractPersistenceTests<Instant, TUserType>
          where TUserType : new()

    {
        protected AbstractInstantPersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {

        }

        [SkippableFact]
        public virtual void SupportsInUtc()
        {
            SupportsPropertyOrMethod(x => x.InUtc());
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsInZone(DateTimeZone zone)
        {
            SupportsPropertyOrMethod(x => x.InZone(zone));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMax(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var testValue = Instant.Max(testEntities[0].TestProperty, testEntities[0].TestComponent.TestComponentProperty);

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => Instant.Max(x.TestProperty, x.TestComponent.TestComponentProperty) == testValue).Select(x => new { ExposedProperty = Instant.Max(x.TestProperty, x.TestComponent.TestComponentProperty) }).ToList();
                foundEntities.Should().HaveCount(1);
                foundEntities[0].ExposedProperty.Should().Be(testValue);
            });
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMaxFromParameter(Instant testInstant)
        {
            SupportsPropertyOrMethod(x => Instant.Max(x, testInstant));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMin(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var testValue = Instant.Min(testEntities[0].TestProperty, testEntities[0].TestComponent.TestComponentProperty);

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => Instant.Min(x.TestProperty, x.TestComponent.TestComponentProperty) == testValue).Select(x => new { ExposedProperty = Instant.Min(x.TestProperty, x.TestComponent.TestComponentProperty) }).ToList();
                foundEntities.Should().HaveCount(1);
                foundEntities[0].ExposedProperty.Should().Be(testValue);
            });
        }

        [SkippableFact]
        [NodaTimeAutoData]
        public virtual void SupportsMinFromParameter(Instant testInstant)
        {
            SupportsPropertyOrMethod(x => Instant.Min(x, testInstant));
        }

        [SkippableFact]
        public virtual void SupportsToDateTimeOffset()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeOffset());
        }

        [SkippableFact]
        public virtual void SupportsToDateTimeUtc()
        {
            SupportsPropertyOrMethod(x => x.ToDateTimeUtc(), x => x.Kind.Should().Be(DateTimeKind.Utc));
        }

        [SkippableFact]
        public virtual void SupportsToUnixTimeMilliseconds()
        {
            SupportsPropertyOrMethod(x => x.ToUnixTimeMilliseconds());
        }

        [SkippableFact]
        public virtual void SupportsToUnixTimeSeconds()
        {
            SupportsPropertyOrMethod(x => x.ToUnixTimeSeconds());
        }


        [SkippableFact]
        public virtual void SupportsToUnixTimeTicks()
        {
            SupportsPropertyOrMethod(x => x.ToUnixTimeTicks());
        }

        [SkippableFact]
        public virtual void SupportsToJulianDate()
        {
            SupportsPropertyOrMethod(x => x.ToJulianDate());
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDurationWithOperator(Duration duration)
        {
            SupportsPropertyOrMethod(x => x + duration);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusDurationWithMethod(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Plus(duration));
        }


        [SkippableFact]
        public virtual void SupportsInstantSubtraction()
        {
            SupportsPropertyOrMethod(x => x.Minus(NodaConstants.UnixEpoch));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsDurationSubtraction(Duration testDuration)
        {
            SupportsPropertyOrMethod(x => x.Minus(testDuration));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithGreaterThan(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty > minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public void CanQueryWithLessThan(List<TestEntity<Instant>> testEntities)
        {
            AddToDatabase(testEntities.ToArray());

            var minimum = testEntities.Select(x => x.TestProperty).Min();

            ExecuteWithQueryable(q =>
            {
                var foundEntities = q.Where(x => x.TestProperty < minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsPlusWithMethod(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Plus(duration));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsMinusWithMethod(Duration duration)
        {
            SupportsPropertyOrMethod(x => x.Minus(duration));
        }


        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsWithOffset(Offset offset)
        {
            SupportsPropertyOrMethod(x => x.WithOffset(offset));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromDateTimeUtc(TestEntity<DateTime> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromDateTimeUtc(testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<DateTime>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromDateTimeUtc(x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromDateTimeOffset(TestEntity<DateTime> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromDateTimeOffset(testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<DateTime>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromDateTimeOffset(x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromJulianDate(TestEntity<double> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromJulianDate(testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<double>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromJulianDate(x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromFromUnixTimeMilliseconds(TestEntity<long> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromUnixTimeMilliseconds(testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<long>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromUnixTimeMilliseconds(x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromFromUnixTimeSeconds(TestEntity<long> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromUnixTimeSeconds(testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<long>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromUnixTimeSeconds(x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromUtc(TestEntity<int> testEntity)
        {

            AddToDatabase(testEntity);

            var minimum = Instant.FromUtc(testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<int>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromUtc(x.TestProperty, x.TestProperty, x.TestProperty, x.TestProperty, x.TestProperty) == minimum).ToList();
            });
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsFromUtcWithSeconds(TestEntity<int> testEntity)
        {
            AddToDatabase(testEntity);

            var minimum = Instant.FromUtc(testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty, testEntity.TestProperty);

            ExecuteWithQueryable<TestEntity<int>>(q =>
            {
                var foundEntities = q.Where(x => Instant.FromUtc(x.TestProperty, x.TestProperty, x.TestProperty, x.TestProperty, x.TestProperty, x.TestProperty) == minimum).ToList();
            });
        }
    }
}
