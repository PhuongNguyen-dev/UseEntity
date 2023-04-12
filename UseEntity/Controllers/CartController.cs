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
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(Guid userId, Guid prodid, int quatity)
        {
            await _cartRepo.AddToCart(userId, prodid, quatity);

            return Created("", null);
        }

        [HttpPost("UpdateToCart")]
        public async Task<IActionResult> UpdateToCart(Guid userId, Guid prodid, int quatity)
        {
            await _cartRepo.UpdateToCart(userId, prodid, quatity);

            return Created("", null);
        }

        //[HttpPost("GetByUserId")]
        //public async Task<List<CartModel>> GetByUserID(Guid userId)
        //{
        //     return await _cartRepo.GetByUserID(userId);

        //}
        [HttpPost("getByUserId")]
        public async Task<CartModel> getByUserId(Guid userId)
        {
            return await _cartRepo.getByUserId(userId);
        }
    }
}
