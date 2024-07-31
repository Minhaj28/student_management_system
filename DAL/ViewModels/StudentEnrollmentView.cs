using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class StudentEnrollmentView
    {
        public int StudentEnrollmentId { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }

        public StudentEnrollmentView() { }
        public StudentEnrollmentView(string name, string courseName)
        {
            Name = name;
            CourseName = courseName;
        }
    }
}
