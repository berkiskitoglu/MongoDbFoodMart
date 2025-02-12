namespace MongoDbFoodMart.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryID { get; set; }
    }
}
