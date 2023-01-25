using BookWebStore.DAL.Repositories.Abstractions;
using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.ProductRepository
{
    public interface IProductRepository : IDbRepository<Product>
    {
        Task<bool> UpdateAsync(Product item); 
    }
}
