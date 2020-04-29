using NHibernate.Engine;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;
using System.Data.Common;

namespace NHibernate.NodaTime
{
    public abstract class AbstractTwoPropertyStructType<T, TProperty1Persisted, TProperty2Persisted> : ICompositeUserType 
        where TProperty1Persisted : struct 
        where TProperty2Persisted : struct
    {
        protected abstract string Property1Name { get; }
        protected abstract string Property2Name { get; }

        protected abstract IType Property1Type { get; }
        protected abstract IType Property2Type { get; }

        protected abstract T Unwrap(TProperty1Persisted? property1Value, TProperty2Persisted? property2Value);

        protected abstract TProperty1Persisted? GetProperty1Value(T value);
        protected abstract TProperty2Persisted? GetProperty2Value(T value);


        string[] ICompositeUserType.PropertyNames => new[] { Property1Name, Property2Name };

        IType[] ICompositeUserType.PropertyTypes => new[] { Property1Type, Property2Type };

        System.Type ICompositeUserType.ReturnedClass => typeof(T);

        bool ICompositeUserType.IsMutable => false;

        object ICompositeUserType.Assemble(object cached, ISessionImplementor session, object owner) => cached;

        object ICompositeUserType.DeepCopy(object value) => value;

        object ICompositeUserType.Disassemble(object value, ISessionImplementor session) => value;

        bool ICompositeUserType.Equals(object x, object y)
        {
            throw new NotImplementedException();
        }

        int ICompositeUserType.GetHashCode(object x)
        {
            throw new NotImplementedException();
        }

        object ICompositeUserType.GetPropertyValue(object component, int property)
        {
            throw new NotImplementedException();
        }

        object ICompositeUserType.NullSafeGet(DbDataReader dr, string[] names, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        void ICompositeUserType.NullSafeSet(DbCommand cmd, object value, int index, bool[] settable, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        object ICompositeUserType.Replace(object original, object target, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        void ICompositeUserType.SetPropertyValue(object component, int property, object value)
        {
            throw new NotImplementedException();
        }
    }
}
