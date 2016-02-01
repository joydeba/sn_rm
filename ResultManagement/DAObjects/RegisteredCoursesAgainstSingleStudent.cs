using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ResultManagement.DAObjects
{
    class RegisteredCoursesAgainstSingleStudent
    {
        #region Private Members
        private Student student;
        private List<Registration_and_Marks> courseList;
        private Session session;
        private Year year;
        private Term term;

        #endregion
        #region Properties
        public List<Registration_and_Marks> CourseList
        {
            get { return courseList; }
            set { courseList = value; }
        }

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
        public Session Session
        {
            get { return session; }
            set { session = value; }
        }

        public Year Year
        {
            get { return year; }
            set { year = value; }
        }

        public Term Term
        {
            get { return term; }
            set { term = value; }
        }
        #endregion

        public RegisteredCoursesAgainstSingleStudent()
        {
            student = new Student();
            session = new Session();
            year = new Year((int?)null,null);
            term = new Term((int?)null, null);
        }

        public static int? isStudentRegistered(int? sessionID, int? year, int? term, int? stdID)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);
            int? Registered_Session_ID = null;
            string cmdStr = @"SELECT Registered_Session.ID
                            FROM Registered_Session
                            WHERE
                            Std_ID = @Std_ID AND
                            Sess_ID = @Sess_ID AND
                            Reg_Year = @Reg_Year AND
                            Reg_Term = @Reg_Term";
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@Std_ID", OleDbType.Integer).Value = stdID;
            cmd.Parameters.Add("@Sess_ID", OleDbType.Integer).Value = sessionID;
            cmd.Parameters.Add("@Reg_Year", OleDbType.Integer).Value = year;
            cmd.Parameters.Add("@Reg_Term", OleDbType.Integer).Value = term;
            try
            {
                connection.Open();
                Registered_Session_ID = (int?)cmd.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }
            return Registered_Session_ID;
        }

        public static List<Registration_and_Marks> getCourseList(int? sessionID, int? year, int? term, int? stdID)
        {
            //RegisteredCoursesAgainstSingleStudent registeredCoursesAgainstSingleStudent = new RegisteredCoursesAgainstSingleStudent();
            return Registration_and_Marks.getAllRegistrationList(sessionID, null, year, term, (int?)null, stdID);
        }

        public int? insert()
        { 
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"INSERT INTO Registered_Session
                            (Std_ID, Sess_ID, Reg_Year, Reg_Term)
                            VALUES
                            (@Std_ID, @Sess_ID, @Reg_Year, @Reg_Term)";
            OleDbCommand cmd = new OleDbCommand(cmdStr,connection);

            cmd.Parameters.Add("@Std_ID",OleDbType.Integer).Value = this.Student.StudentId;
            cmd.Parameters.Add("@Sess_ID",OleDbType.Integer).Value = this.Session.SessionID;
            cmd.Parameters.Add("@Reg_Year",OleDbType.Integer).Value = this.Year.YearID;
            cmd.Parameters.Add("@Reg_Term",OleDbType.Integer).Value = this.Term.TermID;

            try{
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
            return insertCourses();
        }
        private int? insertCourses()
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);
            int? Registered_Session_ID;

            string cmdStr = @"SELECT ID FROM Registered_Session
                            WHERE
                            Std_ID = @Std_ID AND 
                            Sess_ID = @Sess_ID AND 
                            Reg_Year = @Reg_Year AND 
                            Reg_Term = @Reg_Term";
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            cmd.Parameters.Add("@Std_ID", OleDbType.Integer).Value = this.Student.StudentId;
            cmd.Parameters.Add("@Sess_ID", OleDbType.Integer).Value = this.Session.SessionID;
            cmd.Parameters.Add("@Reg_Year", OleDbType.Integer).Value = this.Year.YearID;
            cmd.Parameters.Add("@Reg_Term", OleDbType.Integer).Value = this.Term.TermID;

            try
            {
                connection.Open();
                Registered_Session_ID = (int?)cmd.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }
            for (int i = 0; i < courseList.Count; i++)
            {
                courseList[i].Registered_Session_ID = Registered_Session_ID;
                Registration_and_Marks.insert(courseList[i]);
            }
            return Registered_Session_ID;
        }

        public static bool Delete(int reg_sess_id)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"DELETE FROM Registered_Session WHERE ID = "+reg_sess_id;

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            bool susccessful = false;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                susccessful = true;
            }
            finally
            {
                connection.Close();
            }
            return susccessful;
        }
    }
}
