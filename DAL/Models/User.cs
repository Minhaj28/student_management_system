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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public User(int userId, string name, string address, string email, string phoneNumber)
        {
            UserId = userId;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        
    }
}
