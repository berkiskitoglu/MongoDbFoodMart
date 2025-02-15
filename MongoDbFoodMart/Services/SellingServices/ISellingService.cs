using MongoDbFoodMart.Dtos.SellingDtos;

namespace MongoDbFoodMart.Services.SellingServices
{
    public interface ISellingService
    {
        Task<List<ResultSellingDto>> GetAllSellingAsync();
        Task<List<ResultSellingWithProductDto>> GetAllSellingsWithProductAsync();
        Task CreateSellingAsync(CreateSellingDto createSellingDto);
        Task UpdateSellingAsync(UpdateSellingDto updateSellingDto);
        Task DeleteSellingAsync(string sellingID);
        Task<GetByIDSellingDto> GetByIDSellingAsync(string sellingID);
    }
}
