using System;
using System.Linq;

namespace Corenet.Core
{
    public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<IEntity<TKey>>
    {
        public TKey Id { get; set; }

        protected Entity() { }

        protected Entity(TKey id) => Id = id;

        public override bool Equals(object obj)
        {
            if (obj is Entity<TKey> entity) return Equals(entity);
            return false;
        }

        public bool Equals(IEntity<TKey> otherEntity)
        {
            if (otherEntity is null) return false;
            return Id.Equals(otherEntity.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    public abstract class Entity : IEntity, IEquatable<IEntity>
    {
        public override bool Equals(object obj)
        {
            if (obj is Entity entity) return Equals(entity);
            return false;
        }

        public bool Equals(IEntity otherEntity)
        {
            if (otherEntity is null) return false;
            return GetKeyValues().SequenceEqual(otherEntity.GetKeyValues());
        }

        public override int GetHashCode() => GetKeyValues().GetHashCode();

        public abstract object[] GetKeyValues();
    }
}