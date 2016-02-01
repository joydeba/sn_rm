using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ResultManagement.DAObjects
{
    public class Course
    {
        #region Private Members

        private int? id;
        private string prefix;
        private int? year;
        private int? term;
        private string course_No;
        private decimal? credit;
        private string title;
        private bool? is_Optional;

        private string displayableCourseNumber;

        #endregion

        #region Properties

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }
        
        public int? Year
        {
            get { return year; }
            set { year = value; }
        }
        
        public int? Term
        {
            get { return term; }
            set { term = value; }
        }
        
        public string Course_No
        {
            get { return course_No; }
            set {
                if (value == "")
                    course_No = null;
                else
                    course_No = value;
            }
        }
        
        public decimal? Credit
        {
            get {
                if (credit == null)
                    return 0;
                else
                    return credit;
            }
            set {
                if (value == null)
                    credit = 0;
                else
                    credit = value;
            }
        }
        
        public string Title
        {
            get { return title; }
            set {
                if (value == "")
                    title = null;
                else
                    title = value;
            }
        }

        public bool? Is_Optional
        {
            get {
                if (is_Optional == null)
                    return false;
                else
                    return is_Optional;
            }
            set {
                if (value == null)
                    is_Optional = false;
                else
                    is_Optional = value;
            }
        }
        
        public string DisplayableCourseNumber
        {
            get { return this.prefix + " " + Year + Term + Course_No; }
        }

        public string DisplayableCourseNumberWithTitle
        {
            get { return this.prefix + " " + Year + Term + Course_No +" -> "+ Title; }
        }
        #endregion

        public static List<Course> getCourseListOfATerm(int? year, int? term)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"SELECT ID, Course_Prefix, Course_Year, Course_Term, Course_No,
                                Credit, Title, is_Optional
                                From Course
                                WHERE 1 ";
            if (year != null)
            {
                cmdStr += " AND Course_Year = " + year;
            }
            if (term != null)
            {
                cmdStr += " AND Course_Term = " + term;
            }
            cmdStr += @" ORDER BY Course_prefix,Course_year desc,Course_term desc,Course_no";
            
            List<Course> courseList = new List<Course>();

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.ID = (int)reader.GetValue(reader.GetOrdinal("ID"));
                    course.Prefix = (string)reader.GetValue(reader.GetOrdinal("Course_Prefix"));
                    course.Year = (int)reader.GetValue(reader.GetOrdinal("Course_Year"));
                    course.Term = (int)reader.GetValue(reader.GetOrdinal("Course_Term"));
                    course.Course_No = (string)reader.GetValue(reader.GetOrdinal("Course_No"));

                    course.Credit = (decimal)reader.GetValue(reader.GetOrdinal("Credit"));
                    course.Title = (string)reader.GetValue(reader.GetOrdinal("Title"));
                    course.Is_Optional = (bool)reader.GetValue(reader.GetOrdinal("is_Optional"));
                    
                    courseList.Add(course);
                }
            }
            finally
            {
                connection.Close();
            }
            return courseList;
        }

        public static bool Delete(int? CourseID)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"DELETE FROM Course WHERE ID = " + CourseID;

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

        public bool Update()
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"UPDATE Course
                            SET
                            Course_No = @Course_No,
                            Course_Prefix = @Course_Prefix,
                            Course_Year = @Course_Year,
                            Course_Term = @Course_Term,
                            Credit = @Credit,
                            Title = @Title,
                            is_Optional = @is_Optional
                            WHERE ID = @ID";

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@Course_No", OleDbType.VarChar).Value = this.Course_No;
            cmd.Parameters.Add("@Course_Prefix", OleDbType.VarChar).Value = this.Prefix;
            cmd.Parameters.Add("@Course_Year", OleDbType.Integer).Value = this.Year;
            cmd.Parameters.Add("@Course_Term", OleDbType.Integer).Value = this.Term;
            cmd.Parameters.Add("@Credit", OleDbType.Decimal).Value = this.Credit;
            cmd.Parameters.Add("@Title", OleDbType.VarChar).Value = this.Title;
            cmd.Parameters.Add("@is_Optional", OleDbType.Boolean).Value = this.Is_Optional;
            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = this.ID;
            
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

        public bool Insert()
        {
            Boolean inserted = false;
            //MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"INSERT INTO Course
                      (Course_No, Course_Prefix, Course_Year, Course_Term, Credit, Title, is_Optional)
                            VALUES     
                      (@Course_No, @Course_Prefix, @Course_Year,@Course_Term, @Credit, @Title, @is_Optional)";

            //MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            cmd.Parameters.Add("@Course_No", OleDbType.VarChar).Value = this.Course_No;
            cmd.Parameters.Add("@Course_Prefix", OleDbType.VarChar).Value = this.Prefix;
            cmd.Parameters.Add("@Course_Year", OleDbType.Integer).Value = this.Year;
            cmd.Parameters.Add("@Course_Term", OleDbType.Integer).Value = this.Term;
            cmd.Parameters.Add("@Credit", OleDbType.Decimal).Value = this.Credit;
            cmd.Parameters.Add("@Title", OleDbType.VarChar).Value = this.Title;
            cmd.Parameters.Add("@is_Optional", OleDbType.Boolean).Value = this.Is_Optional;
            //int studentId;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                inserted = true;
                //studentId = (int)cmd.;//get last auto-number 
            }
            catch
            { }
            finally
            {
                connection.Close();
            }

            return inserted;
        }
    }
}
