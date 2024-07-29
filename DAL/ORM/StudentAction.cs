using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;

namespace DAL.ORM
{
    public class StudentAction : IStudentActions
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

            string _cmdSelect = "select * from student";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<Student> studentList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return studentList;
        }
        internal List<Student> GetAsList(DataTable dt)
        {
            List<Student> ItemList = new List<Student>();
            foreach (DataRow dr in dt.Rows)
            {
                Student ItemObj = new Student();
                if (!string.IsNullOrEmpty(dr["StudentID"].ToString()))
                    ItemObj.StudentID = Convert.ToInt32(dr["StudentID"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["Address"].ToString()))
                    ItemObj.Address = Convert.ToString(dr["Address"]);

                if (!string.IsNullOrEmpty(dr["Email"].ToString()))
                    ItemObj.Email = Convert.ToString(dr["Email"]);

                if (!string.IsNullOrEmpty(dr["PhoneNumber"].ToString()))
                    ItemObj.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);

                if (!string.IsNullOrEmpty(dr["Level"].ToString()))
                    ItemObj.Level = Convert.ToString(dr["Level"]);

                if (!string.IsNullOrEmpty(dr["Gpa"].ToString()))
                    ItemObj.GPA = Convert.ToString(dr["Gpa"]);
               

                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public Student GetStudentById(int id)
        {
            //return students.FirstOrDefault(s => s.StudentID == id);

           

            try
            {
                string _cmdSelect = "select * from student WHERE StudentID = ?";

                OdbcCommand cmd = new OdbcCommand(_cmdSelect);

                cmd.Parameters.AddWithValue("@StudentID", id);

                List<Student> studentList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

                return studentList[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void AddStudent(Student student)
        {
            string _cmdInsert = "INSERT INTO Student (Name, Address, Email, PhoneNumber, Level, GPA) VALUES (?, ?, ?, ?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@Name", student.Name);
            cmd1.Parameters.AddWithValue("@Address", student.Address);
            cmd1.Parameters.AddWithValue("@Email", student.Email);
            cmd1.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            cmd1.Parameters.AddWithValue("@Level", student.Level);
            cmd1.Parameters.AddWithValue("@GPA", student.GPA);

            DBConnection.ExecuteNonQueryAndScalar(cmd1);

            //students.Add(student);
         
        }

        public void UpdateStudent(int id, Student student)
        {
            

            try
            {
                string _cmdUpdate = "UPDATE Student SET Name = ?, Address = ?, Email = ?, PhoneNumber = ?, Level = ?, GPA = ? WHERE StudentID = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdUpdate);

                // Add parameters for the fields to be updated
                cmd1.Parameters.AddWithValue("@Name", student.Name);
                cmd1.Parameters.AddWithValue("@Address", student.Address);
                cmd1.Parameters.AddWithValue("@Email", student.Email);
                cmd1.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                cmd1.Parameters.AddWithValue("@Level", student.Level);
                cmd1.Parameters.AddWithValue("@GPA", student.GPA);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@StudentID", id);

                // Execute the update command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

               

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void DeleteStudent(int id)
        {
            
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM Student WHERE StudentID = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@StudentID", id);

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
