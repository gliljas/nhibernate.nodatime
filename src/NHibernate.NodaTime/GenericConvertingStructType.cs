using NHibernate.Type;
using System;

namespace NHibernate.NodaTime
{
    public class GenericConvertingStructType<T, TPersisted, TNullableType> : AbstractStructType<T, TPersisted, TNullableType>
        where TNullableType : NullableType, new()
    {
        private readonly Func<T, TPersisted> _convertToPersisted;
        private readonly Func<TPersisted, T> _convertFromPersisted;

        public GenericConvertingStructType(Func<T, TPersisted> convertToPersisted, Func<TPersisted, T> convertFromPersisted)
        {
            _convertToPersisted = convertToPersisted;
            _convertFromPersisted = convertFromPersisted;
        }

        protected override T Unwrap(TPersisted value) => _convertFromPersisted(value);

        protected override TPersisted Wrap(T value) => _convertToPersisted(value);
    }
}