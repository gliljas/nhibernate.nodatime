﻿using NHibernate.Hql.Ast;
using NHibernate.Linq.Visitors;
using NHibernate.NodaTime.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime
{
    internal class PlusDurationTransformer : IHqlMemberTransformer
    {
        public HqlExpression BuildHql(HqlExpression expression, ReadOnlyCollection<HqlExpression> arguments, HqlTreeBuilder treeBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}