using BookWebStore.BLL.DTO.Product;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResult<IEnumerable<ProductDto>>> GetAllProducts();

        Task<ServiceResult<ProductDto>> GetProduct(Guid? id);

        Task<ServiceResult<bool>> AddProduct(ProductDto createdItem);

        Task<ServiceResult<bool>> UpdateProduct(ProductDto itemForUpdate);

        Task<ServiceResult<bool>> DeleteType(Guid id);
    }
}
