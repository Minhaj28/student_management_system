using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EnrollmentService
    {
        public void EnrollStudent(Student student, Course course)
        {
            Console.WriteLine($"{student.Name} enrolled in {course.CourseName}");
            
        }

        public void CancelEnrollment(Student student, Course course)
        {
            Console.WriteLine($"{student.Name} enrollment in {course.CourseName} cancelled");
        }
    }
}
