using vetFoodShop.Catalog.Dtos.CategoryDtos;
using vetFoodShop.Catalog.Dtos.ProductImagesDtos;
using vetFoodShop.Catalog.Dtos.ProductImagesDtos;

namespace vetFoodShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GettAllProductImageAsync();
        Task CreateProductDetailAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductDetailAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    }
}
