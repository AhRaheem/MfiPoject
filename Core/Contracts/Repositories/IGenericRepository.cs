
using Core.Persistence;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Contracts.Repositories
{
    public interface IGenericRepository<TContext,T> 
		where T : class
		where TContext : IDbContext
    {
        Task<T> GetById(string id, Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool enableTracking = true);

		Task<T> Get(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool enableTracking = true);

		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			int page = 0,
			int size = 0,
			bool enableTracking = true);

		IQueryable<T> GetAllQuery(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
			int page = 0,
			int size = 0,
			bool enableTracking = true);
		
		Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
