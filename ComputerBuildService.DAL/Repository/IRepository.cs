using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Contract.Data
{
    public interface IRepository
    {
        IQueryable<TEntity> GetAll<TEntity, TKey>()
             where TEntity : class, IEntity<TKey>;


        IQueryable<TEntity> Get<TEntity, TKey>(TKey id)
            where TEntity : class, IEntity<TKey>;

        Task<TEntity> Add<TEntity, TKey>(TEntity entity)
             where TEntity : class, IEntity<TKey>;


        Task AddRange<TEntity, TKey>(IEnumerable<TEntity> entity)
           where TEntity : class, IEntity<TKey>;


        void Update<TEntity, TKey>(TEntity entity)
             where TEntity : class, IEntity<TKey>;


        Task Remove<TEntity, TKey>(TEntity entity)
           where TEntity : class, IEntity<TKey>;


        Task RemoveRange<TEntity, TKey>(IEnumerable<TEntity> entity)
             where TEntity : class, IEntity<TKey>;


        Task<bool> Any<TEntity, TKey>(TKey key)
            where TEntity : class, IEntity<TKey>;

        Task<int> SaveChangesAsync();
    }
}
