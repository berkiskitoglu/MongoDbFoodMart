using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.ProductDtos;
using MongoDbFoodMart.Entities;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection <Category>(_databaseSettings.CategoryCollectionName);
            this._mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string productID)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == productID);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryID == item.CategoryID).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<GetByIDProductDto> GetByIDProductAsync(string productID)
        {
            var value = await _productCollection.Find(x => x.ProductID == productID).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByCategoryIDAsync(string id)
        {
            var values = await _productCollection.Find(x => x.CategoryID == id).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryID == id).FirstOrDefaultAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

       


        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductID == updateProductDto.ProductID,values);
        }
    }
}
