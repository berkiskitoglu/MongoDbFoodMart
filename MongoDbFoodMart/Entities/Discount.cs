using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbFoodMart.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountID { get; set; }
        public string ImageUrl { get; set; }
        public string Rate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
