using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ResultManagement.DAObjects
{
    public class Registration_and_Marks
    {
        #region Private Members

        // Registration_and_Marks_ID is stored as MarksID in Marks Class
        private int? registered_Session_ID;

        //private int? sessionID;
        //private string sessionName;
        private int? reg_year;
        private int? reg_term;

        private Student student;
        private Marks marks;
        private Course course;
        private Session session;

        #endregion

        #region Properties

        public int? Registered_Session_ID
        {
            get { return registered_Session_ID; }
            set { registered_Session_ID = value; }
        }
        public int? Reg_Year
        {
            get { return reg_year; }
            set { reg_year = value; }
        }
        public int? Reg_Term
        {
            get { return reg_term; }
            set { reg_term = value; }
        }

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
        public Marks Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        public Course Course
        {
            get { return course; }
            set { course = value; }
        }
        public Session Session
        {
            get { return session; }
            set { session = value; }
        }
        #endregion

        public Registration_and_Marks()
        {
            student = new Student();
            marks = new Marks();
            course = new Course();
            session = new Session();
        }


        public static int getMaxNumberOfRegistration(int? sessionID, string batch, int? year, int? term)
        {
            int maxNumberOfRegistration = 0;
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"SELECT max(CountOfID)
                                FROM 
                                (
                                    SELECT [Session].id,Student.id, Student.batch, registered_session.reg_Year, registered_session.reg_term,
                                                Count(Course.ID) AS CountOfID 
                                    FROM [Session], Student, Registered_Session, Registration_and_Marks, Course
                                    WHERE [Session].ID = Registered_Session.Sess_ID
                                    And Student.ID = Registered_Session.Std_ID
                                    And Registered_Session.ID = Registration_and_Marks.Reg_Sess_ID
                                    And Registration_and_Marks.Course_ID = Course.ID
                                    GROUP BY [Session].id, Student.id, Student.batch, registered_session.reg_Year, registered_session.reg_term
                                )
                                WHERE 1 ";
            if (sessionID != null)
            {
                cmdStr += @" AND [session].ID = " + sessionID;
            }
            if (batch != null)
            {
                cmdStr += @" AND student.batch = '" + batch + "'";
            }
            if (year != null)
            {
                cmdStr += @" AND registered_session.reg_Year = " + year; 
            }
            if (term != null)
            {
                cmdStr += @" AND registered_session.reg_Term = " + term;
            }

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            try
            {
                connection.Open();
                maxNumberOfRegistration = (int)cmd.ExecuteScalar();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return maxNumberOfRegistration;
        }

        public static List<Registration_and_Marks> getAllRegistrationList(int? sessionID, string batch, int? year, int? term, int? courseID, int? stdID)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            /*string cmdStr = @"SELECT 
                             [session].ID as SessionID, [session].sessionName,
                              Student.ID as StdID, Student.Batch, Student.Roll, Student.St_Name,
                              Registered_Session.ID as registered_session_ID, Registered_Session.Reg_Year, Registered_Session.Reg_Term,
                              Registration_and_Marks.ID as MarksID, Registration_and_Marks.is_Retake, Registration_and_Marks.Attendence,
                                Registration_and_Marks.CT_or_Viva,Registration_and_Marks.SA_or_SecA, Registration_and_Marks.SecB,
                              Course.ID as CourseID, Course.Course_Prefix, Course.Course_Year, Course.Course_Term,
                                Course.Course_No, Course.Credit, Course.Title, Course.is_Optional
                              FROM [Session],Student,Registered_Session,Registration_and_Marks,Course
                              WHERE 
                             [Session].ID = Registered_Session.Sess_ID AND
                              Student.ID = Registered_Session.Std_ID AND
                              Registered_Session.ID = Registration_and_Marks.Reg_Sess_ID AND
                              Registration_and_Marks.Course_ID = Course.ID";*/

            string cmdStr = @"SELECT 
                             SessionID, sessionName,
                             StdID, Batch, Roll, St_Name,
                             registered_session_ID, Reg_Year, Reg_Term,
                             MarksID, is_Retake, Attendence,CT_or_Viva,SA_or_SecA, SecB,
                             CourseID, Course_Prefix, Course_Year, Course_Term,Course_No,Credit, Title, is_Optional
                             FROM 
                                (SELECT [session].ID as SessionID, [session].sessionName,
                                Student.ID as StdID, Student.Batch, Student.Roll, Student.St_Name,
                                Registered_Session.ID as registered_session_ID, Registered_Session.Reg_Year, Registered_Session.Reg_Term
                                FROM Student INNER JOIN 
                                    ([Session] INNER JOIN Registered_Session ON 
                                        [Session].ID=Registered_Session.Sess_ID) ON 
                                        Student.ID=Registered_Session.Std_ID) AS T1 
                              LEFT JOIN 
                                (SELECT Registration_and_Marks.ID as MarksID, Registration_and_Marks.Reg_Sess_ID, Registration_and_Marks.is_Retake, Registration_and_Marks.Attendence,
                                Registration_and_Marks.CT_or_Viva,Registration_and_Marks.SA_or_SecA, Registration_and_Marks.SecB,
                              Course.ID as CourseID, Course.Course_Prefix, Course.Course_Year, Course.Course_Term,
                                Course.Course_No, Course.Credit, Course.Title, Course.is_Optional 
                                FROM Course INNER JOIN 
                                     Registration_and_Marks ON 
                                        Course.ID=Registration_and_Marks.Course_ID) AS T2 
                              ON T1.registered_session_ID=T2.Reg_Sess_ID
                              WHERE 1 ";

            if (sessionID != null)
            {
                cmdStr += @" AND SessionID = " + sessionID;
            }
            if (batch != null)
            {
                cmdStr += @" AND Batch = '" + batch + "'";
            }
            if (year != null)
            {
                cmdStr += @" AND Reg_Year = " + year;
            }
            if (term != null)
            {
                cmdStr += @" AND Reg_Term = " + term;
            }
            if(courseID != null)
            {
                cmdStr += @" AND CourseID = " + courseID;
            }
            if (stdID != null)
            {
                cmdStr += @" AND StdID = " + stdID;
            }
            cmdStr += @" ORDER BY registered_session_ID, StdID, reg_year, reg_term, course_year desc, course_term desc, course_no, course_prefix";
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            List<Registration_and_Marks> registration_and_MarksList = new List<Registration_and_Marks>();
                
            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Registration_and_Marks regisTration_and_Marks = new Registration_and_Marks();
                    regisTration_and_Marks.Registered_Session_ID = (int)reader.GetValue(reader.GetOrdinal("registered_session_ID"));
                    regisTration_and_Marks.Reg_Year = (int)reader.GetValue(reader.GetOrdinal("Reg_Year"));
                    regisTration_and_Marks.Reg_Term = (int)reader.GetValue(reader.GetOrdinal("Reg_Term"));

                    Session session = new Session();
                    session.SessionID = (int)reader.GetValue(reader.GetOrdinal("SessionID"));
                    session.SessionName = (string)reader.GetValue(reader.GetOrdinal("SessionName"));
                    regisTration_and_Marks.Session = session;

                    Student student = new Student();
                    student.Batch = (string)reader.GetValue(reader.GetOrdinal("Batch"));
                    student.StudentId = (int)reader.GetValue(reader.GetOrdinal("StdID"));
                    student.Roll = (string)reader.GetValue(reader.GetOrdinal("Roll"));
                    student.Name = (string)reader.GetValue(reader.GetOrdinal("St_Name"));
                    regisTration_and_Marks.Student = student;

                    Course course = new Course();
                    try
                    {
                        course.ID = (int?)reader.GetValue(reader.GetOrdinal("CourseID"));
                        course.Prefix = (string)reader.GetValue(reader.GetOrdinal("Course_Prefix"));
                        course.Year = (int?)reader.GetValue(reader.GetOrdinal("Course_Year"));
                        course.Term = (int?)reader.GetValue(reader.GetOrdinal("Course_Term"));
                        course.Course_No = (string)reader.GetValue(reader.GetOrdinal("Course_No"));
                        course.Credit = (decimal?)reader.GetValue(reader.GetOrdinal("Credit"));
                        course.Title = (string)reader.GetValue(reader.GetOrdinal("Title"));
                        course.Is_Optional = (bool?)reader.GetValue(reader.GetOrdinal("is_Optional"));
                        regisTration_and_Marks.Course = course;
                    }
                    catch { }
                    
                    Marks marks = new Marks();
                    try
                    {
                        marks.MarksID = (int?)reader.GetValue(reader.GetOrdinal("MarksID"));
                        marks.IsRetake = (bool?)reader.GetValue(reader.GetOrdinal("is_Retake"));
                        marks.Attendence = (int?)reader.GetValue(reader.GetOrdinal("Attendence"));
                        marks.Ct_or_Viva = (int?)reader.GetValue(reader.GetOrdinal("CT_or_Viva"));
                        marks.SA_or_SecA = (int?)reader.GetValue(reader.GetOrdinal("SA_or_SecA"));
                        marks.SecB = (int?)reader.GetValue(reader.GetOrdinal("SecB"));
                        regisTration_and_Marks.Marks = marks;
                    }
                    catch { }
                    
                    registration_and_MarksList.Add(regisTration_and_Marks);
                }
            }
            finally
            {
                connection.Close();
            }
            return registration_and_MarksList;
        }

        public static bool Update(Registration_and_Marks reg_and_marks)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"UPDATE Registration_and_Marks
                            SET
                            is_retake = @is_retake,
                            Attendence = @attndence,
                            ct_or_viva = @ct_or_viva,
                            sa_or_secA = @sa_or_secA,
                            secB = @secB
                            WHERE 0 ";
            /*if (reg_and_marks.marks.MarksID != null)
            {
                cmdStr += @"OR ID = " + reg_and_marks.marks.MarksID;
            }*/
            if (reg_and_marks.Registered_Session_ID != null && reg_and_marks.course.ID != null)
            {
                cmdStr += @" OR (reg_sess_ID = " + reg_and_marks.Registered_Session_ID 
                            + @" AND course_ID = " + reg_and_marks.course.ID + ")";
            }
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@is_retake", OleDbType.Boolean).Value = reg_and_marks.marks.IsRetake;
            cmd.Parameters.Add("@attndence", OleDbType.Integer).Value = reg_and_marks.marks.Attendence;
            cmd.Parameters.Add("@ct_or_viva", OleDbType.Integer).Value = reg_and_marks.marks.Ct_or_Viva;
            cmd.Parameters.Add("@sa_or_secA", OleDbType.Integer).Value = reg_and_marks.marks.SA_or_SecA;
            cmd.Parameters.Add("@secB", OleDbType.Integer).Value = reg_and_marks.marks.SecB;
            bool successful = false;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                successful = true;
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }

        public static bool delete(Registration_and_Marks reg_and_marks)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"DELETE FROM Registration_and_Marks
                            WHERE 0 ";
            /*if (reg_and_marks.marks.MarksID != null)
            {
                cmdStr += @"OR ID = " + reg_and_marks.marks.MarksID;
            }*/
            if (reg_and_marks.Registered_Session_ID != null && reg_and_marks.course.ID != null)
            {
                cmdStr += " OR (reg_sess_ID = " + reg_and_marks.Registered_Session_ID
                            + @" AND course_ID = " + reg_and_marks.course.ID + ")";
            }
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            bool successful = false;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                successful = true;
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }

        public static bool insert(Registration_and_Marks reg_and_marks)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"INSERT INTO Registration_AND_Marks
                                (Reg_Sess_ID, Course_ID, is_Retake)
                                VALUES
                                (@Reg_Sess_ID, @Course_ID, @is_Retake)";
            
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@Reg_Sess_ID", OleDbType.Integer).Value = reg_and_marks.Registered_Session_ID;
            cmd.Parameters.Add("@Course_ID", OleDbType.Integer).Value = reg_and_marks.Course.ID;
            cmd.Parameters.Add("@is_Retake", OleDbType.Boolean).Value = reg_and_marks.Marks.IsRetake;
            
            bool successful = false;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                successful = true;
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }
    }
}
