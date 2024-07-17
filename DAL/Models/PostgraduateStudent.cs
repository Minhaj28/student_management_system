﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class PostgraduateStudent : Student
    {
        public PostgraduateStudent(int userId, string name, string address, string email, string phoneNumber, int studentID, string level, string gpa)
            : base(userId, name, address, email, phoneNumber, studentID, "Postgraduate", gpa) { }

    }
}
