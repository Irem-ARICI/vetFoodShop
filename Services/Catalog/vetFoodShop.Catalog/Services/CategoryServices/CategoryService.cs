using AutoMapper;
using MongoDB.Driver;
using vetFoodShop.Catalog.Dtos.CategoryDtos;
using vetFoodShop.Catalog.Entities;
using vetFoodShop.Catalog.Services.CategoryServices;
using vetFoodShop.Catalog.Settings;

namespace vetFoodShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;   // _mapper = mapper; --> adam böyle yaptı da neyyseğ (this.mapper = mapper; ) bendeki buydu
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            // throw new NotImplementedException();
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }


        public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
        {
            var values = await _categoryCollection.Find<Category>(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
