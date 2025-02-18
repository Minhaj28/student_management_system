﻿using DAL.ViewModels;
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
    public class StudentEnrollmentAction
    {
        protected List<StudentEnrollment> studentEnrollments = new List<StudentEnrollment>();
        public void EnrollStudent(StudentEnrollment studentEnrollment)
        {
            try
            {
                string _cmdInsert = "INSERT INTO studentEnrollment (StudentID, CourseId) VALUES (?, ?)";

                OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

                //cmd.CommandText(_cmdInsert);
                cmd1.Parameters.AddWithValue("@StudentID", studentEnrollment.StudentID);
                cmd1.Parameters.AddWithValue("@CourseId", studentEnrollment.CourseId);

                DBConnection.ExecuteNonQueryAndScalar(cmd1);

                Console.WriteLine("Enrollment successfully.");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
           

        }

        public void DeleteEnrollment(int studentEnrollmentId)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM studentenrollment WHERE StudentEnrollmentId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@StudentEnrollmentId", studentEnrollmentId);

                // Execute the delete command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        public List<StudentEnrollment> GetAllStudentEnrollment()
        {
            string _cmdSelect = "select * from studentenrollment";
            /*string _cmdSelect = @"SELECT se.StudentEnrollmentId, s.Name, c.CourseName FROM studentenrollment AS se 
                                JOIN student AS s  ON s.StudentID = se.StudentID 
                                JOIN course AS c   ON c.CourseId = se.CourseId;";*/

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<StudentEnrollment> studentEnrollmentList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return studentEnrollmentList;
        }

        internal List<StudentEnrollment> GetAsList(DataTable dt)
        {
            List<StudentEnrollment> ItemList = new List<StudentEnrollment>();
            foreach (DataRow dr in dt.Rows)
            {
                StudentEnrollment ItemObj = new StudentEnrollment();

                if (!string.IsNullOrEmpty(dr["StudentEnrollmentId"].ToString()))
                    ItemObj.StudentEnrollmentId = Convert.ToInt32(dr["StudentEnrollmentId"]);

                if (!string.IsNullOrEmpty(dr["StudentID"].ToString()))
                    ItemObj.StudentID = Convert.ToInt32(dr["StudentID"]);

                if (!string.IsNullOrEmpty(dr["CourseId"].ToString()))
                    ItemObj.CourseId = Convert.ToInt32(dr["CourseId"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public List<StudentEnrollmentView> GetAllStudentEnrollmentView()
        {
            string _cmdSelect = @"SELECT se.StudentEnrollmentId, s.Name, c.CourseName FROM studentenrollment AS se 
                                JOIN student AS s  ON s.StudentID = se.StudentID 
                                JOIN course AS c   ON c.CourseId = se.CourseId;";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<StudentEnrollmentView> studentEnrollmentList = GetAsListView(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return studentEnrollmentList;
        }

        internal List<StudentEnrollmentView> GetAsListView(DataTable dt)
        {
            List<StudentEnrollmentView> ItemList = new List<StudentEnrollmentView>();
            foreach (DataRow dr in dt.Rows)
            {
                StudentEnrollmentView ItemObj = new StudentEnrollmentView();

                if (!string.IsNullOrEmpty(dr["StudentEnrollmentId"].ToString()))
                    ItemObj.StudentEnrollmentId = Convert.ToInt32(dr["StudentEnrollmentId"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }
    }
}
