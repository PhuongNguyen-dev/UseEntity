using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;

namespace Yoong.WebShopping.DAO.InterfacesDAO
{
    public interface IProductDAO
    {
        public void CreateProduct(Product product);
        public Task<Product?> GetByID(Guid prodId);
        public Task<List<Product>> GetAll();
        public Task DeleteProd(Product product);
        public Task<Product> UpdateProd(Product product);

    }
}
