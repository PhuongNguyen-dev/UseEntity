using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;
using UseEntity.Models;
using Yoong.WebShopping.Application.Interfaces;
using Yoong.WebShopping.Application.Models;

namespace Yoong.WebShopping.Application.Repositories
{

    public class CartRepository : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public CartRepository(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddToCart(Guid userId, Guid prodid, int quatity)
        {
            if (quatity > 0)
            {
                var cart = await _context.carts.AsQueryable()
                                .Where(c => c.ProductID == prodid)
                                .Where(c => c.UserId == userId)
                                                            .FirstOrDefaultAsync();
                if (cart == null)
                {
                    Cart cartNew = new Cart()
                    {
                        UserId = userId,
                        ProductID = prodid,
                        Quatity = quatity
                    };
                    _context.carts.Add(cartNew);
                }
                else
                {
                    cart.Quatity += quatity;
                    this._context.Update(cart);

                }

            }
            else
            {
                Console.WriteLine("kodchaku");

            }
            await this._context.SaveChangesAsync();
        
        }
        public async Task UpdateToCart(Guid userId, Guid prodid, int quatity)
        {
            if (quatity < 0)
            {
                var cart = await _context.carts.AsQueryable()
                                .Where(c => c.ProductID == prodid)
                                .Where(c => c.UserId == userId)
                                                            .FirstOrDefaultAsync();
                if (cart == null)
                {
                    Console.WriteLine("kodchaku");

                }
                else
                {
                    cart.Quatity += quatity;
                    this._context.Update(cart);
                }

            }
           
            await this._context.SaveChangesAsync();

        }

        //public async Task<List<CartModel>> GetByUserID(Guid userId)
        //{
        //    var cart = await _context.carts.AsQueryable()
        //                        .Where(c => c.ProductID == new Guid("8AA2006F-0983-47CE-60D3-08DB3A6434A6"))
        //                        .Where(c=> c.UserId==userId)
        //                                                    .FirstOrDefaultAsync();
        //    return new List<CartModel>()
        //    {
        //        new CartModel()
        //        {
        //            Id = cart.CartID
        //        }
        //    };
        //}

        
        public async Task<CartModel> getByUserId(Guid userId)
        {
            var cart = await _context.carts!.Where(c => c.UserId == userId)
                                                            .FirstOrDefaultAsync();
            CartModel cartNew = new CartModel()
            {
                Id = cart.CartID,
                Quantity = cart.Quatity,

            };
           
            return cartNew;
        }
    }
}
