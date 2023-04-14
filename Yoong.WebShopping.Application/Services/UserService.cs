using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Interfaces;
using UseEntity.Models;
using Yoong.WebShopping.Application.Models;
using Yoong.WebShopping.DAO.InterfacesDAO;
using Yoong.WebShopping.DAO.ServiceDAO;

namespace UseEntity.Repositories
{
    public class UserService : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IUserDAO _userDAO;
        public UserService(IUserDAO userDAO, IMapper mapper)
        {
            _userDAO = userDAO;
            _mapper = mapper;
        }
        public async Task<Guid> AddUserAsync(CreateUserModel model)
        {
            var newUser = _mapper.Map<User>(model);
            _userDAO.CreateUser(newUser);
            return newUser.UserId;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var deleteUser = await _userDAO.GetByID(userId);
            if (deleteUser != null)
            {
               await _userDAO.DeleteUser(deleteUser);
            }
        }

        public async Task<List<UserModel>> getAllUserAsync()
        {
            var users = await _userDAO.GetAll();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> getUserAsync(Guid userId)
        {
            var user = await _userDAO.GetByID(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateUserAsync(UserModel model)
        {
            var updateUser = _mapper.Map<User>(model);
            if (updateUser != null)
            {
                await _userDAO.UpdateUser(updateUser);
            }
            else
            {
                Console.WriteLine("ngiu vcd");
            }
        }

    }
}
