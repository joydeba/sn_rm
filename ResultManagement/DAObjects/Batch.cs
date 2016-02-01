using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ResultManagement.DAObjects
{
    class Depertment { 
        public static int StudentIDLength = 6;
        public static int MaxCredit = 25;
        //public static string DepartmentCode = "03";
        //public static string SchoolName = "Management and Business Administration School";
        //public static string DisciplineName = "Business Administration Discipline";
        public static string DepartmentCode = "02";
        public static string SchoolName = "Science Engineering and Technology School";
        public static string DisciplineName = "Computer Science and Engineering Discipline";
    }

    class Batch
    {

        #region Private Members

        private string batchID;

        private string batchName;

        #endregion

        #region Properties

        public string BatchID
        {
            get { return batchID; }
            set { 
                if(value == "")
                    batchID = null;
                else
                    batchID = value;
            }
        }
        public string BatchName
        {
            get { return batchName; }
            set {
                if (value == "")
                    batchName = null;
                else
                    batchName = value;
            }
        }

        #endregion

        public static List<Batch> getAllBatchList(string batchName)
        {
            OleDbConnection connection = new OleDbConnection(global::ResultManagement.Properties.Settings.Default.ConnectionString);

            String cmdString = @"SELECT batch 
                               FROM Student WHERE 1 ";

            if (batchName != null)
            {
                cmdString += " AND batch = '" + batchName + "'";
            }

            cmdString += " GROUP BY batch";

            OleDbCommand cmd = new OleDbCommand(cmdString, connection);

            List<Batch> batchList = new List<Batch>();

            try
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Batch b = new Batch();
                    b.batchName = (string)reader.GetValue(reader.GetOrdinal("batch"));
                    b.batchID = b.batchName;
                    batchList.Add(b);
                }
            }
            finally
            {
                connection.Close();
            }

            return batchList;
        }

        public static Batch getAllMapping()
        {
            Batch b = new Batch();
            b.batchID = null;
            b.batchName = "(All)";
            return b;
        }
    }
    
    class Year
    {
        private int? yearID;
        private string yearName;

        public int? YearID
        {
            get { return yearID; }
            set { yearID = value; }
        }

        public string YearName
        {
            get { return yearName; }
            set
            {
                if (value == "")
                    yearName = null;
                else
                    yearName = value;
            }
        }

        public Year(int? yearID, string yearName)
        {
            this.YearID = yearID;
            this.YearName = yearName;
        }

        public static List<Year> getYearList()
        {
            List<Year> yearList = new List<Year>();
            yearList.Add(new Year(1, "1st"));
            yearList.Add(new Year(2, "2nd"));
            yearList.Add(new Year(3, "3rd"));
            yearList.Add(new Year(4, "4th"));

            return yearList;
        }

        public static List<Year> getYearListWithAllMapping()
        {
            List<Year> yearList = getYearList();
            yearList.Insert(0, getAllMapping());
            return yearList;
        }

        public static Year getAllMapping()
        {
            Year year = new Year(null, "(All)");
            return year;
        }
    }

    class Term
    {
        private int? termID;
        private string termName;

        public int? TermID
        {
            get { return termID; }
            set { termID = value; }
        }

        public string TermName
        {
            get { return termName; }
            set
            {
                if (value == "")
                    termName = null;
                else
                    termName = value;
            }
        }

        public Term(int? termID, string termName)
        {
            this.TermID = termID;
            this.TermName = termName;
        }

        public static List<Term> getTermList()
        {
            List<Term> termList = new List<Term>();
            termList.Add(new Term(1, "I"));
            termList.Add(new Term(2, "II"));

            return termList;
        }

        public static List<Term> getTermListWithAllMapping()
        {
            List<Term> termList = getTermList();
            termList.Insert(0, getAllMapping());
            return termList;
        }

        public static Term getAllMapping()
        {
            Term term = new Term(null, "(All)");
            return term;
        }
    }

    public enum UpdateType
    {
        None = 0,
        Update = 1,
        Insert = 2,
        Delete = 3
    }
}
