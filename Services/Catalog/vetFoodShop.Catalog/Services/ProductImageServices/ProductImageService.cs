using AutoMapper;
using MongoDB.Driver;
using vetFoodShop.Catalog.Dtos.CategoryDtos;
using vetFoodShop.Catalog.Dtos.ProductImagesDtos;
//using vetFoodShop.Catalog.Dtos.ProductImageDtos;
using vetFoodShop.Catalog.Entities;
using vetFoodShop.Catalog.Services.CategoryServices;
using vetFoodShop.Catalog.Settings;

namespace vetFoodShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
            private readonly IMongoCollection<ProductImage> _ProductImageCollection;
            private readonly IMapper _mapper;

            public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
            {
                var client = new MongoClient(_databaseSettings.ConnectionString);
                var database = client.GetDatabase(_databaseSettings.DatabaseName);
                _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.CategoryCollectionName);
                _mapper = mapper;   // _mapper = mapper; --> adam böyle yaptı da neyyseğ (this.mapper = mapper; ) bendeki buydu
            }

        public Task CreateProductDetailAsync(CreateProductImageDto createProductImageDto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
            {
                // throw new NotImplementedException();
                var value = _mapper.Map<ProductImage>(createProductImageDto);
                await _ProductImageCollection.InsertOneAsync(value);
            }

            public async Task DeleteProductImageAsync(string id)
            {
                await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
            }

        public Task<GetByIdProductImageDto> GetByIdProductDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
            {
                var values = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
                return _mapper.Map<GetByIdProductImageDto>(values);
            }

            public async Task<List<ResultProductImageDto>> GettAllProductImageAsync()
            {
                var values = await _ProductImageCollection.Find(x => true).ToListAsync();
                return (_mapper.Map<List<ResultProductImageDto>>(values));
            }

            public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
            {
                var values = _mapper.Map<ProductImage>(updateProductImageDto);
                await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
            }
        
    }

}
