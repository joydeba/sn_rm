using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ResultManagement.UserManagement
{
    
    public class User
    {
        public static bool IsLoggedIn;
        public static User LoggedInUser;


        #region Private Fields
        private int? userId;
        private string userName;
        private string password;
        private UserType type;
        private string fullName;
        private bool authenticated;
        private DateTime date;
        #endregion

        #region properties
        public int? UserId
        {
            get { return this.userId; }
            set { this.userId = value; }           
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public UserType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public bool Authenticated
        {
            get { return this.authenticated; }
            set { this.authenticated = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        #endregion


        /// <summary>
        /// Creates a new User object
        /// </summary>
        public User()
        {

        }

        public override string ToString()
        {
            return this.userName;
        }


        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUserList(string userName, string password)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            String cmdStr = @"SELECT     user_id, username, password, authenticated 
                         FROM  `user`  WHERE  1 ";

            if (userName != null)
            {
                cmdStr += " AND  username = '" + userName + "'";
            }

            if (password != null)
            {
                cmdStr += " AND  password = '" + password + "'";
            }

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            List<User> userList = new List<User>();

            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.userId = (int)reader.GetValue(reader.GetOrdinal("user_id"));
                    user.userName = (string)reader.GetValue(reader.GetOrdinal("username"));
                    user.password = (string)reader.GetValue(reader.GetOrdinal("password"));
                    //user.fullName = (string)reader.GetValue(reader.GetOrdinal("full_name"));
                    //user.type = (UserType)reader.GetValue(reader.GetOrdinal("type"));
                    user.authenticated = (bool)reader.GetValue(reader.GetOrdinal("authenticated"));
                    //user.date = (DateTime)reader.GetValue(reader.GetOrdinal("date"));
                    
                    userList.Add(user);
                }
                
            }
            finally
            {
                connection.Close();
            }

            return userList;

        }

        //**********************************************************

        /// <summary>
        /// Authenticate username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void Login(string userName, string password)
        {
            try
            {
                List<User> userList = User.GetUserList(userName, password);

                if (userList.Count > 0)
                {
                    if (userList[0].authenticated)
                    {
                        User.IsLoggedIn = true;
                        User.LoggedInUser = userList[0];
                    }
                    else
                    {
                        MessageBox.Show("Your request has not yet been approved!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username & password!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        public static void Logout()
        {
            User.IsLoggedIn = false;
            User.LoggedInUser = null;
        }
        /*

        /// <summary>
        /// Place a new user request
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="type"></param>
        public static void Register(string userName, string password, string fullName, UserType type)
        {
            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            String cmdStr = @"INSERT INTO `user` (username, password, full_name, type, `date`, authenticated)
                        VALUES  (@username, @password, @full_name, @type, @date, @authenticated)";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);

            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@full_name", MySqlDbType.VarChar).Value = fullName;
            cmd.Parameters.Add("@type", MySqlDbType.Int32).Value = (int)type;
            cmd.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@authenticated", MySqlDbType.Bit).Value = false;


            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your request has been posted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not post the request.Please try different username.\n\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Changes the password of an user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        public static void ChangePassword(string userName, string curPassword, string newPassword)
        {

            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            String cmdStr = "UPDATE  user  SET  password = @new_password  WHERE  username = @username  AND password = @cur_password";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);

            cmd.Parameters.Add("@new_password", MySqlDbType.VarChar).Value = newPassword;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@cur_password", MySqlDbType.VarChar).Value = curPassword;


            try
            {
                connection.Open();
                int i = cmd.ExecuteNonQuery();

                if (i == 0)
                {
                    MessageBox.Show("Invalid current password!");
                }
                else
                {
                    MessageBox.Show("Your password has been changed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Enable or disable an existing user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="enable"></param>
        public static void AuthenticateUser(string userName, bool authenticated)
        {

            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            String cmdStr = "UPDATE  user  SET  authenticated = @authenticated  WHERE  username = @username";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);

            cmd.Parameters.Add("@authenticated", MySqlDbType.Bit).Value = authenticated;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userName;


            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="userName"></param>
        public static void DeleteUser(string userName)
        {

            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            String cmdStr = "DELETE  FROM  user  WHERE  username = '" + userName + "'";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);

         
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }


        //added later
        public static bool MatchPassword(string userName, string password)
        {

            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            String cmdStr = @"SELECT  [Password]  FROM  Users   WHERE  UserName = ?";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = userName;

            bool successful = false;

            try
            {
                connection.Open();
                string p = (string)cmd.ExecuteScalar();

                if (password == p)
                {
                    successful = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return successful;
        }
        */

    }


    public enum UserType
    {
        Admin = 0,
        User = 1
    }
        
}
