using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }

        public Course(int courseID, string courseName, string description, string level)
        {
            CourseID = courseID;
            CourseName = courseName;
            Description = description;
            Level = level;
        }

    }
}
