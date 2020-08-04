namespace ComputerBuildService
{
    public interface IUniqueEntity<out TKey> : IEntity<TKey>
    {
        string Name { get; set; }
    }
}
