using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _IProductImageService;

        public ProductImagesController(IProductImageService IProductImageService)
        {
            _IProductImageService = IProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var result = await _IProductImageService.GetAllProductImageAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByProductImageID(string id)
        {
            var result = await _IProductImageService.GetProductImageByIDAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductImage(ProductImageCreateDto model)
        {
            await _IProductImageService.CreateProductImageAsync(model);

            return Ok("Başarılı..");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(ProductImageUpdateDto model)
        {
            await _IProductImageService.UpdateProductImageAsync(model);

            return Ok("Başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _IProductImageService.DeleteProductImageAsync(id);

            return Ok("Başarılı");
        }
    }
}
