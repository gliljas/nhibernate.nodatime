namespace NHibernate.NodaTime.Tests
{
    public class TestEntity<T> : Entity
    {
        public virtual T TestProperty { get; set; }
    }
}
