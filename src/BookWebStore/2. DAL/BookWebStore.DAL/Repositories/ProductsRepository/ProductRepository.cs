using AutoMapper;
using BookWebStore.DAL.Repositories.Repository;
using BookWebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebStore.DAL.Repositories.ProductRepository
{
    public class ProductRepository : DbRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext,
            IMapper mapper)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Update(Product item)
        {
            var objFromDb = GetItemAsync(p => p.Id == item.Id);

            if (objFromDb == null)
            {
                return false;
            }

            await _mapper.Map(item, objFromDb);
            _dbContext.Entry(item).State = EntityState.Modified;

            return true;
        }
    }
}
