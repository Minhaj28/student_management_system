using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
       

        public void EnrollInCourse(Student student, Course course);
        public void ViewGrades(Student student);
        public void GiveAttendance();
        public void GiveExam();
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public void CreateStudent(Student student);
        public void UpdateStudent(int id, Student student);
        public void DeleteStudent(int id);
    }
}
