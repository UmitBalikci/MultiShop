﻿namespace MultiShop.Discount.Dtos
{
    public class DiscountCouponUpdateDto
    {
        public Guid CouponID { get; set; }
        public string Code { get; set; }
        public int? Rate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ValidDate { get; set; }
    }
}
