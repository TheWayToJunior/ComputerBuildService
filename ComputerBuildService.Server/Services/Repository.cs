using ComputerBuildService.Server.Helpers;
using ComputerBuildService.Server.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ComputerBuildService.Server.Services
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GerRange(int index, int size)
        {
            return Context.Set<TEntity>().GetRange(index, size);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().AddRange(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().RemoveRange(entity);
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navPath)
        {
            return Context.Set<TEntity>().Include(navPath);
        }
    }
}
