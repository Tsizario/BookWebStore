using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.CategoryService
{
    public interface ICoverTypeService
    {
        Task<ServiceResult<IEnumerable<CoverTypeDto>>> GetAllTypes();

        Task<ServiceResult<CoverTypeDto>> GetType(Guid? id);

        Task<ServiceResult<bool>> AddType(CoverTypeDto category);

        Task<ServiceResult<bool>> UpdateType(CoverTypeDto category);

        Task<ServiceResult<bool>> DeleteType(Guid id);
    }
}
