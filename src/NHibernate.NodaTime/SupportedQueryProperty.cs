using System.Reflection;

namespace NHibernate.NodaTime
{
    public class SupportedQueryProperty<T>
    {
        public SupportedQueryProperty(MemberInfo member,IHqlPropertyTransformer transformer)
        {

        }
    }

    public class SupportedQueryMethod<T>
    {
        public SupportedQueryMethod(MethodInfo method, IHqlMethodTransformer transformer)
        {

        }
    }
}