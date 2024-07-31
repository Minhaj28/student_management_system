using DAL.Models;
using DAL.ViewModels;
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

        public void TakeAttendance(Attendance attendance)
        {
            string _cmdInsert = "INSERT INTO attendance (StudentEnrollmentId, AttendanceDate, Status) VALUES (?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@StudentEnrollmentId", attendance.StudentEnrollmentId);
            cmd1.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate);
            cmd1.Parameters.AddWithValue("@Status", attendance.Status);


            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public List<AttendanceView> GetAllAttendanceView()
        {
            string _cmdSelect = @"SELECT 
                                    a.AttendanceId, 
                                    s.StudentID, 
                                    s.Name, 
                                    c.CourseName, 
                                    a.AttendanceDate,
                                    a.Status
                                FROM 
                                    Attendance a
                                JOIN 
                                    StudentEnrollment se ON a.StudentEnrollmentId = se.StudentEnrollmentId
                                JOIN 
                                    Student s ON se.StudentID = s.StudentID
                                JOIN 
                                    Course c ON se.CourseId = c.CourseId;
                                ";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<AttendanceView> attendanceList = GetAsAttendanceListView(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return attendanceList;
        }

        internal List<AttendanceView> GetAsAttendanceListView(DataTable dt)
        {
            List<AttendanceView> ItemList = new List<AttendanceView>();
            foreach (DataRow dr in dt.Rows)
            {
                AttendanceView ItemObj = new AttendanceView();

                if (!string.IsNullOrEmpty(dr["AttendanceId"].ToString()))
                    ItemObj.AttendanceId = Convert.ToInt32(dr["AttendanceId"]);

                if (!string.IsNullOrEmpty(dr["StudentID"].ToString()))
                    ItemObj.StudentID = Convert.ToInt32(dr["StudentID"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);

                if (!string.IsNullOrEmpty(dr["AttendanceDate"].ToString()))
                    ItemObj.AttendanceDate = Convert.ToString(dr["AttendanceDate"]);

                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                    ItemObj.Status = Convert.ToString(dr["Status"]);



                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public void GradeStudents()
        {
            Console.WriteLine($"Teacher graded students.");
        }

        public void SuperviseResearch()
        {
            Console.WriteLine($"Teacher is supervising research.");
        }

        public void TakeExam(Exam exam)
        {
            string _cmdInsert = "INSERT INTO exam (CourseId, ExamDate, ExamType) VALUES (?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@CourseId", exam.CourseId);
            cmd1.Parameters.AddWithValue("@ExamDate", exam.ExamDate);
            cmd1.Parameters.AddWithValue("@ExamType", exam.ExamType);


            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public List<ExamView> GetAllExamView()
        {
            string _cmdSelect = @"SELECT e.ExamId, c.CourseName, e.ExamDate, e.ExamType FROM exam AS e
                                JOIN course AS c   ON c.CourseId = e.CourseId;";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<ExamView> examList = GetAsExamListView(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return examList;
        }

        internal List<ExamView> GetAsExamListView(DataTable dt)
        {
            List<ExamView> ItemList = new List<ExamView>();
            foreach (DataRow dr in dt.Rows)
            {
                ExamView ItemObj = new ExamView();

                if (!string.IsNullOrEmpty(dr["ExamId"].ToString()))
                    ItemObj.ExamId = Convert.ToInt32(dr["ExamId"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);

                if (!string.IsNullOrEmpty(dr["ExamDate"].ToString()))
                    ItemObj.ExamDate = Convert.ToString(dr["ExamDate"]);

                if (!string.IsNullOrEmpty(dr["ExamType"].ToString()))
                    ItemObj.ExamType = Convert.ToString(dr["ExamType"]);



                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public void DeleteExam(int examId)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM exam WHERE ExamId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@ExamId", examId);

                // Execute the delete command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        public void ExamResult(ExamResult examResult)
        {
            string _cmdInsert = "INSERT INTO examresult (ExamId, StudentID, Score) VALUES (?, ?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@ExamId", examResult.ExamId);
            cmd1.Parameters.AddWithValue("@StudentID", examResult.StudentID);
            cmd1.Parameters.AddWithValue("@Score", examResult.Score);


            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public List<ResultView> GetAllResultView()
        {
            string _cmdSelect = @"SELECT 
                                   er.ResultId,
                                   e.ExamId,
                                   s.StudentID,
                                   s.Name,
                                   c.CourseName,
                                   er.Score
                                FROM 
                                    examresult er
                                JOIN 
                                    exam e ON e.ExamId = er.ExamId
                                JOIN 
                                    Student s ON s.StudentID = er.StudentID
                                JOIN 
                                    Course c ON c.CourseId = e.CourseId;
                                ";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<ResultView> resultList = GetAsResultListView(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return resultList;
        }

        internal List<ResultView> GetAsResultListView(DataTable dt)
        {
            List<ResultView> ItemList = new List<ResultView>();
            foreach (DataRow dr in dt.Rows)
            {
                ResultView ItemObj = new ResultView();

                if (!string.IsNullOrEmpty(dr["ResultId"].ToString()))
                    ItemObj.ResultId = Convert.ToInt32(dr["ResultId"]);

                if (!string.IsNullOrEmpty(dr["ExamId"].ToString()))
                    ItemObj.ExamId = Convert.ToInt32(dr["ExamId"]);

                if (!string.IsNullOrEmpty(dr["StudentID"].ToString()))
                    ItemObj.StudentID = Convert.ToInt32(dr["StudentID"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);

                if (!string.IsNullOrEmpty(dr["Score"].ToString()))
                    ItemObj.Score = Convert.ToString(dr["Score"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public void DeleteResult(int resultId)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM examresult WHERE ResultId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@ResultId", resultId);

                // Execute the delete command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        public void AssignedTeacher(AssignedTeacher assignedTeacher)
        {
            string _cmdInsert = "INSERT INTO assignedteacher (TeacherId, CourseId) VALUES (?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@TeacherId", assignedTeacher.TeacherId);
            cmd1.Parameters.AddWithValue("@CourseId", assignedTeacher.CourseId);

            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public List<AssignedTeacherView> GetAllAssignedTeacherView()
        {
            string _cmdSelect = @"SELECT at.AssignedTeacherId, t.Name, c.CourseName FROM assignedteacher AS at 
                                JOIN teacher AS t  ON t.TeacherId = at.TeacherId 
                                JOIN course AS c   ON c.CourseId = at.CourseId;";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<AssignedTeacherView> assignedTeacherList = GetAsListView(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return assignedTeacherList;
        }

        internal List<AssignedTeacherView> GetAsListView(DataTable dt)
        {
            List<AssignedTeacherView> ItemList = new List<AssignedTeacherView>();
            foreach (DataRow dr in dt.Rows)
            {
                AssignedTeacherView ItemObj = new AssignedTeacherView();

                if (!string.IsNullOrEmpty(dr["AssignedTeacherId"].ToString()))
                    ItemObj.AssignedTeacherId = Convert.ToInt32(dr["AssignedTeacherId"]);

                if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                    ItemObj.Name = Convert.ToString(dr["Name"]);

                if (!string.IsNullOrEmpty(dr["CourseName"].ToString()))
                    ItemObj.CourseName = Convert.ToString(dr["CourseName"]);


                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public void DeleteAssignedTeacher(int assignedTeacherId)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM assignedteacher WHERE AssignedTeacherId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@AssignedTeacherId", assignedTeacherId);

                // Execute the delete command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

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
