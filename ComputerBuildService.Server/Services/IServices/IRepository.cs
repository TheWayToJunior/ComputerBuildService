using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace ComputerBuildService.Server.IServices
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TPrimaryKey id);

        EntityEntry<TEntity> Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        bool Any(TPrimaryKey key);
    }
}
