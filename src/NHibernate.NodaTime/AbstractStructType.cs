using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;
using NHibernate.UserTypes;
using System.Data.Common;

namespace NHibernate.NodaTime
{
    public abstract class AbstractStructType<T, TPersisted> : IUserType
    {
        protected abstract IType ValueType { get; }

        protected abstract SqlType SqlType { get; }

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
            return object.Equals(x, y);
        }

        public int GetHashCode(object x)
        {
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
            }
            var actualValue = (T)value;
            ValueType.NullSafeSet(cmd, Wrap(actualValue), index, session);
        }



        public object Replace(object original, object target, object owner) => original;
    }
}
