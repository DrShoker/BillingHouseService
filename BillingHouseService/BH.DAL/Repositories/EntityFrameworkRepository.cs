using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BH.DTOL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BH.DAL.Repositories
{
    public class EntityFrameworkRepository<TContext> : IRepository
          where TContext : DbContext
    {
        protected readonly TContext context;

        public EntityFrameworkRepository(TContext context)
        {
            this.context = context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Length > 0)
            {
                foreach (var includeProperty in includeProperties.Where(item => !string.IsNullOrWhiteSpace(item)))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync<TEntity>(object id, string[] includeProperties = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(entity => entity.Id.Equals(id), null, includeProperties, null, null).FirstOrDefaultAsync();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual TEntity GetById<TEntity>(object id, string[] includeProperties = null)
            where TEntity : class, IEntity
        {
            return GetAll<TEntity>(entity => entity.Id.Equals(id), includeProperties: includeProperties).First();
        }
    }
}
