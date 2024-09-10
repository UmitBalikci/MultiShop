using MultiShop.Catalog.Dtos.ProductDetail;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ProductDetailResultDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(ProductDetailCreateDto createProductDetailDto);
        Task UpdateProductDetailAsync(ProductDetailUpdateDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string ProductDetailID);
        Task<ProductDetailDetailDto> GetProductDetailByIDAsync(string ProductDetailID);
    }
}
