using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.PhotoRepository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image> AddAsync(Image image)
        {
            await _dbContext.Images.AddAsync(image);

            await _dbContext.SaveChangesAsync();

            return image;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var photo = await _dbContext.Images.FindAsync(id);

            if (photo == null)
            {
                return false;
            }

            _dbContext.Images.Remove(photo);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
