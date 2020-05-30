using NHibernate.Engine;
using NHibernate.Type;
using NHibernate.UserTypes;
using System;
using System.Runtime.CompilerServices;

namespace NHibernate.NodaTime
{
    public abstract class VersionedAbstractStructType<T, TPersisted, TNullableType> : AbstractStructType<T, TPersisted, TNullableType>, IUserVersionType
        where TNullableType : NullableType, IVersionType, new()
    {
        public virtual int Compare(object x, object y)
        {
            if (ValueType is IVersionType versionType)
            {
                return versionType.Compare(Wrap((T)x), Wrap((T)y));
            };
            throw new NotImplementedException();
        }

        public virtual object Next(object current, ISessionImplementor session)
        {
            if (ValueType is IVersionType versionType)
            {
                Unwrap((TPersisted)versionType.Next(Wrap((T)current), session));
            }
            throw new NotImplementedException();
        }

        public virtual object Seed(ISessionImplementor session)
        {
            if (ValueType is IVersionType versionType)
            {
                Unwrap((TPersisted)versionType.Seed(session));
            }
            throw new NotImplementedException();
        }
    }

    public class FactoryLocal<T> where T : class
    {
        private ConditionalWeakTable<ISessionFactoryImplementor, T> _conditionalWeakTable = new ConditionalWeakTable<ISessionFactoryImplementor, T>();

        public FactoryLocal()
        {
        }

        public T GetOrAdd(ISessionFactoryImplementor factory, Func<ISessionFactoryImplementor, T> factoryFunc) => _conditionalWeakTable.GetValue(factory, new ConditionalWeakTable<ISessionFactoryImplementor, T>.CreateValueCallback(factoryFunc));
    }
}