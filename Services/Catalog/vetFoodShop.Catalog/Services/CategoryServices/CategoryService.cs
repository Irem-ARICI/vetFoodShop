using AutoMapper;
using MongoDB.Driver;
using vetFoodShop.Catalog.Dtos.CategoryDtos;
using vetFoodShop.Catalog.Entities;
using vetFoodShop.Catalog.Settings;

namespace vetFoodShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;   // _mapper = mapper; --> adam böyle yaptı da neyyseğ (this.mapper = mapper; ) bendeki buydu
        }

        public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
            // var value = _mapper.Map<Category>(createCategoryDto);
            // await
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GettAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
