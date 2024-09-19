using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult> DiscountCouponList()
        {
            var result = _discountService.GetAllDiscountCouponAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDiscountCouponByID(Guid id)
        {
            var result = _discountService.GetDiscountCouponDetailAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiscountCoupon(DiscountCouponCreateDto createCouponDtos)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDtos);

            return Ok("İşlem Başarılı!!");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDiscountCoupon(DiscountCouponUpdateDto updateDiscountCouponDtos)
        {
            await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDtos);

            return Ok("işlem Başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscountCoupon(Guid id) 
        {
            await _discountService.DeleteDiscountCouponAsync(id);

            return Ok("Silme işlemi başarılı");
        }
    }
}
