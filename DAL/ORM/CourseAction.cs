using Domain.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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
            string _cmdSelect = "select * from course";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<Course> courseList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return courseList;
        }

        internal List<Course> GetAsList(DataTable dt)
        {
            List<Course> ItemList = new List<Course>();
            foreach (DataRow dr in dt.Rows)
            {
                Course ItemObj = new Course();
                if (!string.IsNullOrEmpty(dr["CourseId"].ToString()))
                    ItemObj.CourseId = Convert.ToInt32(dr["CourseId"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);

                if (!string.IsNullOrEmpty(dr["Description"].ToString()))
                    ItemObj.Description = Convert.ToString(dr["Description"]);

                if (!string.IsNullOrEmpty(dr["Level"].ToString()))
                    ItemObj.Level = Convert.ToString(dr["Level"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public Course GetCourseById(int id)
        {
            try
            {
                string _cmdSelect = "select * from course WHERE CourseId = ?";

                OdbcCommand cmd = new OdbcCommand(_cmdSelect);

                cmd.Parameters.AddWithValue("@CourseId", id);

                List<Course> courseList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

                return courseList[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void AddCourse(Course course)
        {
            string _cmdInsert = "INSERT INTO Course (CourseName, Description, Level) VALUES (?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@Name", course.CourseName);
            cmd1.Parameters.AddWithValue("@Address", course.Description);
            cmd1.Parameters.AddWithValue("@Level", course.Level);

            DBConnection.ExecuteNonQueryAndScalar(cmd1);
            //courses.Add(course);
        }

        public void UpdateCourse(int id, Course course)
        {
            try
            {
                string _cmdUpdate = "UPDATE Course SET CourseName = ?, Description = ?, Level = ? WHERE CourseId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdUpdate);

                // Add parameters for the fields to be updated
                cmd1.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd1.Parameters.AddWithValue("@Description", course.Description);
                cmd1.Parameters.AddWithValue("@Level", course.Level);
               

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@CourseId", id);

                // Execute the update command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);



            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void DeleteCourse(int id)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM course WHERE CourseId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@CourseId", id);

                // Execute the delete command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

    }
}
