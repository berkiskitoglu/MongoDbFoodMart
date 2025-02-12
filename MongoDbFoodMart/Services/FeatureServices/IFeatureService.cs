using MongoDbFoodMart.Dtos.FeatureDtos;

namespace MongoDbFoodMart.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string featureID);
        Task<GetByIDFeatureDto> GetByIDFeatureAsync(string featureID);
    }
}
