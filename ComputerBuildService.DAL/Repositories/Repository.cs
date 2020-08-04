using ComputerBuildService.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.DAL.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.Run(() => Context.Set<TEntity>());
        }

        public async Task<IQueryable<TEntity>> Get(TKey id)
        {
            return await Task.Run(() => Context.Set<TEntity>().Where(entity => entity.Id.Equals(id)));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await Context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await Context.Set<TEntity>().AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => Context.Set<TEntity>().Remove(entity));
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entity)
        {
            await Task.Run(() => Context.Set<TEntity>().RemoveRange(entity));
        }

        public async Task<bool> AnyAsync(TKey key)
        {
            return await Context.Set<TEntity>().AnyAsync(s => s.Id.Equals(key));
        }
    }
}
