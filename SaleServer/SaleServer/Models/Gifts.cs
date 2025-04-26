using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace SaleServer.Models
{
    public class Gifts
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int ticketPrice { get; set; } = 10;
        public string category { get; set; }
        public  int  donorId { get; set; }
        public string imageUrl { get; set; }


       public Donor? donor { get; set; }


    }
}
