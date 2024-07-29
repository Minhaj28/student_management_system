using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.ORM
{
    public class TeacherAction : ITeacherActions
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
            string _cmdSelect = "select * from teacher";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<Teacher> teacherList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return teacherList;
        }

        internal List<Teacher> GetAsList(DataTable dt)
        {
            List<Teacher> ItemList = new List<Teacher>();
            foreach (DataRow dr in dt.Rows)
            {
                Teacher ItemObj = new Teacher();
                if (!string.IsNullOrEmpty(dr["TeacherId"].ToString()))
                    ItemObj.TeacherId = Convert.ToInt32(dr["TeacherId"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["Address"].ToString()))
                    ItemObj.Address = Convert.ToString(dr["Address"]);

                if (!string.IsNullOrEmpty(dr["Email"].ToString()))
                    ItemObj.Email = Convert.ToString(dr["Email"]);

                if (!string.IsNullOrEmpty(dr["PhoneNumber"].ToString()))
                    ItemObj.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);

                if (!string.IsNullOrEmpty(dr["Department"].ToString()))
                    ItemObj.Department = Convert.ToString(dr["Department"]);

                if (!string.IsNullOrEmpty(dr["Designation"].ToString()))
                    ItemObj.Designation = Convert.ToString(dr["Designation"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public Teacher GetTeacherById(int id)
        {
            try
            {
                string _cmdSelect = "select * from teacher WHERE TeacherId = ?";

                OdbcCommand cmd = new OdbcCommand(_cmdSelect);

                cmd.Parameters.AddWithValue("@TeacherId", id);

                List<Teacher> teacherList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

                return teacherList[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            string _cmdInsert = "INSERT INTO Teacher (Name, Address, Email, PhoneNumber, Department, Designation) VALUES (?, ?, ?, ?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@Name", teacher.Name);
            cmd1.Parameters.AddWithValue("@Address", teacher.Address);
            cmd1.Parameters.AddWithValue("@Email", teacher.Email);
            cmd1.Parameters.AddWithValue("@PhoneNumber", teacher.PhoneNumber);
            cmd1.Parameters.AddWithValue("@Department", teacher.Department);
            cmd1.Parameters.AddWithValue("@Designation", teacher.Designation);

            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public void UpdateTeacher(int id, Teacher teacher)
        {
            try
            {
                string _cmdUpdate = "UPDATE teacher SET Name = ?, Address = ?, Email = ?, PhoneNumber = ?, Department = ?, Designation = ? WHERE TeacherId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdUpdate);

                // Add parameters for the fields to be updated
                cmd1.Parameters.AddWithValue("@Name", teacher.Name);
                cmd1.Parameters.AddWithValue("@Address", teacher.Address);
                cmd1.Parameters.AddWithValue("@Email", teacher.Email);
                cmd1.Parameters.AddWithValue("@PhoneNumber", teacher.PhoneNumber);
                cmd1.Parameters.AddWithValue("@Level", teacher.Department);
                cmd1.Parameters.AddWithValue("@GPA", teacher.Designation);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@TeacherId", id);

                // Execute the update command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);



            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void DeleteTeacher(int id)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM Teacher WHERE TeacherId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@TeacherId", id);

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
