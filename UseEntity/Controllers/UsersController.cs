using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseEntity.Interfaces;
using UseEntity.Models;

namespace UseEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _UserRepo;
        public UsersController(IUserRepository userRepo)
        {
            _UserRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            
            return  Ok(await _UserRepo.getAllUserAsync());
           
            
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserBy(Guid userId)
        {
            var user = await _UserRepo.getUserAsync(userId);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserModel model)
        {
            var newUser = await _UserRepo.AddUserAsync(model);
            var user = await _UserRepo.getUserAsync(newUser);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            await _UserRepo.UpdateUserAsync(model);
            return Ok();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser( Guid userId)
        {
            await _UserRepo.DeleteUserAsync(userId);
            return Ok();
        }
    }
}
