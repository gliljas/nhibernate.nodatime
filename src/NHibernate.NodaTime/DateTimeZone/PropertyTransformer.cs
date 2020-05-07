using NHibernate.NodaTime.Linq;

namespace NHibernate.NodaTime
{
    public class PropertyTransformer : IHqlPropertyTransformer
    {
        private readonly string _propertyName;

        public PropertyTransformer(string propertyName)
        {
            _propertyName = propertyName;
        }
    }
}