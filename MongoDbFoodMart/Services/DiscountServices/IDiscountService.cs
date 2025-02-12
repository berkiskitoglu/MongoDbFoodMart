using MongoDbFoodMart.Dtos.DiscountDtos;

namespace MongoDbFoodMart.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string discountID);
        Task<GetByIDDiscountDto> GetByIDDiscountAsync(string discountID);
    }
}
