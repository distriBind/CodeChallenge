using System.Linq.Expressions;
using Mezo.Data.Entities;
using Mezo.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Mezo.Data.Repositories.Interfaces
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly MezoDbContext _mezoDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MezoDbContext mezoDbContext)
        {
            _mezoDbContext = mezoDbContext;
            _dbSet = _mezoDbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(long id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> optionalQuery = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (optionalQuery != null) 
                query = optionalQuery(query);

            var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);

            return entity;
        }

        // public async Task<TEntity> GetByIdAsync(long id, Expression<Func<TEntity, object>> include = null)
        // {
        //     IQueryable<TEntity> query = _dbSet;
        //
        //     if (include != null)
        //     {
        //         query = query.Include(include);
        //     }
        //
        //     return await query.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        // }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null) 
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            _mezoDbContext.Set<TEntity>();
            await _mezoDbContext.AddAsync(entity);
            return await _mezoDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithRelatedAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
    }
}
