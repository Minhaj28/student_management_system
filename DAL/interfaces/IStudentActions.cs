using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IStudentActions
    {
        public void EnrollInCourse(Student student, Course course);
        public void ViewGrades(Student student);
        public void GiveAttendance();
        public void GiveExam();
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public void AddStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}
