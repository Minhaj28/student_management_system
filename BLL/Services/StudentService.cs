using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLL.Interfaces;
using DAL.ORM;
using Domain.Classes;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private StudentAction _studentAction;

        public StudentService(StudentAction studentAction)
        {
            _studentAction = studentAction;
        }
        public void EnrollInCourse(Student student, Course course)
        {
            throw new NotImplementedException();
        }

        public void ViewGrades(Student student)
        {
            throw new NotImplementedException();
        }

        public void GiveAttendance()
        {
            Console.WriteLine("Give attendance.");
        }

        public void GiveExam()
        {
            Console.WriteLine("Give exam.");
        }

        public List<Student> GetAllStudents()
        {
            return _studentAction.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _studentAction.GetStudentById(id);
        }

        public void CreateStudent(Student student)
        {
            _studentAction.AddStudent(student);
        }

        public void UpdateStudent(int id, Student student)
        {
            _studentAction.UpdateStudent(id, student);
        }

        public void DeleteStudent(int id)
        {
            _studentAction.DeleteStudent(id);
        }

        public List<Student> SearchStudents(string value)
        {
            List<Student> students = _studentAction.GetAllStudents();
            return students.Where(s =>
                (s.StudentID.ToString().ToLower().Contains(value)) ||
                (s.Name.ToString().ToLower().Contains(value)) ||
                (s.Address.ToString().ToLower().Contains(value)) ||
                (s.Email.ToString().ToLower().Contains(value)) ||
                (s.PhoneNumber.ToString().ToLower().Contains(value)) ||
                (s.Level.ToString().ToLower().Contains(value)) ||
                (s.GPA.ToString().ToLower().Contains(value)) 
            ).ToList();
        }

        
    }
}
