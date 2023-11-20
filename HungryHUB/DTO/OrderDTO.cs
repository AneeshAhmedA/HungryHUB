namespace HungryHUB.DTO
{
    public class OrderDTO
    {

        public string OrderId { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
