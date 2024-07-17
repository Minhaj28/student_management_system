using DAL.ORM;
using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        private CourseAction _courseAction;

        public CourseService(CourseAction courseAction)
        {
            _courseAction = courseAction;
        }
        

        public List<Course> GetAllCourses()
        {
            return _courseAction.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseAction.GetCourseById(id);
        }

        public void CreateCourse(Course course)
        {
            _courseAction.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseAction.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseAction.DeleteCourse(id);
        }

        public List<Course> SearchCourses(string attribute, string value)
        {
            var courses = _courseAction.GetAllCourses();
            return courses.Where(c =>
                (attribute.ToLower() == "id" && c.CourseID.ToString().Contains(value)) ||
                (attribute.ToLower() == "name" && c.CourseName.ToLower().Contains(value)) ||
                (attribute.ToLower() == "description" && c.Description.ToLower().Contains(value)) ||
                (attribute.ToLower() == "level" && c.Level.ToLower().Contains(value))
            ).ToList();
        }
    }
}
