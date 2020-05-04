using NHibernate.Util;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class SupportedQueryMethod<T>
    {
        public SupportedQueryMethod(MethodInfo method, IHqlMethodTransformer transformer)
        {

        }

        public SupportedQueryMethod(Expression<Func<T,object>> method, IHqlMethodTransformer transformer)
        {

        }
    }
}