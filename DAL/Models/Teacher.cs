using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
     public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }


        public Teacher() { }
        public Teacher(string name, string address, string email, string phoneNumber, string department, string designation)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            Department = department;
            Designation = designation;
        }

    }
}
