using BookWebStore.DAL.Repositories.Abstractions;
using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IDbRepository<Category>
    {
        Task<bool> UpdateAsync(Category item);
    }
}
