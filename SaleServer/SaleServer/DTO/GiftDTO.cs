namespace SaleServer.DTO
{
    public class GiftDTO
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string imageUrl { get; set; }
      
        public int ticketPrice { get; set; } = 10;

        public string category { get; set; }

        public int ?donorId { get; set; }
    }
}
