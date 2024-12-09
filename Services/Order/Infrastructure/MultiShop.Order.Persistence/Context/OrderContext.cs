using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...;Initial Catalog=MultiShopOrderDb;Integrated Security=true;");
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Ordering> Ordering { get; set; }
    }
}
