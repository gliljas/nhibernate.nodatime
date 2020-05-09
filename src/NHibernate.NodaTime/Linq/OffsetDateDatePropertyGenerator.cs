﻿using NHibernate.Hql.Ast;
using NHibernate.Impl;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace NHibernate.NodaTime.Linq
{
    internal class OffsetDateDatePropertyGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty<OffsetDate,LocalDate>(x=>x.Date)};

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.MethodCall("tolocaldate",treeBuilder.MethodCall("date", visitor.Visit(expression).AsExpression()));
        }
    }

    internal class LocalDateWithOffsetMethodGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<LocalDate>(x => x.WithOffset(Offset.Zero)) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var offsetConstant = arguments[0] as ConstantExpression;
            var offset = (Offset)offsetConstant.Value;
            var sessionFactoryImpl = visitor.SessionFactory as SessionFactoryImpl;
            return treeBuilder.MethodCall("tooffsetdate", treeBuilder.MethodCall("switchoffset", visitor.Visit(targetObject).AsExpression(), treeBuilder.Constant(offset.Seconds / 60)));
        }
    }

    internal class LocalDateYearPropertyGenerator : IHqlGeneratorForProperty
    {
        public IEnumerable<MemberInfo> SupportedProperties => new[] { ReflectHelper.GetProperty<LocalDate, int>(x => x.Year) };

        public HqlTreeNode BuildHql(MemberInfo member, Expression expression, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.MethodCall("year", visitor.Visit(expression).AsExpression());
        }
    }

    internal class InstantPlusMethodGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods => new[] { ReflectHelper.GetMethod<Instant>(x => x.Plus(new Duration())) };

        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

}