using BookWebStore.DAL.Repositories.Abstractions;
using BookWebStore.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookWebStore.DAL.Repositories.Repository
{
    public class DbRepository<T> : IDbRepository<T> 
        where T : class, IDbEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;        

        public DbRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> AllItems => _dbSet;

        public async Task<IEnumerable<T>> GetAllItemsAsync(Expression<Func<T, bool>> filter = null, string includeProps = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string includeProps = null)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProps != null)
            {
                foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);    
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> AddItemAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveItemAsync(Guid id)
        {
            T candidate = await AllItems.FirstOrDefaultAsync(e => e.Id == id);

            if (candidate == null)
            {
                return false;
            }

            _dbSet.Remove(candidate);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveItemsAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}