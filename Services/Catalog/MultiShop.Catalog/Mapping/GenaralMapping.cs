using AutoMapper;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GenaralMapping : Profile
    {
        public GenaralMapping() 
        {
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            CreateMap<Category, CategoryDetailDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<Product, ProductResultDto>().ReverseMap();
            CreateMap<Product, ProductDetailDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<ProductDetail, ProductDetailResultDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailCreateDto>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailUpdateDto>().ReverseMap();

            CreateMap<ProductImage, ProductImageResultDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDetailDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageCreateDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageUpdateDto>().ReverseMap();
        }
    }
}
