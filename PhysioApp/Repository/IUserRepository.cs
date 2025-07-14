using PhysioApp.Models;

namespace PhysioApp.Repository
{
    public interface IUserRepository
    {
        public Task<string> AddUsers(Users user);
        public Task<int> EditUsers(Users user);
        public Task<List<Users>> GetAllUsers();
        public Task<Users> GetUserById(int userId);
    }
}
