using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.CategoryService
{
    public interface IProductService
    {
        Task<ServiceResult<IEnumerable<CoverTypeDto>>> GetAllTypes();

        Task<ServiceResult<CoverTypeDto>> GetType(Guid? id);

        Task<ServiceResult<bool>> AddType(CoverTypeDto createdDto);

        Task<ServiceResult<bool>> UpdateType(CoverTypeDto itemForUpdate);

        Task<ServiceResult<bool>> DeleteType(Guid id);
    }
}
