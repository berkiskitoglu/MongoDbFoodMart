using MongoDbFoodMart.Dtos.CategoryDtos;

namespace MongoDbFoodMart.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task <List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryID);
        Task<GetByIDCategoryDto> GetByIDCategoryAsync(string categoryID);
    }
}
