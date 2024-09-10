using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _IProductService;

        public ProductsController(IProductService IProductService)
        {
            _IProductService = IProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var result = await _IProductService.GetAllProductAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByProductID(string id)
        {
            var result = await _IProductService.GetProductByIDAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(ProductCreateDto model)
        {
            await _IProductService.CreateProductAsync(model);

            return Ok("Başarılı..");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto model)
        {
            await _IProductService.UpdateProductAsync(model);

            return Ok("Başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _IProductService.DeleteProductAsync(id);

            return Ok("Başarılı");
        }
    }
}
