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
        //public Task<List<CartModel>> GetByUserID(Guid userId);
        public Task AddToCart(Guid userId, Guid prodid, int quatity);
        public Task UpdateToCart(Guid userId, Guid prodid, int quatity);
        public Task<CartModel> getByUserId(Guid userId);

    }
}
