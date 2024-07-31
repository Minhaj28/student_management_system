using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AssignedTeacher
    {
        public int AssignedTeacherId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public AssignedTeacher() { }
        public AssignedTeacher(int teacherId, int courseId)
        {
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}
