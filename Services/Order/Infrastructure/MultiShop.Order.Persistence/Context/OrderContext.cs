using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 1440;Initial Catalog=MultiShopOrderDb;User=sa;Password=123456qA.;TrustServerCertificate=true;");
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Ordering> Ordering { get; set; }
    }
}
