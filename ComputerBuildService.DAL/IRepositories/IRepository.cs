using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.IRepositories
{
    public interface IRepository<TEntity, TKey>
         where TEntity : class, IEntity<TKey>
    {
        Task<IQueryable<TEntity>> GetAll();

        Task<IQueryable<TEntity>> Get(TKey id);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        Task Update(TEntity entity);

        Task RemoveAsync(TEntity entity);

        Task RemoveRangeAsync(IEnumerable<TEntity> entity);

        Task<bool> AnyAsync(TKey key);
    }
}
