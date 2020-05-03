using System;

namespace NHibernate.NodaTime.Tests
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
