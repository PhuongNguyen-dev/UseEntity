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
    public class UserDAO : IUserDAO
    {
        private readonly IMapper _mapper;
        private readonly WebShopContext _context;
        public UserDAO(WebShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public Task<User?> GetByID(Guid userId)
        {
            return _context.Users!.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task DeleteUser(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users!.ToListAsync();
        }
    }
}
