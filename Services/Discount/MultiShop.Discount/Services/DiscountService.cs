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
        public async Task CreateCouponAsync(CouponCreateDto couponCreateDto)
        {
            string query = "insert into Coupons(CouponID, Code, Rate, IsActive, ValidDate) Values(@CouponID, @Code, @Rate, @IsActive, @ValidDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@Code", couponCreateDto.Code);
            parameters.Add("@Rate", couponCreateDto.Rate);
            parameters.Add("@IsActive", couponCreateDto.IsActive);
            parameters.Add("@ValidDate", couponCreateDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(Guid couponID)
        {
            string query = "Delete From Coupon Where CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", couponID);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<CouponResultDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";

            using(var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<CouponResultDto>(query);

                return values.ToList();
            }
        }

        public async Task<CouponDetailDto> GetCouponDetailAsync(Guid couponID)
        {
            string query = "Select * From Coupons Where CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", couponID);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<CouponDetailDto>(query);

                return value;
            }
        }

        public async Task UpdateCouponAsync(CouponUpdateDto couponUpdateDto)
        {
            string query = "Update Coupons Set = Code= @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate";

            var parameters = new DynamicParameters();

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
