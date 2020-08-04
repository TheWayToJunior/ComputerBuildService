using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface ISearcher<TModel>
    {
        Task<TModel> GetByName(string name);
    }
}
