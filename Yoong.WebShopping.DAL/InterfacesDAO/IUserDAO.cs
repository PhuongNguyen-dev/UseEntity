using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseEntity.Entities;

namespace Yoong.WebShopping.DAO.InterfacesDAO
{
    public interface IUserDAO
    {
        public void CreateUser(User user);
        public Task<User?> GetByID(Guid userId);
        public Task DeleteUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<List<User>> GetAll();

    }
}
