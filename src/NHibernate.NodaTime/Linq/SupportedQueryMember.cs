using NHibernate.Util;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class SupportedQueryMember : ISupportedQueryMember
    {
       
        private SupportedQueryMember(MemberInfo member, IHqlMemberTransformer transformer)
        {
            Member = member;
            Transformer = transformer;
        }

        public static SupportedQueryMember ForMethod<T,TValue>(Expression<Func<T, TValue>> methodExpression, IHqlMemberTransformer transformer)
        {
            var method = ReflectHelper.GetMethod(methodExpression);
            return new SupportedQueryMember(method, transformer);
        }

        public static SupportedQueryMember ForProperty<T, TValue>(Expression<Func<T, TValue>> member, IHqlMemberTransformer transformer)
        {
            return new SupportedQueryMember(ReflectHelper.GetProperty(member), transformer);
        }

        public MemberInfo Member { get; }

        public IHqlMemberTransformer Transformer { get; }
    }
}