using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class UserDL : IUserDL

    {
        public ShinestockContext _context;
        public UserDL(ShinestockContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            User current = await _context.Users.FindAsync(id);
            if (current.Id == id)
                return current;
            return null;
        }

        //public async Task<User> GetUserByEmail(string email)
        //{
        //    User currentUser = await _context.Users.FindAsync(email);
        //    if (currentUser.Email == email)
        //        return currentUser;
        //    return null;
        //}

        public async Task<User> login(string email, string password)
        {
            User currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return currentUser;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveUser(int id)
        {
            try
            {
                User currentUser = await _context.Users.SingleOrDefaultAsync(item => item.Id == id);
                if (currentUser == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Users.Remove(currentUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Update(User user, int id)
        {
            try
            {
                User current = await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
                if (current != null)
                {
                    current.Name = user.Name;
                    current.Address = user.Address;
                    current.Password = user.Password;
                    current.Phone = user.Phone;
                    current.Email = user.Email;

                    _context.Users.Update(current);
                    // _context.Entry(user).State = EntityState.Modified; //מעדכן את הדטהבייס
                    await _context.SaveChangesAsync();
                    return current;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
