using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class AssignedTeacherView
    {
        public int AssignedTeacherId { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }

        public AssignedTeacherView() { }
        public AssignedTeacherView(string name, string courseName)
        {
            Name = name;
            CourseName = courseName;
        }
    }
}
