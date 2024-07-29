using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain.Classes
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
   
        public User() { }
        public User(string userName, string userPassword)
        {
            UserName = userName;
            UserPassword = userPassword;
        }

        
    }
}
