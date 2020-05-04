using NHibernate.Engine;
using NHibernate.NodaTime.Linq;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace NHibernate.NodaTime
{
    public abstract class AbstractTwoPropertyStructType<T, TProperty1Persisted, TProperty2Persisted> : ICompositeUserType, ISupportLinqQueries<T>, IParameterizedType
    {
        protected abstract string Property1Name { get; }
        protected abstract string Property2Name { get; }

        protected abstract IType Property1Type { get; }
        protected abstract IType Property2Type { get; }

        protected abstract int Property1ColumnSpan { get; }
        protected abstract int Property2ColumnSpan { get; }


        protected abstract T Unwrap(TProperty1Persisted property1Value, TProperty2Persisted property2Value);

        protected abstract TProperty1Persisted GetProperty1Value(T value);
        protected abstract TProperty2Persisted GetProperty2Value(T value);


        string[] ICompositeUserType.PropertyNames => new[] { Property1Name, Property2Name };

        IType[] ICompositeUserType.PropertyTypes => new[] { Property1Type, Property2Type };

        System.Type ICompositeUserType.ReturnedClass => typeof(T);

        bool ICompositeUserType.IsMutable => false;

        public virtual IEnumerable<SupportedQueryProperty<T>> SupportedQueryProperties => Enumerable.Empty<SupportedQueryProperty<T>>();
        public virtual IEnumerable<SupportedQueryMethod<T>> SupportedQueryMethods => Enumerable.Empty<SupportedQueryMethod<T>>();

        object ICompositeUserType.Assemble(object cached, ISessionImplementor session, object owner) => cached;

        object ICompositeUserType.DeepCopy(object value) => value;

        object ICompositeUserType.Disassemble(object value, ISessionImplementor session) => value;

        bool ICompositeUserType.Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return object.Equals(x, y);
        }

        int ICompositeUserType.GetHashCode(object x)
        {
            return x?.GetHashCode() ?? 0;
        }

        object? ICompositeUserType.GetPropertyValue(object? component, int property)
        {
            if (component == null)
            {
                return null;
            }
            var value = (T)component;
            return property switch
            {
                0 => GetProperty1Value(value),
                1 => GetProperty2Value(value),
                _ => throw new ArgumentException(message: "invalid property index", paramName: nameof(property)),
            };
        }

        object? ICompositeUserType.NullSafeGet(DbDataReader dr, string[] names, ISessionImplementor session, object owner)
        {
            var names1 = new string[Property1ColumnSpan];
            var names2 = new string[Property2ColumnSpan];
            Array.Copy(names, names1, Property1ColumnSpan);
            Array.Copy(names, Property1ColumnSpan, names2, 0, Property2ColumnSpan);

            var value1 = (TProperty1Persisted)Property1Type.NullSafeGet(dr, names1, session, owner);
            var value2 = (TProperty2Persisted)Property2Type.NullSafeGet(dr, names1, session, owner);

            return Unwrap(value1,value2);
        }

        void ICompositeUserType.NullSafeSet(DbCommand cmd, object value, int index, bool[] settable, ISessionImplementor session)
        {
            if (value == null)
            {
                Property1Type.NullSafeSet(cmd, null, index, session);
                Property2Type.NullSafeSet(cmd, null, index + Property1ColumnSpan, session);
                return;
            }
            var typedValue = (T)value;
            Property1Type.NullSafeSet(cmd, GetProperty1Value(typedValue), index, session);
            Property2Type.NullSafeSet(cmd, GetProperty2Value(typedValue), index + Property1ColumnSpan, session);
        }

        object ICompositeUserType.Replace(object original, object target, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        void ICompositeUserType.SetPropertyValue(object component, int property, object value)
        {
            throw new NotImplementedException();
        }

        void IParameterizedType.SetParameterValues(IDictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                if (Property1Type is IParameterizedType parameterizedType1)
                {
                    parameterizedType1.SetParameterValues(parameters.Where(x => x.Key.StartsWith(Property1Name + "_")).ToDictionary(x => x.Key.Remove(0, Property1Name.Length + 1), x => x.Value));
                }
                if (Property2Type is IParameterizedType parameterizedType2)
                {
                    parameterizedType2.SetParameterValues(parameters.Where(x => x.Key.StartsWith(Property2Name + "_")).ToDictionary(x => x.Key.Remove(0, Property2Name.Length + 1), x => x.Value));
                }
            }
        }
    }
}
