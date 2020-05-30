using AutoFixture.Xunit2;
using FluentAssertions;
using NHibernate.Engine;
using NodaTime;
using NSubstitute;
using System.Data.Common;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class TzdbDateTimeZoneTypeTests
    {
        [Theory]
        [AutoData]
        public void NullSafeGet_ShouldReturnATimeZone(TzdbDateTimeZoneType sut)
        {
            var reader = Substitute.For<DbDataReader>();
            reader.GetOrdinal("Zone").Returns(0);
            reader[0].Returns(DateTimeZoneProviders.Tzdb.Ids[0]);
            var value = sut.NullSafeGet(reader, new[] { "Zone" }, Substitute.For<ISessionImplementor>(), null);
            value.Should().NotBeNull();
            value.Should().BeAssignableTo<DateTimeZone>();
        }
    }
}