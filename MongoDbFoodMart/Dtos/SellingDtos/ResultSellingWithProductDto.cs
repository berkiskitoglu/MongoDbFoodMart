namespace MongoDbFoodMart.Dtos.SellingDtos
{
    public class ResultSellingWithProductDto
    {
        public string SellingID { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SellingDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
