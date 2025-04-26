using System.Text.Json.Serialization;

namespace SaleServer.Models
{
    public class Donation
    {
        [JsonIgnore]
        public int DonationId { get; set; }
        
        public int GiftId { get; set; }
        [JsonIgnore]
        public Gifts Gift { get; set; }
        [JsonIgnore]
        public int DonorId { get; set; }
        [JsonIgnore]
        public Donor Donor { get; set; }
    }
}
