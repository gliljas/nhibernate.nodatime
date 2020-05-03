using AutoFixture;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.NodaTime.Tests.Fixtures
{
    public class NodaTimeAutoDataAttribute : AutoDataAttribute
    {
        public NodaTimeAutoDataAttribute() : base(()=>new Fixture().Customize(new NodaTimeCustomization()))
        {

        }
    }
}
