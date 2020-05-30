namespace NHibernate.NodaTime.Tests
{
    public class TestEntity<T> : Entity, ITestEntity<T>
    {
        public virtual T TestProperty { get; set; }
        public virtual TestComponent<T> TestComponent { get; set; }
    }
}