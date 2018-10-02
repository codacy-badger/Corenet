namespace Corenet.Core
{
    public abstract class AggregateRoot : Entity, IAggregateRoot { }

    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey> { }
}
