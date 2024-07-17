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
    public class TeacherAction : UserAction, ITeacherActions
    {
        protected List<Teacher> teachers = new List<Teacher>();
        public void ManageCourses()
        {
            Console.WriteLine($"Teacher is managing courses.");
        }

        public void UpdateAttendance()
        {
            Console.WriteLine($"Teacher updated attendance.");
        }

        public void GradeStudents()
        {
            Console.WriteLine($"Teacher graded students.");
        }

        public void SuperviseResearch()
        {
            Console.WriteLine($"Teacher is supervising research.");
        }

        public void TakeExam()
        {
            Console.WriteLine($"Teacher is taking exam.");
        }

        public List<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            return teachers.FirstOrDefault(t => t.TeacherID == id);
        }

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
            AddUser(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var existingTeacher = GetTeacherById(teacher.TeacherID);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Email = teacher.Email;
                UpdateUser(existingTeacher);
            }
        }

        public void DeleteTeacher(int id)
        {
            var teacher = GetTeacherById(id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
                DeleteUser(id);
            }
        }
    }
}
