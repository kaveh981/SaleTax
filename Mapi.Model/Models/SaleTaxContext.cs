using System.Data.Entity;

namespace Mapi.Models
{
    public class SaleTaxContext : DbContext
    {
        public SaleTaxContext()
            : base("name=DefaultConnection") {
                Database.SetInitializer<SaleTaxContext>(new SaleTaxDatabaseInitializer());
        }    

        
        public DbSet<Article> Items { get; set; }

        public DbSet<ItemCategory> ItemCategoryies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}