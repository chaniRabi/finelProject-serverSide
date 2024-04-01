using DAL.Models;

namespace DAL
{
    public interface IUserDL
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<User> login(string email, string password);
        Task<bool> RemoveUser(int id);
        Task<User> Update(User user, int id);
    }
}