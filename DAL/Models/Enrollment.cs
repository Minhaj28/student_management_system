using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Enrollment(int enrollmentID, int studentID, int courseID)
        {
            EnrollmentID = enrollmentID;
            StudentID = studentID;
            CourseID = courseID;
        }

       
    }
}
