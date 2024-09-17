using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<CouponResultDto>> GetAllCouponAsync();
        Task<CouponDetailDto> GetCouponDetailAsync(Guid couponID);
        Task CreateCouponAsync(CouponCreateDto couponCreateDto);
        Task UpdateCouponAsync(CouponUpdateDto couponUpdateDto);
        Task DeleteCouponAsync(Guid couponID);
    }
}
