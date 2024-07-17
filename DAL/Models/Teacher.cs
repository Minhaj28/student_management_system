using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Teacher : User
    {
        public int TeacherID { get; set; }

        public Teacher(int userId, string name, string address, string email, string phoneNumber, int teacherID)
            : base(userId, name, address, email, phoneNumber)
        {
            TeacherID = teacherID;
        }


    }
}
