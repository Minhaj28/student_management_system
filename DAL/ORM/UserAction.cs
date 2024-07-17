using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.ORM
{
    public class UserAction : IUserActions
    {
        protected List<User> users = new List<User>();

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.UserId == id);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            User existingUser = GetUserById(user.UserId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
            }
        }

        public void DeleteUser(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
   
    
}
