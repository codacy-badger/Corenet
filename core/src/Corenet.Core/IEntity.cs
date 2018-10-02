namespace Corenet.Core
{
    public interface IEntity
    {
        object[] GetKeyValues();
    }

    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}