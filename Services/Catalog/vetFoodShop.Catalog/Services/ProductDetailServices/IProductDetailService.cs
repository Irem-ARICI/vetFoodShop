using vetFoodShop.Catalog.Dtos.ProductDetailDtos;

namespace vetFoodShop.Catalog.Services.ProductDetailDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GettAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
