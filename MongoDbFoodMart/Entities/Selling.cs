using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbFoodMart.Entities
{
    public class Selling
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SellingID { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SellingDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    
    }
}
