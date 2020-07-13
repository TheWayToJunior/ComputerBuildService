using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ComputerBuildService.Server.IServices
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GerRange(int index, int size);

        TEntity Get(int id);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navPath);
    }
}
