using FluentAssertions;
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
    public class TestLab
    {
        [Theory]
        [NodaTimeAutoData]
        public void Something(List<TestClass> testEntities)
        {
            var z = testEntities[0].MyProperty.InUtc();
            var count=testEntities.Where(x => x.MyProperty.InUtc() == z).Count();
            var count2 = testEntities.Select(x => new { Entity = x, InUtc = new { Instant = x.MyProperty, Zone = DateTimeZone.Utc } }).Where(x => x.InUtc.Instant == z.ToInstant() && x.InUtc.Zone == z.Zone).Count();
            count.Should().Be(count2);
        }

        public class TestClass
        {
            public Instant MyProperty { get; set; }
        }
    }
}
