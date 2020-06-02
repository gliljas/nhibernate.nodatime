using NHibernate.Util;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class SupportedQueryMethod<T> : ISupportedQueryMethod
    {
        public SupportedQueryMethod(MethodInfo method, IHqlMethodTransformer transformer)
        {
            Method = method;
            Transformer = transformer;
        }

        public SupportedQueryMethod(Expression<Func<T, DateTimeOffset>> method, IHqlMethodTransformer transformer)
        {
            Method = ReflectHelper.GetMethod(method);
            Transformer = transformer;
        }

        public MethodInfo Method { get; }

        public IHqlMethodTransformer Transformer { get; }
    }

    public interface ISupportedQueryMethod
    { 
        MethodInfo Method { get; }
        IHqlMethodTransformer Transformer { get; }
    }
}