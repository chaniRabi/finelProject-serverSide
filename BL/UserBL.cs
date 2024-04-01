using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Models;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL _userDL;
        IMapper _mapper;

        public UserBL(IUserDL userDL, IMapper mapper)
        {
            _userDL = userDL;
            _mapper = mapper;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _userDL.GetUsers();
            return users;
        }
        public async Task<User> GetUserById(int id)
        {
            User currentUser = await _userDL.GetUserById(id);
            return currentUser;
        }

        public async Task<UserDTO> login(UserLoginDTO user)
        {
            User currentUser = await _userDL.login(user.Email, user.Password);
            if (currentUser == null || currentUser.Password != user.Password) { return null; }
            return _mapper.Map<UserDTO>(currentUser);
        }

        public async Task<UserDTO> AddUser(UserDTO user)
        {
            User u = _mapper.Map<User>(user);
            User isAdd = await _userDL.AddUser(u);
            UserDTO userDTO = _mapper.Map<UserDTO>(isAdd);
            return userDTO;
        }
        public async Task<bool> RemoveUser(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _userDL.RemoveUser(u);
            return isRmove;
        }

        public async Task<UserDTO> Update(UserDTO user, int id)
        {
            User u = _mapper.Map<User>(user);
            User updatedUser = await _userDL.Update(u, id);
            UserDTO userDTO = _mapper.Map<UserDTO>(updatedUser);

            return userDTO;

        }

    }
}
