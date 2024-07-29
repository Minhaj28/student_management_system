using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class StudentEnrollment
    {
        public int StudentEnrollmentId { get; set; }
        public int StudentID { get; set; }
        public int CourseId { get; set; }

        public StudentEnrollment() { }
        public StudentEnrollment(int studentID, int courseId)
        {
            StudentID = studentID;
            CourseId = courseId;
        }

       
    }
}
