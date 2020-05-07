using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace NHibernate.NodaTime
{

    public abstract class AbstractStructType<T, TPersisted, TNullableType> : AbstractStructType<T, TPersisted>
        where TNullableType : NullableType, new()
    {
        public AbstractStructType() : base(new TNullableType())
        {

        }
    }

    public abstract class AbstractStructType<T, TPersisted> : IUserType, IParameterizedType
    {
        private NullableType _backingType;

        protected AbstractStructType(NullableType nullableType)
        {
            _backingType = nullableType;
        }
    
        protected NullableType ValueType => _backingType;

        protected virtual SqlType SqlType => ValueType.SqlType;

        protected abstract TPersisted Wrap(T value);

        protected abstract T Unwrap(TPersisted value);

        public SqlType[] SqlTypes => new[] { SqlType };

        public System.Type ReturnedType => typeof(T);

        public bool IsMutable => false;

        public object Assemble(object cached, object owner) => cached;

        public object DeepCopy(object value) => value;

        public object Disassemble(object value) => value;

        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x is T tx && y is T ty)
            {
                return ValueType.IsEqual(Wrap(tx), Wrap(ty));
            }
            return object.Equals(x, y);
        }

        public int GetHashCode(object x)
        {
            if (x is T tx)
            {
                return ValueType.GetHashCode(Wrap(tx));
            }
            if (x is TPersisted tx2)
            {
                return ValueType.GetHashCode(tx2);
            }
            return x?.GetHashCode() ?? 0;
        }

        public object? NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var value = ValueType.NullSafeGet(rs, names[0], session, owner);
            if (value == null)
            {
                return null;
            }
            var persistedValue = (TPersisted)value;
            return Unwrap(persistedValue);
        }

        public void NullSafeSet(DbCommand cmd, object? value, int index, ISessionImplementor session)
        {
            if (value == null)
            {
                ValueType.NullSafeSet(cmd, null, index, session);
                return;
            }
            var actualValue = (T)value;
            ValueType.NullSafeSet(cmd, Wrap(actualValue), index, session);
        }



        public object Replace(object original, object target, object owner) => original;

        public virtual void SetParameterValues(IDictionary<string, string> parameters)
        {
            if (ValueType is IParameterizedType parameterizedType)
            {
                parameterizedType.SetParameterValues(parameters);
            }
        }
    }
}
