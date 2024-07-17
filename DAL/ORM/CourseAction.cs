using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class CourseAction
    {

        protected List<Course> courses = new List<Course>();
        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public Course GetCourseById(int id)
        {
            return courses.FirstOrDefault(c => c.CourseID == id);
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            Course existingCourse = GetCourseById(course.CourseID);
            if (existingCourse != null)
            {
                existingCourse.CourseName = course.CourseName;
                existingCourse.Description = course.Description;
                existingCourse.Level = course.Level;
            }
        }

        public void DeleteCourse(int id)
        {
            Course course = GetCourseById(id);
            if (course != null)
            {
                courses.Remove(course);
            }
        }

    }
}
