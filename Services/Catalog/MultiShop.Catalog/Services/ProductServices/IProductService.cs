using MultiShop.Catalog.Dtos.Product;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductResultDto>> GetAllProductAsync();
        Task CreateProductAsync(ProductCreateDto createProductDto);
        Task UpdateProductAsync(ProductUpdateDto updateProductDto);
        Task DeleteProductAsync(string productID);
        Task<ProductDetailDto> GetProductByIDAsync(string productID);
    }
}
