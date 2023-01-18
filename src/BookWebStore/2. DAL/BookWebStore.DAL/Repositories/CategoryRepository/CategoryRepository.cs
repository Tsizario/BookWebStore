using BookWebStore.DAL.Repositories.Repository;
using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.CategoryRepository
{
    public class CategoryRepository : DbRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateAsync(Category item)
        {
            _dbContext.Categories.Update(item);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}