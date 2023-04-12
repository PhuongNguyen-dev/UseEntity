using UseEntity.Models;

namespace UseEntity.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> getAllUserAsync();
        public Task<UserModel> getUserAsync(Guid userId);
        public Task<Guid> AddUserAsync(UserModel model);
        public Task UpdateUserAsync(UserModel model);
        public Task DeleteUserAsync(Guid userId);
    }
}
