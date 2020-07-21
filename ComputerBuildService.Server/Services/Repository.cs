using ComputerBuildService.Server.Data;
using ComputerBuildService.Server.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Services
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TEntity> GetAll<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get<TEntity, TKey>(TKey id)
            where TEntity : class, IEntity<TKey>
        {
            return context.Set<TEntity>().Where(entity => entity.Id.Equals(id));
        }

        public async Task<TEntity> Add<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            return (await context.Set<TEntity>().AddAsync(entity))?.Entity;
        }

        public async Task AddRange<TEntity, TKey>(IEnumerable<TEntity> entity)
            where TEntity : class, IEntity<TKey>
        {
            await context.Set<TEntity>().AddRangeAsync(entity);
        }

        public void Update<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Remove<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            await Task.Run(() => context.Set<TEntity>().Remove(entity));
        }

        public async Task RemoveRange<TEntity, TKey>(IEnumerable<TEntity> entity)
            where TEntity : class, IEntity<TKey>
        {
            await Task.Run(() => context.Set<TEntity>().RemoveRange(entity));
        }

        public async Task<bool> Any<TEntity, TKey>(TKey key)
            where TEntity : class, IEntity<TKey>
        {
            return await context.Set<TEntity>().AnyAsync(s => s.Id.Equals(key));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
