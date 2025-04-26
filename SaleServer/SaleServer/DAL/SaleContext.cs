using Microsoft.EntityFrameworkCore;
using SaleServer.Models;

namespace SaleServer.DAL
{
    public class SaleContext : DbContext
    { 
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
        }
        public DbSet<Gifts> Gifts { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Winner> Winner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer("Data Source=DESKTOP-L9S4R74;Initial Catalog=sale;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Data Source=srv2\\pupils;Initial Catalog=sss;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
            //api_dataBaseNew
        }

    }
}
