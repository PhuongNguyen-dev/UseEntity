using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;

namespace Yoong.WebShopping.DAO.InterfacesDAO
{
    public interface ICartDAO
    {
        public Task DeleteCart(Cart cart);
        public Task<Cart?> GetByID(Guid cartId);
        public Task<Cart> GetBy(Guid userId, Guid prodId);
        public void CreateCart(Cart cart);
        public  Task<Cart> UpdateCart(Cart cart);
        public IEnumerable<Cart> GetByUserID(Guid userId);

    }
}
