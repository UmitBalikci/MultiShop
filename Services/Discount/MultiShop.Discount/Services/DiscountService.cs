using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateDiscountCouponAsync(DiscountCouponCreateDto couponCreateDto)
        {
            string query = "insert into Coupons(CouponID, Code, Rate, IsActive, ValidDate) Values(@CouponID, @Code, @Rate, @IsActive, @ValidDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", Guid.NewGuid());
            parameters.Add("@Code", couponCreateDto.Code);
            parameters.Add("@Rate", couponCreateDto.Rate);
            parameters.Add("@IsActive", couponCreateDto.IsActive);
            parameters.Add("@ValidDate", couponCreateDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(Guid couponID)
        {
            string query = "Delete From Coupons Where CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", couponID);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<DiscountCouponResultDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";

            using(var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<DiscountCouponResultDto>(query);

                return values.ToList();
            }
        }

        public async Task<DiscountCouponDetailDto> GetDiscountCouponDetailAsync(Guid couponID)
        {
            string query = "Select * From Coupons Where CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", couponID);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<DiscountCouponDetailDto>(query, parameters);

                return value;
            }
        }

        public async Task UpdateDiscountCouponAsync(DiscountCouponUpdateDto couponUpdateDto)
        {
            string query = "Update Coupons Set Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate where CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", couponUpdateDto.CouponID);
            parameters.Add("@Code", couponUpdateDto.Code);
            parameters.Add("@Rate", couponUpdateDto.Rate);
            parameters.Add("@IsActive", couponUpdateDto.IsActive);
            parameters.Add("@ValidDate", couponUpdateDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
