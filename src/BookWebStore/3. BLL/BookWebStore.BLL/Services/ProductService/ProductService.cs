using AutoMapper;
using BookWebStore.BLL.DTO.Product;
using BookWebStore.BLL.Helpers;
using BookWebStore.DAL.Repositories.ProductRepository;
using BookWebStore.Domain.Constants;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<ProductDto>>> GetAllProducts()
        {           
            var categories = await _repository.GetAllItemsAsync();

            var mappedDtos = _mapper.Map<IEnumerable<ProductDto>>(categories);

            return ServiceResult<IEnumerable<ProductDto>>.CreateSuccess(mappedDtos);
        }

        public async Task<ServiceResult<ProductDto>> GetProduct(Guid? id)
        {
            var category = await _repository.GetItemAsync(p => p.Id == id);

            var mapped = _mapper.Map<ProductDto>(category);

            return mapped is not null
                ? ServiceResult<ProductDto>.CreateSuccess(mapped)
                : ServiceResult<ProductDto>.CreateFailure(Errors.ProductNotFound);
        }

        public async Task<ServiceResult<bool>> AddProduct(ProductDto createdDto)
        {
            var mapped = _mapper.Map<Product>(createdDto);

            var result = await _repository.AddItemAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.ProductAddingError);
        }

        public async Task<ServiceResult<bool>> UpdateProduct(ProductDto itemForUpdate)
        {
            var mapped = _mapper.Map<Product>(itemForUpdate);

            var result = await _repository.UpdateAsync(mapped);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.ProductDoesNotExist);
        }

        public async Task<ServiceResult<bool>> DeleteType(Guid id)
        {
            var result = await _repository.RemoveItemAsync(id);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.ProductDoesNotExist);
        }
    }
}
