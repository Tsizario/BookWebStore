using BookWebStore.DAL.Repositories.Abstractions;
using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.CoverTypeRepository
{
    public interface ICoverTypeRepository : IDbRepository<CoverType>
    {
        Task<bool> UpdateAsync(CoverType item);
    }
}
