using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ResultManagement.DAObjects
{
    public class Session
    {
        #region Private Members

        int? sessionID;
        string sessionName;

        #endregion

        #region Properties

        public int? SessionID
        {
            get { return sessionID; }
            set { sessionID = value; }
        }

        public string SessionName
        {
            get { return sessionName; }
            set { sessionName = value; }
        }

        #endregion

        public static List<Session> getSessionList(int? sessionID, string SessionName)
        {
            //MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"SELECT   `session`.ID, `session`.sessionName
                            FROM  `session`  WHERE 1 ";

            if (sessionID != null)
            {
                cmdStr += " AND id = " + sessionID.Value.ToString();
            }

            if (SessionName != null)
            {
                cmdStr += " AND sessionName = '" + SessionName + "'";
            }

            //MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            List<Session> sessionList = new List<Session>();

            try
            {
                connection.Open();
                //MySqlDataReader reader = cmd.ExecuteReader();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Prog p = new Prog();
                    Session s = new Session();

                    s.sessionID = (int)reader.GetValue(reader.GetOrdinal("ID"));
                    s.sessionName = (string)reader.GetValue(reader.GetOrdinal("sessionName"));

                    sessionList.Add(s);
                }
            }
            finally
            {
                connection.Close();
            }

            return sessionList;
        }

        public static Session GetAllMapping()
        {
            Session s = new Session();
            s.sessionID = null;
            s.sessionName = "(All)";
            
            return s;
        }
    }
}
