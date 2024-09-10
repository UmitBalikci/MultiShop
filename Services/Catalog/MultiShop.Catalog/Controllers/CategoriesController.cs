using Amazon.Runtime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _ICategoryService;

        public CategoriesController(ICategoryService ICategoryService)
        {
            _ICategoryService = ICategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _ICategoryService.GetAllCategoryAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByCategoryID(string id)
        {
            var result = await _ICategoryService.GetCategoryByIDAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryCreateDto model)
        {
            await _ICategoryService.CreateCategoryAsync(model);

            return Ok("Başarılı..");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto model)
        {
            await _ICategoryService.UpdateCategoryAsync(model);

            return Ok("BAşarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _ICategoryService.DeleteCategoryAsync(id);

            return Ok("BAşarılı");
        }
    }
}
