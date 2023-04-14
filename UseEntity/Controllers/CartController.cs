using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseEntity.Entities;
using UseEntity.Interfaces;
using Yoong.WebShopping.Application.Interfaces;
using Yoong.WebShopping.Application.Models;

namespace Yoong.WebShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;
        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        //---------------------

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(Guid userId, Guid prodId, int quatity)
        {
            await _cartRepo.AddToCart(userId, prodId, quatity);

            return Created("", null);
        }

        [HttpPut("UpdateQuatity")]
        public async Task UpdateQuatity(Guid cartId, int quatity)
        {
           await _cartRepo.UpdateQuatity(cartId,quatity);
        }


        [HttpGet("GetMyCart")]
        public async Task<List<CartModel>> GetMyCart(Guid userId)
        {
            return await _cartRepo.getByUserId(userId);
        }
    }
}
