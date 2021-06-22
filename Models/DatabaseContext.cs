using Microsoft.EntityFrameworkCore;

namespace WorkShop4.Models
{
     public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Client> Clients {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}