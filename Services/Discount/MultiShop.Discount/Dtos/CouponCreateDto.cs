﻿namespace MultiShop.Discount.Dtos
{
    public class CouponCreateDto
    {
        public string Code { get; set; }
        public int? Rate { get; set; }
        public bool? IsActive { get; set; }
        public DateOnly? ValidDate { get; set; }
    }
}
