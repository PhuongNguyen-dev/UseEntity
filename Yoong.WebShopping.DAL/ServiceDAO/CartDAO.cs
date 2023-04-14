using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;
using Yoong.WebShopping.DAO.InterfacesDAO;

namespace Yoong.WebShopping.DAO.ServiceDAO
{
    public class CartDAO : ICartDAO
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public CartDAO(WebShopContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Cart> GetByUserID(Guid userId)
        {
            return _context.carts!
                .Include(p => p.Product)
                .Where(c => c.UserId == userId);
                //;
        }
        public Task<Cart?> GetByID(Guid cartId)
        {
            return _context.carts!.FirstOrDefaultAsync(p => p.CartID == cartId);
        }
        public Task<Cart?> GetBy(Guid userId, Guid prodId)
        {
            return _context.carts!.AsQueryable()
                                .Where(c => c.ProductID == prodId)
                                .Where(c => c.UserId == userId)
                                                            .FirstOrDefaultAsync();
        }
        public void CreateCart(Cart cart)
        {
            _context.carts.Add(cart);
            _context.SaveChanges();
        }
        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        public async Task DeleteCart(Cart cart)
        {
            _context.Remove(cart);
            await _context.SaveChangesAsync();

        }

        

    }
}
