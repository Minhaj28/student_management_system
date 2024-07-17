using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.ORM
{
    public class StudentAction : UserAction, IStudentActions
    {
        protected List<Student> students = new List<Student>();
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
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentID == id);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            AddUser(student);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = GetStudentById(student.StudentID);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Level = student.Level;
                existingStudent.Gpa = student.Gpa;
                UpdateUser(existingStudent);
            }
        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
                DeleteUser(id);
            }
        }

       
    }
}
