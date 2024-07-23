using DAL.Models;

namespace DAL
{
    public interface IUserDL
    {
      public  Task<User> AddUser(User user);
      public  Task<User> GetUserById(int id);
       public Task<List<User>> GetUsers();
       public Task<User> login(string email, string password);
       public Task<bool> RemoveUser(int id);
       public Task<User> Update(User user, int id);
    }
}