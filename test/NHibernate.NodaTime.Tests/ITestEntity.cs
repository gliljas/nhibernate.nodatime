using System;

namespace NHibernate.NodaTime.Tests
{
    public interface ITestEntity<T>
    {
        Guid Id { get; set; }
        T TestProperty { get; set; }
        TestComponent<T> TestComponent { get; set; }
    }

    public class TestComponent<T>
    {
        public T TestComponentProperty { get; set; }
    }
}