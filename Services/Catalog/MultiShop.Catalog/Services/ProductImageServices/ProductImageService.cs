using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageMongoCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _ProductImageMongoCollection = database.GetCollection<ProductImage>(databaseSetting.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task<ProductImageDetailDto> GetProductImageByIDAsync(string productImageID)
        {
            var value = await _ProductImageMongoCollection.Find<ProductImage>(x => x.ProductImageID == productImageID).FirstOrDefaultAsync();

            return _mapper.Map<ProductImageDetailDto>(value);
        }

        public async Task<List<ProductImageResultDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageMongoCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ProductImageResultDto>>(values);
        }

        public async Task CreateProductImageAsync(ProductImageCreateDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);

            await _ProductImageMongoCollection.InsertOneAsync(value);
        }

        public async Task UpdateProductImageAsync(ProductImageUpdateDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);

            await _ProductImageMongoCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, value);
        }

        public async Task DeleteProductImageAsync(string ProductImageID)
        {
            await _ProductImageMongoCollection.DeleteOneAsync(x => x.ProductImageID == ProductImageID);
        }
    }
}
