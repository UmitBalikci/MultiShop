using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productMongoCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _productMongoCollection = database.GetCollection<Product>(databaseSetting.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<ProductDetailDto> GetProductByIDAsync(string productID)
        {
            var value = await _productMongoCollection.Find<Product>(x => x.ProductID == productID).FirstOrDefaultAsync();

            return _mapper.Map<ProductDetailDto>(value);
        }

        public async Task<List<ProductResultDto>> GetAllProductAsync()
        {
            var values = await _productMongoCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ProductResultDto>>(values);
        }

        public async Task CreateProductAsync(ProductCreateDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);

            await _productMongoCollection.InsertOneAsync(value);
        }

        public async Task UpdateProductAsync(ProductUpdateDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);

            await _productMongoCollection.FindOneAndReplaceAsync(x => x.ProductID ==  updateProductDto.ProductID, value);
        }

        public async Task DeleteProductAsync(string productID)
        {
            await _productMongoCollection.DeleteOneAsync(x => x.ProductID == productID);
        }
    }
}
