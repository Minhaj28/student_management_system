using DAL.ORM;
using DAL.ViewModels;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentEnrollmentService
    {
        private StudentEnrollmentAction _studentEnrollmentAction;

        public StudentEnrollmentService(StudentEnrollmentAction studentEnrollmentAction)
        {
            _studentEnrollmentAction = studentEnrollmentAction;
        }
        public void EnrollStudent(StudentEnrollment studentEnrollment)
        {
            _studentEnrollmentAction.EnrollStudent(studentEnrollment);
            
        }

        public void DeleteEnrollment(int studentEnrollmentId)
        {
            _studentEnrollmentAction.DeleteEnrollment(studentEnrollmentId);
        }

        public List<StudentEnrollment> GetStudentEnrollment()
        {
            return _studentEnrollmentAction.GetAllStudentEnrollment();
        }

        public List<StudentEnrollmentView> GetStudentEnrollmentView()
        {
            return _studentEnrollmentAction.GetAllStudentEnrollmentView();
        }
    }
}
