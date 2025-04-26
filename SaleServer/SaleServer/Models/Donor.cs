using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SaleServer.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public static implicit operator Donor(User v)
        {
            throw new NotImplementedException();
        }
       
    }
}
