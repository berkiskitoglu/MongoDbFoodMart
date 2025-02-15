namespace MongoDbFoodMart.Dtos.DiscountDtos
{
    public class GetByIDDiscountDto
    {
        public string DiscountID { get; set; }
        public string ImageUrl { get; set; }
        public string Rate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
