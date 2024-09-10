using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _IProductDetailService;

        public ProductDetailsController(IProductDetailService IProductDetailService)
        {
            _IProductDetailService = IProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var result = await _IProductDetailService.GetAllProductDetailAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailByProductDetailID(string id)
        {
            var result = await _IProductDetailService.GetProductDetailByIDAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductDetail(ProductDetailCreateDto model)
        {
            await _IProductDetailService.CreateProductDetailAsync(model);

            return Ok("Başarılı..");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(ProductDetailUpdateDto model)
        {
            await _IProductDetailService.UpdateProductDetailAsync(model);

            return Ok("Başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _IProductDetailService.DeleteProductDetailAsync(id);

            return Ok("Başarılı");
        }
    }
}
