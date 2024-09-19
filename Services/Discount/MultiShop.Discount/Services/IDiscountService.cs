using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<DiscountCouponResultDto>> GetAllDiscountCouponAsync();
        Task<DiscountCouponDetailDto> GetDiscountCouponDetailAsync(Guid couponID);
        Task CreateDiscountCouponAsync(DiscountCouponCreateDto couponCreateDto);
        Task UpdateDiscountCouponAsync(DiscountCouponUpdateDto couponUpdateDto);
        Task DeleteDiscountCouponAsync(Guid couponID);
    }
}
