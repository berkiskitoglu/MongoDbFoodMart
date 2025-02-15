namespace MongoDbFoodMart.Models
{
    public class MailRequest
    {
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
