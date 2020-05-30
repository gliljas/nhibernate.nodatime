using NHibernate.Type;
using NHibernate.UserTypes;

namespace NHibernate.NodaTime
{
    public class CompositeCustomType<T> : CompositeCustomType where T : ICompositeUserType
    {
        public CompositeCustomType() : base(typeof(T), null)
        {
        }
    }
}