using AutoMapper;
using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.BLL.Helpers;
using BookWebStore.DAL.Repositories.CoverTypeRepository;
using BookWebStore.Domain.Constants;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.Services.CategoryService
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ICoverTypeRepository _repository;
        private readonly IMapper _mapper;

        public CoverTypeService(ICoverTypeRepository type,
            IMapper mapper)
        {
            _repository = type;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<CoverTypeDto>>> GetAllTypes()
        {           
            var categories = await _repository.GetAllItemsAsync();

            var mappedDtos = _mapper.Map<IEnumerable<CoverTypeDto>>(categories);

            return ServiceResult<IEnumerable<CoverTypeDto>>.CreateSuccess(mappedDtos);
        }

        public async Task<ServiceResult<CoverTypeDto>> GetType(Guid? id)
        {
            var category = await _repository.GetItemAsync(p => p.Id == id);

            var mapped = _mapper.Map<CoverTypeDto>(category);

            return mapped is not null
                ? ServiceResult<CoverTypeDto>.CreateSuccess(mapped)
                : ServiceResult<CoverTypeDto>.CreateFailure(Errors.CoverTypeNotFound);
        }

        public async Task<ServiceResult<bool>> AddType(CoverTypeDto createdDto)
        {
            var mapped = _mapper.Map<CoverType>(createdDto);

            var result = await _repository.AddItemAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CoverTypeAddingError);
        }

        public async Task<ServiceResult<bool>> UpdateType(CoverTypeDto itemForUpdate)
        {
            var mapped = _mapper.Map<CoverType>(itemForUpdate);

            var result = await _repository.UpdateAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CoverTypeDoesNotExist);
        }

        public async Task<ServiceResult<bool>> DeleteType(Guid id)
        {
            var result = await _repository.RemoveItemAsync(id);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CoverTypeDoesNotExist);
        }
    }
}
