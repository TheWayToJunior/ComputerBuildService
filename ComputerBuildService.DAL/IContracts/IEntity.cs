namespace ComputerBuildService
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
