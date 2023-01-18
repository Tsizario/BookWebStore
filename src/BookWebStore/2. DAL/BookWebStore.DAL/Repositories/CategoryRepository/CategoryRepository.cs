using BookWebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebStore.DAL.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllEntitiesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid? id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<bool> AddAsync(Category item)
        {
            await _dbContext.Categories.AddAsync(item);

            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Category updatedItem)
        {
            _dbContext.Categories.Update(updatedItem);

            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await GetByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            _dbContext.Categories.Remove(category);

            return await SaveChangesAsync() > 0;
        }

        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}