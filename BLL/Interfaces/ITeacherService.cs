using DAL.Models;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        void ManageCourses();
        public void TakeAttendance(Attendance attendance);
        void GradeStudents();
        void SuperviseResearch();
        public void TakeExam(Exam exam);
        public void AssignedTeacher(AssignedTeacher assignedTeacher);
        public List<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);
        public void CreateTeacher(Teacher teacher);
        public void UpdateTeacher(int id, Teacher teacher);

        public void DeleteTeacher(int id);
    }
}
