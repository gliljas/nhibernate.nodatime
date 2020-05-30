using NHibernate.NodaTime.Tests.Fixtures;
using NodaTime;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NHibernate.NodaTime.Tests
{
    public class AnnualDateAsDateTypePersistenceTests : AbstractPersistenceTests<AnnualDate, AnnualDateAsDateType>
    {
        public AnnualDateAsDateTypePersistenceTests(NHibernateFixture nhibernateFixture) : base(nhibernateFixture)
        {
        }

        [SkippableFact]
        public virtual void SupportsDay()
        {
            SupportsPropertyOrMethod(x => x.Day);
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsInYear(int year)
        {
            SupportsPropertyOrMethod(x => x.InYear(year));
        }

        [SkippableTheory]
        [NodaTimeAutoData]
        public virtual void SupportsIsValidYear(int year)
        {
            SupportsPropertyOrMethod(x => x.IsValidYear(year));
        }

        [SkippableFact]
        public virtual void SupportsMonth()
        {
            SupportsPropertyOrMethod(x => x.Month);
        }
        protected override object GetTypeParameters()
        {
            return new
            {
                BaseYear = 2000
            };
        }
    }
}