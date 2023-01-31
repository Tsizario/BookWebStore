using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.CoverTypeService
{
    public interface ICoverTypeService
    {
        Task<ServiceResult<IEnumerable<CoverTypeDto>>> GetAllTypes();

        Task<ServiceResult<CoverTypeDto>> GetType(Guid? id);

        Task<ServiceResult<CoverTypeDto>> AddType(CoverTypeDto createdDto);

        Task<ServiceResult<bool>> UpdateType(CoverTypeDto itemForUpdate);

        Task<ServiceResult<bool>> DeleteType(Guid id);
    }
}
