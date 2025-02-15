using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.SellingDtos;
using MongoDbFoodMart.Entities;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.SellingServices
{
    public class SellingService : ISellingService
    {
        private readonly IMongoCollection<Selling> _sellingCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        public SellingService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sellingCollection = database.GetCollection<Selling>(_databaseSettings.SellingCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSellingAsync(CreateSellingDto createSellingDto)
        {
            var values =  _mapper.Map<Selling>(createSellingDto);
            await _sellingCollection.InsertOneAsync(values);
        }

        public async Task DeleteSellingAsync(string sellingID)
        {
             await _sellingCollection.DeleteOneAsync(x=>x.SellingID == sellingID);
        }

        public async Task<List<ResultSellingDto>> GetAllSellingAsync()
        {
            var values = await _sellingCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSellingDto>>(values);
        }

        public async Task<List<ResultSellingWithProductDto>> GetAllSellingsWithProductAsync()
        {
            var sellingList = await _sellingCollection.Find(x => true).ToListAsync();
            foreach (var item in sellingList)
            {
                item.Product = await _productCollection.Find(x => x.ProductID == item.ProductID).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultSellingWithProductDto>>(sellingList);

        }

        public async Task<GetByIDSellingDto> GetByIDSellingAsync(string sellingID)
        {
            var value = await _sellingCollection.Find(x => x.SellingID == sellingID).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDSellingDto>(value);
        }

        public async Task UpdateSellingAsync(UpdateSellingDto updateSellingDto)
        {
           var values = _mapper.Map<Selling>(updateSellingDto);
           await _sellingCollection.FindOneAndReplaceAsync(x=>x.SellingID == updateSellingDto.SellingID,values);
        }
    }
}
