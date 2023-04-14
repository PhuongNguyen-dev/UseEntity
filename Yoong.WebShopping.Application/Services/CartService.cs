using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;
using UseEntity.Interfaces;
using UseEntity.Models;
using Yoong.WebShopping.Application.Interfaces;
using Yoong.WebShopping.Application.Models;
using Yoong.WebShopping.DAO.InterfacesDAO;
using Yoong.WebShopping.DAO.ServiceDAO;

namespace Yoong.WebShopping.Application.Repositories
{

    public class CartService : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly ICartDAO _cartDAO;
        private readonly IProductRepository _prodRepo;
        private readonly IUserRepository _userRepo;

        public CartService(ICartDAO cartDAO, IMapper mapper, IProductRepository prodRepo,IUserRepository userRepo)
        {
            _cartDAO = cartDAO;
            _mapper = mapper;
            _prodRepo = prodRepo;
            _userRepo = userRepo;
        }


        public async Task AddToCart(Guid userId, Guid prodId, int quatity)
        {
            var prod = await _prodRepo.getProdAsync(prodId);
            var user = await _userRepo.getUserAsync(userId);
           

            if (prod == null) throw new Exception("Sai ProdID");
            if (user == null) throw new Exception("Sai UserID");
            if (userId == Guid.Empty) throw new Exception("Sai cu phap");
            if (prodId == Guid.Empty) throw new Exception("Sai cu phap");
            var cart = await _cartDAO.GetBy(userId, prodId);
            if (quatity <= 0)
            {
                throw new Exception("vui long nhap lon hon 0");
            }
            else
            {
                if (cart == null)
                {
                   
                    Cart cartNew = new Cart()
                    {
                        UserId = userId,
                        ProductID = prodId,
                        Quatity = quatity
                    };
                    _cartDAO.CreateCart(cartNew);
                }
                else
                {
                    cart.Quatity += quatity;
                    await _cartDAO.UpdateCart(cart);
                }
            }
        }

        public async Task DeleteCartItem(Guid cartId)
        {
            var deleteCart = await _cartDAO.GetByID(cartId);
            if (deleteCart != null)
            {
                await _cartDAO.DeleteCart(deleteCart);
            }
        }

        public async Task UpdateQuatity(Guid cartId, int quatity)
        {
            var cart = await _cartDAO.GetByID(cartId);
            if (cart == null) throw new Exception("Gio hang ko ton tai");
            if (quatity == 0) throw new Exception("Ranh ha m?");
            
          
            cart.Quatity += quatity;
            await this._cartDAO.UpdateCart(cart);
            if (cart.Quatity <= 0)
            {
                await this.DeleteCartItem(cartId);
            }
        }
        public async Task<List<CartModel>> getByUserId(Guid userId)
        {
            // Where
            // FirtOrDefaultAsync
            // ToListAsync
            // Include 
            // Count
            var user = await _userRepo.getUserAsync(userId);
            if (user == null) throw new Exception("Sai UserID");

            IEnumerable<Cart> carts = _cartDAO.GetByUserID(userId);
            List<CartModel> cartItems = new List<CartModel>();
            foreach (Cart cart in carts)
            {
                CartModel cartModel = new CartModel()
                {
                    Id = cart.CartID,
                    Quantity = cart.Quatity,
                    ProductName = cart.Product.ProductName,
                    Price = cart.Product.Price,
                    ProductImage = cart.Product.ImageUrl
                };
                cartItems.Add(cartModel);
            }
            return _mapper.Map<List<CartModel>>(cartItems);
        }


    }
}



//IEnumerable<Cart> carts = _cartDAO.GetByUserID(userId);
//List<CartModel> cartItems = new List<CartModel>();
//foreach (Cart cart in carts)
//{
//    ProductModel product = await _prodRepo.getProdAsync(cart.ProductID);
//    CartModel cartModel = new CartModel()
//    {
//        Id = cart.CartID,
//        Quantity = cart.Quatity,
//        ProductName = product.ProductName,
//        Price = product.Price,
//        ProductImage = product.ImageUrl
//    };
//    cartItems.Add(cartModel);
//}
//return cartItems;