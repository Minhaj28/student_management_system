using BLL.Interfaces;
using DAL.ORM;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private TeacherAction _teacherAction;

        public TeacherService(TeacherAction teacherAction)
        {
            _teacherAction = teacherAction;
        }
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
            Console.WriteLine($"Teacher  graded students.");
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
            return _teacherAction.GetAllTeachers();
        }

        public Teacher GetTeacherById(int id)
        {
            return _teacherAction.GetTeacherById(id);
        }

        public void CreateTeacher(Teacher teacher)
        {
            _teacherAction.AddTeacher(teacher);
        }

        public void UpdateTeacher(int id, Teacher teacher)
        {
            _teacherAction.UpdateTeacher(id, teacher);
        }

        public void DeleteTeacher(int id)
        {
            _teacherAction.DeleteTeacher(id);
        }

        public List<Teacher> SearchTeachers(string value)
        {
            List<Teacher> teachers = _teacherAction.GetAllTeachers();
            return teachers.Where(t =>
                (t.TeacherId.ToString().Contains(value)) ||
                (t.Name.ToLower().Contains(value)) ||
                (t.Address.ToString().ToLower().Contains(value)) ||
                (t.Email.ToString().ToLower().Contains(value)) ||
                (t.PhoneNumber.ToString().ToLower().Contains(value)) ||
                (t.Department.ToString().ToLower().Contains(value)) ||
                (t.Designation.ToString().ToLower().Contains(value))
            ).ToList();
        }
    }
}
