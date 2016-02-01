using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Data.OleDb;

namespace ResultManagement.DAObjects
{
    public class Student
    {
        #region Private Fields

        private int? studentId;

        private string batch;
        private string roll;
        private string name;

        private string displayableStudentID;

        #endregion


        #region Properties

        public int? StudentId
        {
            get
            {
                return this.studentId;
            }

            set
            {
                this.studentId = value;
            }
        }

        public string Batch
        {
            get
            {
                return this.batch;
            }

            set
            {
                this.batch = value;
            }
        }

        public string Roll
        {
            get 
            {
                if (this.roll == null)
                {
                    return "";
                }
                else
                {
                    return this.roll;
                }
            }

            set
            {
                if (value == "")
                {
                    this.roll = null;
                }
                else
                {
                    this.roll = value;
                }
            }
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    return " ";
                }
                else
                {
                    return this.name;
                }
            }

            set
            {
                if (value == "")
                {
                    this.name = " ";
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string DisplayableStudentID
        {
            get { return batch + Depertment.DepartmentCode + roll; }
        }

        #endregion

        /*
        /// <summary>
        /// Delete all info of a student(including transactions, exam results, university admission test info etc)
        /// </summary>
        public static void Delete(int studentId)
        {
            MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);

            string cmdStr = @"DELETE  FROM  student  WHERE  student_id = @student_id";

            MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            cmd.Parameters.Add("@student_id", MySqlDbType.Int32).Value = studentId;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        
        */
        /// <summary>
        /// Insert student info and returns StudentId (auto-number)
        /// </summary>
        public Boolean Insert()
        {
            Boolean inserted = false;
            //MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"INSERT INTO student
                      (roll, st_name, batch)
                            VALUES     
                      (@roll, @name, @batch)";

            //MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            cmd.Parameters.Add("@roll", OleDbType.VarChar).Value = this.Roll;
            cmd.Parameters.Add("@name", OleDbType.VarChar).Value = this.Name;
            
            cmd.Parameters.Add("@batch", OleDbType.VarChar).Value = this.Batch;

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

        
        /// <summary>
        /// Update student info
        /// </summary>
        public bool Update()
        {
            Boolean sucsessful = false;
            
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"UPDATE  student  SET
                      roll = @roll, St_name = @St_name, batch = @batch 
                            WHERE  id = @id";

            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);


            cmd.Parameters.Add("@roll", OleDbType.VarChar).Value = this.Roll;
            cmd.Parameters.Add("@St_name", OleDbType.VarChar).Value = this.Name;
            cmd.Parameters.Add("@batch", OleDbType.VarChar).Value = this.Batch;

            cmd.Parameters.Add("@id", OleDbType.Integer).Value = this.studentId;

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                sucsessful = true;
            }
            finally
            {
                connection.Close();
            }
            return sucsessful;
        }

       

        public static Student getStudent(int stdID)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);
            Student student = null;
            string cmdStr = @"SELECT     student.id, student.Roll, student.batch, student.St_name
                   FROM  student WHERE  student.id = @std_ID";
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@std_ID", OleDbType.Integer).Value = stdID;
            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    student = new Student();
                    student.Batch = (string)reader.GetValue(reader.GetOrdinal("batch"));
                    student.Roll = (string)reader.GetValue(reader.GetOrdinal("Roll"));
                    student.name = (string)reader.GetValue(reader.GetOrdinal("St_Name"));
                    student.studentId = stdID;
                }
            }
            finally
            {
                connection.Close();
            }
            return student;
        }

        public static Student getStudent(string StudentID)
        {
            if (StudentID.Length != 6)
                return null;
            else if (!StudentID.Substring(2, 2).Equals(Depertment.DepartmentCode))
                return null;
            else
                return getStudent(StudentID.Substring(0, 2), StudentID.Substring(4, 2));
        }

        public static Student getStudent(string batch, string roll)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);
            Student student = null;
            string cmdStr = @"SELECT     student.id, student.Roll, student.batch, student.St_name
                   FROM  student WHERE  
                   student.batch = @batch AND
                   student.roll = @roll";
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);
            cmd.Parameters.Add("@batch", OleDbType.VarChar).Value = batch;
            cmd.Parameters.Add("@roll", OleDbType.VarChar).Value = roll;
            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    student = new Student();
                    student.Batch = (string)reader.GetValue(reader.GetOrdinal("batch"));
                    student.Roll = (string)reader.GetValue(reader.GetOrdinal("Roll"));
                    student.name = (string)reader.GetValue(reader.GetOrdinal("St_Name"));
                    student.studentId = (int)reader.GetValue(reader.GetOrdinal("id"));
                }
            }
            finally
            {
                connection.Close();
            }
            return student;
        }

        public static List<Student> GetStudentList(StudentSearchCriteria sc)
        {
            //MySqlConnection connection = new MySqlConnection(global::CCMS.Properties.Settings.Default.ccmsConnectionString);
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);
            
            string cmdStr = @"SELECT     student.id, student.Roll, student.batch, student.St_name
                   FROM  student WHERE  1 ";
            
            #region search criteria
            if (sc.StudentId != null)
            {
                cmdStr += " AND student.id = " + sc.StudentId.ToString();
            }

            if (sc.RollLike != null)
            {
                cmdStr += " AND student.roll LIKE '%" + sc.RollLike + "%'";
            }

            if (sc.RollExact != null)
            {
                cmdStr += " AND student.roll = '" + sc.RollExact + "'";
            }

            if (sc.Name != null)
            {
                cmdStr += " AND student.St_name LIKE '%" + sc.Name + "%'";
            }

            if (sc.Batch != null)
            {
                cmdStr += " AND student.batch = '" + sc.Batch + "'";
            }

            cmdStr += " ORDER BY batch,roll";
            #endregion


            //MySqlCommand cmd = new MySqlCommand(cmdStr, connection);
            OleDbCommand cmd = new OleDbCommand(cmdStr, connection);

            List<Student> sList = new List<Student>();

            try
            {
                connection.Open();
                //MySqlDataReader reader = cmd.ExecuteReader();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student s = new Student();


                    #region student
                    object val;

                    s.studentId = (int)reader.GetValue(reader.GetOrdinal("id"));

                    val = reader.GetValue(reader.GetOrdinal("Roll"));
                    if (val != DBNull.Value)
                    {
                        s.roll = (string)val;
                    }

                    val = reader.GetValue(reader.GetOrdinal("St_name"));
                    if (val != DBNull.Value)
                    {
                        s.name = (string)val;
                    }

                    
                    val = reader.GetValue(reader.GetOrdinal("batch"));
                    if (val != DBNull.Value)
                    {
                        s.batch = (string)val;
                    }

                    #endregion

                    sList.Add(s);
                }
            }
            finally
            {
                connection.Close();
            }
        
            return sList;
        }

        public static Boolean parseStudentID(String StdID, StudentSearchCriteria sc)
        {
            Boolean retValue = false;
            if (StdID.Length == 6)
            {
                sc.Batch = StdID.Substring(0, 2);
                sc.RollExact = StdID.Substring(4, 2);
                retValue = true;
            }
            else if (StdID.Length == 2)
            {
                sc.RollExact = StdID;
                sc.Batch = "";
                retValue = true;
            }
            else if (StdID.Length == 0)
                retValue = true;
            return retValue;
        }

        public static Boolean parseStudentID(String StdID, Student s)
        {
            Boolean retValue = false;
            if (StdID.Length == 6)
            {
                s.Batch = StdID.Substring(0, 2);
                s.Roll = StdID.Substring(4, 2);
                retValue = true;
            }
            else if (StdID.Length == 2)
            {
                s.Roll = StdID;
                s.Batch = "";
                retValue = true;
            }
            return retValue;
        }

        public static Boolean Delete(int stdID)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            string cmdStr = @"DELETE FROM Student WHERE ID = " + stdID;

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
        /*
        /// <summary>
        /// Upgrade this Student object with ImageResult
        /// </summary>
        /// <param name="ir"></param>
        /// <returns></returns>
        public Student Upgrade(ImageResult ir)
        {
            if (ir.GetValue(ResultIndex.Roll) != "")
            {
                this.roll = ir.GetValue(ResultIndex.Roll);
            }

            if (ir.GetValue(ResultIndex.Name) != "")
            {
                this.name = formatName(ir.GetValue(ResultIndex.Name));
            }

            if (ir.GetValue(ResultIndex.FatherName) != "")
            {
                this.fatherName = formatName(ir.GetValue(ResultIndex.FatherName));
            }

            if (ir.GetValue(ResultIndex.Batch) != "")
            {
                try
                {
                    this.batchId = Batch.GetBatchList((int?)null, ir.GetValue(ResultIndex.Batch))[0].BatchId;
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.Phone1) != "")
            {
                this.phone1 = ir.GetValue(ResultIndex.Phone1);
            }

            if (ir.GetValue(ResultIndex.Phone2) != "")
            {
                this.phone2 = ir.GetValue(ResultIndex.Phone2);
            }

            if (ir.GetValue(ResultIndex.Adc) != "")
            {
                this.adc = ir.GetValue(ResultIndex.Adc);
            }

            //**********************************
            if (ir.GetValue(ResultIndex.EmpStatFather) != "")
            {
                this.empStatFather = ir.GetValue(ResultIndex.EmpStatFather);
            }

            if (ir.GetValue(ResultIndex.EmpStatMother) != "")
            {
                this.empStatMother = ir.GetValue(ResultIndex.EmpStatMother);
            }

            if (ir.GetValue(ResultIndex.EmpStatBrother) != "")
            {
                this.empStatBrother = ir.GetValue(ResultIndex.EmpStatBrother);
            }

            if (ir.GetValue(ResultIndex.EmpStatSister) != "")
            {
                this.empStatSister= ir.GetValue(ResultIndex.EmpStatSister);
            }
            //*************************************

            if (ir.GetValue(ResultIndex.FamilyRes) != "")
            {
                try
                {
                    this.familyRes = Int32.Parse(ir.GetValue(ResultIndex.FamilyRes));
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.CollegeName) != "")
            {
                this.collegeName = formatName(ir.GetValue(ResultIndex.CollegeName));
            }

            if (ir.GetValue(ResultIndex.SscGpa) != "")
            {
                try
                {
                    this.sscGpa = Single.Parse(ir.GetValue(ResultIndex.SscGpa));
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.HscGpa) != "")
            {
                try
                {
                    this.hscGpa = Single.Parse(ir.GetValue(ResultIndex.HscGpa));
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.Ompc) != "")
            {
                try
                {
                    this.ompc = Int32.Parse(ir.GetValue(ResultIndex.Ompc));
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.Dob).Length==4)
            {
                try
                {
                    this.dob = DateTime.ParseExact(ir.GetValue(ResultIndex.Dob), "ddMM", System.Globalization.CultureInfo.InstalledUICulture);//Year = current year
                }
                catch { }
            }
            else if (ir.GetValue(ResultIndex.Dob).Length == 6)
            {
                try
                {
                    this.dob = DateTime.ParseExact(ir.GetValue(ResultIndex.Dob), "ddMMyyyy", System.Globalization.CultureInfo.InstalledUICulture);
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.Program) != "")
            {
                try
                {
                    this.programId = Prog.GetProgramList((int?)null, ir.GetValue(ResultIndex.Program))[0].ProgramId;
                }
                catch { }
            }

            //****************************
            if (ir.GetValue(ResultIndex.OccFather) != "")
            {
                this.occFather = ir.GetValue(ResultIndex.OccFather);
            }

            if (ir.GetValue(ResultIndex.OccMother) != "")
            {
                this.occMother = ir.GetValue(ResultIndex.OccMother);
            }

            if (ir.GetValue(ResultIndex.OccBrother) != "")
            {
                this.occBrother = ir.GetValue(ResultIndex.OccBrother);
            }

            if (ir.GetValue(ResultIndex.OccSister) != "")
            {
                this.occSister = ir.GetValue(ResultIndex.OccSister);
            }
            //**************************

            if (ir.GetValue(ResultIndex.Branch) != "")
            {
                try
                {
                    this.branchId = Branch.GetBranchList((int?)null, ir.GetValue(ResultIndex.Branch))[0].BranchId;
                }
                catch { }
            }

            if (ir.GetValue(ResultIndex.PreInstOfSsc) != "")
            {
                this.preInstSsc = ir.GetValue(ResultIndex.PreInstOfSsc);
            }

            if (ir.GetValue(ResultIndex.PreInstOfHsc) != "")
            {
                this.preInstHsc = ir.GetValue(ResultIndex.PreInstOfHsc);
            }

            ////////////
            if (ir.GetValue(ResultIndex.Ffs) != "")
            {
                try
                {
                    this.ffs = Int32.Parse(ir.GetValue(ResultIndex.Ffs));
                }
                catch { }
            }

            ////////////
            if (ir.GetValue(ResultIndex.Ts) != "")
            {
                try
                {
                    this.ts = Int32.Parse(ir.GetValue(ResultIndex.Ts));
                }
                catch { }
            }

            return this;
        }


        
        private string formatName(string name)
        {
            name = name.Trim();

            if (name.Length == 0)
            {
                return "";
            }

            char[] ca = name.ToCharArray();
            ca[0] = Char.ToUpper(ca[0]);

            for (int i = 0; i < ca.Length - 1; i++)
            {
                if (ca[i] == ' ' || ca[i] == '.')
                {
                    ca[i + 1] = Char.ToUpper(ca[i + 1]);
                }
                else
                {
                    ca[i + 1] = Char.ToLower(ca[i + 1]);
                }
            }

            return new String(ca);
        }

 

        public static ccmsDataSet GetStudentInfoDt(List<Student> sList, bool includeBatchName, bool includeBranchName, bool includeProgName, bool includeImage)
        {
            ccmsDataSet ds = new ccmsDataSet();

            foreach (Student s in sList)
            {
                string batchName = "";
                string branchName = "";
                string programName = "";
                byte[] bmpBytes = null;

                if (includeBatchName)
                {
                    batchName = s.batchId == null ? "" : Batch.GetBatchList(s.batchId, (string)null)[0].Name;                                    
                }

                if (includeBranchName)
                {
                    branchName = s.branchId == null ? "" : Branch.GetBranchList(s.branchId, (string)null)[0].Name;
                }

                if (includeProgName)
                {
                    programName = s.programId == null ? "" : Prog.GetProgramList(s.programId, (string)null)[0].Name;
                }
                             
                if (includeImage)
                {
                    StudentImage si = StudentImage.GetStudentImage(s.studentId.Value);
                    if (si.Bmp != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        si.Bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        bmpBytes = ms.ToArray();
                    }
                }


                //be careful! values are sequential
                ds.StudentInfo.Rows.Add(s.studentId, s.roll, s.name, s.batchId, batchName, s.branchId, branchName, s.programId, programName, s.totalPaid, s.programFee - s.totalPaid, s.programFee, bmpBytes, s.admissionDate, s.schoolName, s.collegeName, s.fatherName, s.motherName, s.sscGpa, s.hscGpa, s.phone1 + ", " + s.phone2);
           
            }

            return ds;
        }



        */
    }
}
