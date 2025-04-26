using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleServer.Models
{
    public class Winner
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } 
        public int GiftId { get; set; }

        public Gifts Gift { get; set; }
    }
}
