using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;

namespace Yoong.WebShopping.DAO
{
    internal class WebShopContextFactory : IDesignTimeDbContextFactory<WebShopContext>
    {
        public WebShopContext CreateDbContext(string[] args)
        {
            Console.WriteLine("All In webShope");
            var optionsBuilder = new DbContextOptionsBuilder<WebShopContext>();

        

            optionsBuilder.UseSqlServer("Data Source = DESKTOP-MLHK8LP\\MSSQLSERVER01; Initial Catalog = MyWebShop;Trusted_Connection=True;TrustServerCertificate=True;", option =>
            {
                
            });

            return new WebShopContext(optionsBuilder.Options);
        }
    }
}
