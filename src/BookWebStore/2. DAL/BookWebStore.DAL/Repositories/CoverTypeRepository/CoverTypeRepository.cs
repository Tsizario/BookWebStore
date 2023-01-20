using BookWebStore.DAL.Repositories.Repository;
using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.CoverTypeRepository
{
    public class CoverTypeRepository : DbRepository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoverTypeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateAsync(CoverType item)
        {
            _dbContext.CoverTypes.Update(item);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
