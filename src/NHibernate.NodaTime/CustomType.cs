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

    public class CompositeCustomType<T> : CompositeCustomType where T : ICompositeUserType
    {
        public CompositeCustomType() : base(typeof(T), null)
        {

        }
    }
}
