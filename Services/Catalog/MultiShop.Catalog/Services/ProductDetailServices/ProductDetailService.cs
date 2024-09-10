using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailMongoCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _ProductDetailMongoCollection = database.GetCollection<ProductDetail>(databaseSetting.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<ProductDetailDetailDto> GetProductDetailByIDAsync(string productDetailID)
        {
            var value = await _ProductDetailMongoCollection.Find<ProductDetail>(x => x.ProductDetailID == productDetailID).FirstOrDefaultAsync();

            return _mapper.Map<ProductDetailDetailDto>(value);
        }

        public async Task<List<ProductDetailResultDto>> GetAllProductDetailAsync()
        {
            var values = await _ProductDetailMongoCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ProductDetailResultDto>>(values);
        }

        public async Task CreateProductDetailAsync(ProductDetailCreateDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);

            await _ProductDetailMongoCollection.InsertOneAsync(value);
        }

        public async Task UpdateProductDetailAsync(ProductDetailUpdateDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);

            await _ProductDetailMongoCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }

        public async Task DeleteProductDetailAsync(string productDetailID)
        {
            await _ProductDetailMongoCollection.DeleteOneAsync(x => x.ProductDetailID == productDetailID);
        }
    }
}
