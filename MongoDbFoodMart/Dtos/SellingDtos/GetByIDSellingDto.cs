namespace MongoDbFoodMart.Dtos.SellingDtos
{
    public class GetByIDSellingDto
    {
        public string SellingID { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SellingDate { get; set; }
        public string ProductID { get; set; }
    }
}
