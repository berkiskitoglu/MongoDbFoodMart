using MongoDbFoodMart.Dtos.ProductDtos;

namespace MongoDbFoodMart.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productID);
        Task<GetByIDProductDto> GetByIDProductAsync(string productID);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

        Task<List<ResultProductWithCategoryDto>> GetProductByCategoryIDAsync(string id);
    }
}
