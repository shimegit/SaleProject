using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SaleServer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List <Gifts> orderItems { get; set; }
    }
}
