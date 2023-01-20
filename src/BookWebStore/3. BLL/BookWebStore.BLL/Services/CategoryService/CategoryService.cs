using AutoMapper;
using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.Helpers;
using BookWebStore.DAL.Repositories.CategoryRepository;
using BookWebStore.Domain.Constants;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository category,
            IMapper mapper)
        {
            _repository = category;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {           
            var categories = await _repository.GetAllItemsAsync();

            var mappedDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return ServiceResult<IEnumerable<CategoryDto>>.CreateSuccess(mappedDtos);
        }

        public async Task<ServiceResult<CategoryDto>> GetCategory(Guid? id)
        {
            var category = await _repository.GetItemAsync(p => p.Id == id);

            var mapped = _mapper.Map<CategoryDto>(category);

            return mapped is not null
                ? ServiceResult<CategoryDto>.CreateSuccess(mapped)
                : ServiceResult<CategoryDto>.CreateFailure(Errors.CategoryNotFound);
        }

        public async Task<ServiceResult<bool>> AddCategory(CategoryCreateDto createdDto)
        {
            var mapped = _mapper.Map<Category>(createdDto);

            var result = await _repository.AddItemAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CategoryAddingError);
        }

        public async Task<ServiceResult<bool>> UpdateCategory(CategoryDto itemForUpdate)
        {
            var mapped = _mapper.Map<Category>(itemForUpdate);

            var result = await _repository.UpdateAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CategoryDoesNotExist);
        }

        public async Task<ServiceResult<bool>> DeleteCategory(Guid id)
        {
            var result = await _repository.RemoveItemAsync(id);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.CategoryDoesNotExist);
        }
    }
}
