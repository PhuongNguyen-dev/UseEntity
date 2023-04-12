using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Interfaces;
using UseEntity.Models;

namespace UseEntity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public UserRepository(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddUserAsync(UserModel model)
        {
            var newUser = _mapper.Map<User>(model);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.UserId;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var deleteUser = _context.Users.SingleOrDefault(x => x.UserId == userId);
            if (deleteUser != null)
            {
                _context.Users.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserModel>> getAllUserAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> getUserAsync(Guid userId)
        {
            var user = await _context.Users!.FindAsync(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateUserAsync(UserModel model)
        {
            var updateUser = _mapper.Map<User>(model);
            if (updateUser != null)
            {
                _context.Users.Update(updateUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("ngiu vcd");
            }
        }

    }
}
