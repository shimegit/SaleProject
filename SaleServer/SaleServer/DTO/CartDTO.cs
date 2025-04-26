namespace SaleServer.DTO
{
    public class CartDTO
    {
        public int UserId { get; set; }
        public int GiftId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
