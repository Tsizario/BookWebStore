using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllCategories();

        Task<ServiceResult<CategoryDto>> GetCategory(Guid? id);

        Task<ServiceResult<bool>> AddCategory(CategoryCreateDto createDto);

        Task<ServiceResult<bool>> UpdateCategory(CategoryDto itemForUpdate);

        Task<ServiceResult<bool>> DeleteCategory(Guid id);
    }
}
