using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IUserActions
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void AddUser(User user);
        public void UpdateUser(int id, User user);
        public void DeleteUser(int id);
        
    }
}
