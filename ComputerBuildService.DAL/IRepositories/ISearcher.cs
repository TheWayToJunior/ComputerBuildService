using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface ISearcher<TModel, TKey>
        where TModel : IUniqueEntity<TKey>
    {
        Task<TModel> SearchByName(string name);
    }
}
