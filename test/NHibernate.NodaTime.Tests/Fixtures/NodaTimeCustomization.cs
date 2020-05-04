using AutoFixture;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NodaTimeCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new AnnualDateBuilder());
            fixture.Customizations.Add(new InstantBuilder());
            fixture.Customizations.Add(new LocalDateBuilder());
            fixture.Customizations.Add(new LocalDateTimeBuilder());
            fixture.Customizations.Add(new LocalTimeBuilder());
            fixture.Customizations.Add(new OffsetDateBuilder());
            fixture.Customizations.Add(new OffsetDateTimeBuilder());
            fixture.Customizations.Add(new OffsetTimeBuilder());

        }
    }
}
