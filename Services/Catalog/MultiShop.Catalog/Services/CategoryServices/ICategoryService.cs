using MultiShop.Catalog.Dtos.Category;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<CategoryResultDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CategoryCreateDto createCategoryDto);
        Task UpdateCategoryAsync(CategoryUpdateDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryID);
        Task<CategoryDetailDto> GetCategoryByIDAsync(string categoryID);
    }
}
