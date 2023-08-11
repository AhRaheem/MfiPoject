using Core.Contracts.Repositories;
using Core.Entities.Base;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository
{
    public abstract class GenericRepository<TContext,T> : IGenericRepository<TContext, T> 
		where T : BaseEntity
		where TContext : IDbContext
    {
        protected readonly TContext _dbContext;

        protected GenericRepository(TContext context)
        {
            _dbContext = context;
        }
		
		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int page = 1, int size = 10, bool enableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();

			if (!enableTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (predicate != null) query = query.Where(predicate);
			if (orderBy != null) return await orderBy(query).Skip(page * size).Take(size).ToListAsync();
			return await query.OrderByDescending(x=>x.CreatedOn).Skip(page * size).Take(size).ToListAsync();
		}

		public IQueryable<T> GetAllQuery(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int page = 1, int size = 10, bool enableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();
			if (!enableTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (predicate != null) query = query.Where(predicate);
			return query;
		}

		public async Task<T> GetById(string id, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();
			if (!enableTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (predicate != null) query = query.Where(predicate);
			return await query.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<T> Get(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
		{
			IQueryable<T> query = _dbContext.Set<T>();
			if (!enableTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (predicate != null) query = query.Where(predicate);
			if (orderBy != null) return await orderBy(query).FirstOrDefaultAsync();
			return await query.FirstOrDefaultAsync();
		}

		public async Task Add(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
		}

		public async Task Update(T entity)
		{
			await Task.Run(() => { _dbContext.Set<T>().Update(entity); });
		}

		public async Task Delete(T entity)
		{
			entity.IsDeleted= true;
			entity.DeletedOn= DateTime.Now;
			await Update(entity);
		}
	}
}
