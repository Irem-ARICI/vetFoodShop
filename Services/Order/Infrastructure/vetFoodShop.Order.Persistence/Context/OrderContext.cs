using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Order.Domain.Entities;

namespace vetFoodShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // bunu yazmak için=> override on.. yazınca çıkıyor :))
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=vetFoodShopOrderDb;User=sa;Password=0123456789aA*;TrustServerCertificate=True"); // ;integrated Security=true
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    // 41. video gg :((
        public DbSet<Ordering> Orderings { get; set; }
    }
}
