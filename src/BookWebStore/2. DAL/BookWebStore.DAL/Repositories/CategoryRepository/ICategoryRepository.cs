using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllEntitiesAsync();

        Task<Category> GetByIdAsync(Guid? id);

        Task<bool> AddAsync(Category item);

        Task<bool> UpdateAsync(Category item);

        Task<bool> DeleteAsync(Guid id);
    }
}
