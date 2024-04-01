using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface IUserBL
    {
        Task<UserDTO> AddUser(UserDTO user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<UserDTO> login(UserLoginDTO user);
        Task<bool> RemoveUser(int id);
        Task<UserDTO> Update(UserDTO user, int id);
    }
}