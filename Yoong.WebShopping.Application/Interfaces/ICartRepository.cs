using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;
using Yoong.WebShopping.Application.Models;

namespace Yoong.WebShopping.Application.Interfaces
{
    public interface ICartRepository
    {
        public Task AddToCart(Guid userId, Guid prodId, int quatity);
        public Task DeleteCartItem(Guid cartId);
        public Task UpdateQuatity(Guid cartId, int quatity);
        public Task<List<CartModel>> getByUserId(Guid userId);
    }
}
