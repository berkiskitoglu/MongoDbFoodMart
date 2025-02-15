using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbFoodMart.Dtos.SellingDtos
{
    public class CreateSellingDto
    {
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SellingDate { get; set; }
        public string ProductID { get; set; }
    }
}
