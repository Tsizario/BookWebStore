using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.Helpers;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllCategories();

        Task<ServiceResult<CategoryDto>> GetCategory(Guid? id);

        Task<ServiceResult<CategoryDto>> AddCategory(CategoryCreateDto createDto);

        Task<ServiceResult<bool>> UpdateCategory(CategoryDto itemForUpdate);

        Task<ServiceResult<bool>> DeleteCategory(Guid id);
    }
}
