﻿using ComputerBuildService.Server.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ComputerBuildService.Server.Services
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
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

        public TEntity Get(TPrimaryKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity)?.Entity;
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

        public bool Any(TPrimaryKey key)
        {
            return Context.Set<TEntity>().Any(s => s.Id.Equals(key));
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] navigations)
        {
            var context = Context.Set<TEntity>();

            IQueryable<TEntity> query = null;

            foreach (var item in navigations)
            {
                query = context.Include(item);
            }

            return query ?? context;
        }
    }
}
