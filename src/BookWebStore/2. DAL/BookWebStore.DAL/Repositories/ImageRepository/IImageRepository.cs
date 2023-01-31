using BookWebStore.Domain.Entities;

namespace BookWebStore.DAL.Repositories.PhotoRepository
{
    public interface IImageRepository
    {
        Task<Image> AddAsync(Image image);

        Task<bool> DeleteAsync(int id);
    }
}
