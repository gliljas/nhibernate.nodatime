using NHibernate.Type;
using NHibernate.UserTypes;

namespace NHibernate.NodaTime
{
    public class CustomType<T> : CustomType where T : IUserType
    {
        public CustomType() : base(typeof(T), null)
        {
        }
    }
}