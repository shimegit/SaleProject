using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleServer.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GiftId { get; set; }
        public int Quantity { get; set; } = 1;

        public User User { get; set; }

        public Gifts Gift { get; set; }
    }
}
