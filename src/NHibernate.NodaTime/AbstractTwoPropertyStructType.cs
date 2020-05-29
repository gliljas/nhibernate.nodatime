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
    public abstract class AbstractTwoPropertyStructType<T, TProperty1Persisted, TProperty2Persisted, TProperty1Type, TProperty2Type> : AbstractTwoPropertyStructType<T, TProperty1Persisted, TProperty2Persisted>
        where TProperty1Type : IType, new()
        where TProperty2Type : IType, new()
    {
        public AbstractTwoPropertyStructType() : base(new TProperty1Type(), new TProperty2Type())
        {
        }
    }
    public abstract class AbstractTwoPropertyStructType<T, TProperty1Persisted, TProperty2Persisted> : ICompositeUserType, ISupportLinqQueries<T>, IParameterizedType, INodaTimeType
    {
        private readonly IType _property1Type;
        private readonly IType _property2Type;

        protected AbstractTwoPropertyStructType(IType property1Type, IType property2Type)
        {
            if (property1Type.ReturnedClass != typeof(TProperty1Persisted))
            {
                throw new ArgumentException($"The {nameof(IType.ReturnedClass)} of {property1Type.GetType()} was expected to be {typeof(TProperty1Persisted)}, but was {property1Type.ReturnedClass}", nameof(property1Type));
            }
            
            if (property2Type.ReturnedClass != typeof(TProperty2Persisted))
            {
                throw new ArgumentException($"The {nameof(IType.ReturnedClass)} of {property2Type.GetType()} was expected to be {typeof(TProperty1Persisted)}, but was {property2Type.ReturnedClass}", nameof(property2Type));
            }

            _property1Type = property1Type;
            _property2Type = property2Type;
           
        }
        protected abstract string Property1Name { get; }
        protected abstract string Property2Name { get; }

        protected IType Property1Type => _property1Type;
        protected IType Property2Type => _property2Type;

        protected virtual int Property1ColumnSpan => 1;
        protected virtual int Property2ColumnSpan => 1;


        protected abstract T Unwrap(TProperty1Persisted property1Value, TProperty2Persisted property2Value);

        protected abstract TProperty1Persisted GetProperty1Value(T value);
        protected abstract TProperty2Persisted GetProperty2Value(T value);

        protected virtual T Cast(object value) => (T)value;


        string[] ICompositeUserType.PropertyNames => new[] { Property1Name, Property2Name };

        IType[] ICompositeUserType.PropertyTypes => new[] { Property1Type, Property2Type };

        System.Type ICompositeUserType.ReturnedClass => typeof(T);

        bool ICompositeUserType.IsMutable => false;

        public virtual IEnumerable<SupportedQueryProperty<T>> SupportedQueryProperties => Enumerable.Empty<SupportedQueryProperty<T>>();
        public virtual IEnumerable<SupportedQueryMethod<T>> SupportedQueryMethods => Enumerable.Empty<SupportedQueryMethod<T>>();

        public System.Type ReturnedType => typeof(T);

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
            var value = Cast(component);
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
            var value2 = (TProperty2Persisted)Property2Type.NullSafeGet(dr, names2, session, owner);

            return Unwrap(value1, value2);
        }

        void ICompositeUserType.NullSafeSet(DbCommand cmd, object value, int index, bool[] settable, ISessionImplementor session)
        {
            if (value == null)
            {
                Property1Type.NullSafeSet(cmd, null, index, session);
                Property2Type.NullSafeSet(cmd, null, index + Property1ColumnSpan, session);
                return;
            }
            var typedValue = Cast(value);
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

        public void SetParameterValues(IDictionary<string, string> parameters)
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

        //public virtual Expression<Func<T, TProperty1Persisted>>[] ExpressionsExposingPersistedProperty1 { get; } = new Expression<Func<T, TProperty1Persisted>>[] { };
        //public virtual Expression<Func<T, TProperty2Persisted>>[] ExpressionsExposingPersistedProperty2 { get; } = new Expression<Func<T, TProperty2Persisted>>[] { };

    }
}
