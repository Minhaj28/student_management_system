using BLL.Interfaces;
using DAL.ORM;
using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private UserAction _userAction;

        public UserService(UserAction userAction)
        {
            _userAction = userAction;
        }
        public List<User> GetAllUsers()
        {
            return _userAction.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userAction.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userAction.AddUser(user);
        }

        public void UpdateUser(int id, User user)
        {
            _userAction.UpdateUser(id, user);
        }

        public void DeleteUser(int id)
        {
           _userAction.DeleteUser(id);
        }

        public List<User> SearchUser(string value)
        {
            List<User> users = _userAction.GetAllUsers();
            return users.Where(u =>
                (u.UserId.ToString().Contains(value)) ||
                (u.UserName.ToLower().Contains(value)) ||
                (u.UserPassword.ToLower().Contains(value)) 
            ).ToList();
        }

    }
}
