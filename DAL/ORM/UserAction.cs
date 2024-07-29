using Domain.Classes;
using Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.ORM
{
    public class UserAction : IUserActions
    {
        protected List<User> users = new List<User>();

        public List<User> GetAllUsers()
        {
            string _cmdSelect = "select * from user";

            OdbcCommand cmd = new OdbcCommand(_cmdSelect);
            List<User> userList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

            return userList;
        }

        internal List<User> GetAsList(DataTable dt)
        {
            List<User> ItemList = new List<User>();
            foreach (DataRow dr in dt.Rows)
            {
                User ItemObj = new User();
                if (!string.IsNullOrEmpty(dr["UserId"].ToString()))
                    ItemObj.UserId = Convert.ToInt32(dr["UserId"]);

                if (!string.IsNullOrEmpty(dr["UserName"].ToString()))
                    ItemObj.UserName = Convert.ToString(dr["UserName"]);

                if (!string.IsNullOrEmpty(dr["UserPassword"].ToString()))
                    ItemObj.UserPassword = Convert.ToString(dr["UserPassword"]);

                ItemList.Add(ItemObj);
            }
            return ItemList;
        }

        public User GetUserById(int id)
        {
            try
            {
                string _cmdSelect = "select * from user WHERE UserId = ?";

                OdbcCommand cmd = new OdbcCommand(_cmdSelect);

                cmd.Parameters.AddWithValue("@UserId", id);

                List<User> userList = GetAsList(DBConnection.ExecuteQuery(cmd).Tables[0]);

                return userList[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void AddUser(User user)
        {
            string _cmdInsert = "INSERT INTO User (UserName, UserPassword) VALUES (?, ?)";

            OdbcCommand cmd1 = new OdbcCommand(_cmdInsert);

            //cmd.CommandText(_cmdInsert);
            cmd1.Parameters.AddWithValue("@UserName", user.UserName);
            cmd1.Parameters.AddWithValue("@UserPassword", user.UserPassword);

            DBConnection.ExecuteNonQueryAndScalar(cmd1);
        }

        public void UpdateUser(int id, User user)
        {
            try
            {
                string _cmdUpdate = "UPDATE user SET UserName = ?, UserPassword = ?  WHERE UserId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdUpdate);

                // Add parameters for the fields to be updated
                cmd1.Parameters.AddWithValue("@UserName", user.UserName);
                cmd1.Parameters.AddWithValue("@UserPassword", user.UserPassword);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@UserId", id);

                // Execute the update command
                DBConnection.ExecuteNonQueryAndScalar(cmd1);



            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                // Define the SQL delete command with a placeholder for the ID
                string _cmdDelete = "DELETE FROM User WHERE UserId = ?";

                // Create an OdbcCommand object
                OdbcCommand cmd1 = new OdbcCommand(_cmdDelete);

                // Add the parameter for the ID
                cmd1.Parameters.AddWithValue("@UserId", id);

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
