using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Student 
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Level { get; set; }
        public string GPA { get; set; }

        public Student () { }
       public Student(string name, string address, string email, string phoneNumber, string level, string gpa) {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            Level = level;
            GPA = gpa;
        }

       
    }
}
