using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }

        public Course()
        {
            
        }
        public Course(string courseName, string description, string level)
        {
            CourseName = courseName;
            Description = description;
            Level = level;
        }

    }
}
