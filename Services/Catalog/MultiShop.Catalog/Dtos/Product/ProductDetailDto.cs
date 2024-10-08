﻿namespace MultiShop.Catalog.Dtos.Product
{
    public class ProductDetailDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
    }
}
