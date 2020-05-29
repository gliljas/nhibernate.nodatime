using AutoFixture;
using AutoFixture.Xunit2;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NodaTimeAutoDataAttribute : AutoDataAttribute
    {
        public NodaTimeAutoDataAttribute() : base(() => new Fixture().Customize(new NodaTimeCustomization()))
        {
        }
    }
}
