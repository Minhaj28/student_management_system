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

        public void UpdateUser(User user)
        {
            _userAction.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
           _userAction.DeleteUser(id);
        }

        public List<User> SearchUser(string attribute, string value)
        {
            List<User> users = _userAction.GetAllUsers();
            return users.Where(u =>
                (attribute.ToLower() == "id" && u.UserId.ToString().Contains(value)) ||
                (attribute.ToLower() == "name" && u.Name.ToLower().Contains(value)) ||
                (attribute.ToLower() == "address" && u.Address.ToLower().Contains(value)) ||
                (attribute.ToLower() == "email" && u.Email.ToLower().Contains(value)) ||
                (attribute.ToLower() == "phonenumber" && u.PhoneNumber.ToLower().Contains(value))
            ).ToList();
        }

    }
}
