using MultiShop.Catalog.Dtos.ProductImage;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ProductImageResultDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(ProductImageCreateDto createProductImageDto);
        Task UpdateProductImageAsync(ProductImageUpdateDto updateProductImageDto);
        Task DeleteProductImageAsync(string productImageID);
        Task<ProductImageDetailDto> GetProductImageByIDAsync(string productImageID);
    }
}
