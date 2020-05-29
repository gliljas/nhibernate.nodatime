using AutoFixture;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NodaTimeCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new AnnualDateSpecimenBuilder());
            fixture.Customizations.Add(new DateIntervalSpecimenBuilder());
            fixture.Customizations.Add(new DateTimeZoneSpecimenBuilder());
            fixture.Customizations.Add(new DurationSpecimenBuilder());
            fixture.Customizations.Add(new InstantBuilder());
            fixture.Customizations.Add(new LocalDateSpecimenBuilder());
            fixture.Customizations.Add(new LocalDateTimeSpecimenBuilder());
            fixture.Customizations.Add(new LocalTimeSpecimenBuilder());
            fixture.Customizations.Add(new OffsetDateSpecimenBuilder());
            fixture.Customizations.Add(new OffsetDateTimeSpecimenBuilder());
            fixture.Customizations.Add(new OffsetTimeSpecimenBuilder());
            fixture.Customizations.Add(new PeriodSpecimenBuilder());
            fixture.Customizations.Add(new YearMonthSpecimenBuilder());

        }
    }
}
