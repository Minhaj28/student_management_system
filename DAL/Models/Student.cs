using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Student : User
    {
        public int StudentID { get; set; }
        public string Level { get; set; }
        public string Gpa { get; set; }

        public Student(int userId, string name, string address, string email, string phoneNumber, int studentID, string level, string gpa)
            : base(userId, name, address, email, phoneNumber)
        {
            StudentID = studentID;
            Level = level;
            Gpa = gpa;
        }

       
    }
}
