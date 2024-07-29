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
        void UpdateAttendance();
        void GradeStudents();
        void SuperviseResearch();
        void TakeExam();
        public List<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);
        public void CreateTeacher(Teacher teacher);
        public void UpdateTeacher(int id, Teacher teacher);

        public void DeleteTeacher(int id);
    }
}
