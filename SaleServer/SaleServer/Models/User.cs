using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Net;
using System.Numerics;
using System.Text.Json.Serialization;

namespace SaleServer.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [PasswordPropertyText]
        [Unicode]
        public string Password { get; set; }

        public string address { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [JsonIgnore]
        public string Roles { get; set; }

        [JsonIgnore]
        public List<Cart> ?Carts { get; set; }  = new List<Cart>();
        [JsonIgnore]
        public List<Order>? orders { get; set; } = new List<Order>();

        public User(string Password, string UserName)
        {
            this.Password   = Password;
            this.UserName = UserName;
        }
        public User()
        {

        }
    }


}
