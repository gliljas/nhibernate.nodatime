﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    public class SupportedQueryProperty<T> : ISupportedQueryProperty
    {
        public SupportedQueryProperty(MemberInfo member, IHqlPropertyTransformer transformer)
        {
        }

        public SupportedQueryProperty(Expression<Func<T, object>> member, IHqlPropertyTransformer transformer)
        {
        }
    }

    public interface ISupportedQueryProperty
    { 
    }
}