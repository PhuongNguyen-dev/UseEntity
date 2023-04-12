using Microsoft.EntityFrameworkCore;

namespace UseEntity.Entities
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions options) : base(options)
        {

        }
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> carts { get; set; }
        #endregion
    }
}
