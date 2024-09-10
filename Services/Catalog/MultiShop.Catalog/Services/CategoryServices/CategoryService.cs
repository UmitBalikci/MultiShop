using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSetting.CategoryCollectionName);
            _mapper = mapper;
        }
        
        public async Task<CategoryDetailDto> GetCategoryByIDAsync(string categoryID)
        {
            var value = await _categoryCollection.Find<Category>(x => x.CategoryID == categoryID).FirstOrDefaultAsync();
            
            return _mapper.Map<CategoryDetailDto>(value);
        }

        public async Task<List<CategoryResultDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<CategoryResultDto>>(values);
        }

        public async Task CreateCategoryAsync(CategoryCreateDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);

            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);

            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, value);
        }

        public async Task DeleteCategoryAsync(string categoryID)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == categoryID);
        }
    }
}
