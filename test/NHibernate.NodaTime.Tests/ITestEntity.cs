using System;

namespace NHibernate.NodaTime.Tests
{
    public interface ITestEntity<T>
    {
        Guid Id { get; set; }
        T TestProperty { get; set; }
    }
}