using System.Linq.Expressions;
using Mezo.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Mezo.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity> GetByIdAsync(long id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> optionalQuery = null);
    //Task<TEntity> GetByIdAsync(long id, Expression<Func<TEntity, object>> include = null);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> include = null);
    Task<int> CreateAsync(TEntity entity);
}