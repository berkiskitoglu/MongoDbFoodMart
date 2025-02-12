using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbFoodMart.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
