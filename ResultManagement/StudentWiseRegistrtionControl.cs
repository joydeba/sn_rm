using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ResultManagement.DAObjects;

namespace ResultManagement
{
    public partial class StudentWiseRegistrtionControl : UserControl
    {

        private List<Session> sessionList;// = new List<Session>();
        private List<Batch> batchList;

        public StudentWiseRegistrtionControl()
        {
            InitializeComponent();
            initControls();
        }

        public void initControls()
        {
            sessionList = Session.getSessionList((int?)null,(string)null);
            sessionList.Insert(0, Session.GetAllMapping());

            batchList = Batch.getAllBatchList((string)null);
            batchList.Insert(0, Batch.getAllMapping());

            SessionToolStripComboBox.ComboBox.DataSource = sessionList;
            SessionToolStripComboBox.ComboBox.DisplayMember = "sessionName";
            SessionToolStripComboBox.ComboBox.ValueMember = "sessionID";
            SessionToolStripComboBox.SelectedIndex = 0;

            BatchToolStripComboBox.ComboBox.DataSource = batchList;
            BatchToolStripComboBox.ComboBox.DisplayMember = "BatchName";
            BatchToolStripComboBox.ComboBox.ValueMember = "BatchID";
            BatchToolStripComboBox.SelectedIndex = 0;

            YearToolStripComboBox.ComboBox.DataSource = Year.getYearListWithAllMapping();
            YearToolStripComboBox.ComboBox.DisplayMember = "yearName";
            YearToolStripComboBox.ComboBox.ValueMember = "yearID";
            YearToolStripComboBox.SelectedIndex = 0;

            TermToolStripComboBox.ComboBox.DataSource = Term.getTermListWithAllMapping();
            TermToolStripComboBox.ComboBox.DisplayMember = "TermName";
            TermToolStripComboBox.ComboBox.ValueMember = "TermID";
            TermToolStripComboBox.SelectedIndex = 0;

            try
            {
                Settings s = new Settings("Settings.xml");

                SessionToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);
                YearToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                TermToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            string batch = (string)this.BatchToolStripComboBox.ComboBox.SelectedValue;
            List<Registration_and_Marks>
                registration_and_marksList = Registration_and_Marks.getAllRegistrationList(
                                                (int?)this.SessionToolStripComboBox.ComboBox.SelectedValue,
                                                batch,
                                                (int?)this.YearToolStripComboBox.ComboBox.SelectedValue,
                                                (int?)this.TermToolStripComboBox.ComboBox.SelectedValue, (int?)null, (int?)null);
            int numOfCol = Registration_and_Marks.getMaxNumberOfRegistration(
                                                (int?)this.SessionToolStripComboBox.ComboBox.SelectedValue,
                                                batch,
                                                (int?)this.YearToolStripComboBox.ComboBox.SelectedValue,
                                                (int?)this.TermToolStripComboBox.ComboBox.SelectedValue);
            showStudent(numOfCol, registration_and_marksList);
        }

        public void showStudent(int numOfCol, List<Registration_and_Marks> reg_and_mark_List)
        {
            dataGridView1.Rows.Clear();
            for (int i = 6; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < numOfCol; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "Course" + i; //ColId
                col.HeaderText = "Course " + (i + 1);
                //col.Width = 100;
                this.dataGridView1.Columns.Add(col);
            }
            int listIterator = 0;
            for (int i = 0; ; i++)
            {
                if (listIterator >= reg_and_mark_List.Count)
                    break;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["stdIDColumn"].Value = reg_and_mark_List[listIterator].Student.StudentId;
                dataGridView1.Rows[i].Cells["SessionIDColumn"].Value = reg_and_mark_List[listIterator].Session.SessionID;
                dataGridView1.Rows[i].Cells["SessionColumn"].Value = reg_and_mark_List[listIterator].Session.SessionName;
                dataGridView1.Rows[i].Cells["regYearColumn"].Value = reg_and_mark_List[listIterator].Reg_Year;
                dataGridView1.Rows[i].Cells["regTermColumn"].Value = reg_and_mark_List[listIterator].Reg_Term;
                //int? reg_Year = reg_and_mark_List[listIterator].Reg_Year;
                //int? reg_Term = reg_and_mark_List[listIterator].Reg_Term;
                int? reg_session_ID = reg_and_mark_List[listIterator].Registered_Session_ID;
                string roll = reg_and_mark_List[listIterator].Student.Roll;
                string stdID = reg_and_mark_List[listIterator].Student.Batch + Depertment.DepartmentCode + roll;
                int j = 0;
                
                dataGridView1.Rows[i].Cells["StudentIDColumn"].Value = stdID;
                if (reg_and_mark_List[listIterator].Course.ID != null)
                {
                    string disPlayableCourseNumber = reg_and_mark_List[listIterator + j].Course.DisplayableCourseNumber;
                    if (reg_and_mark_List[listIterator + j].Marks.IsRetake == true)
                        disPlayableCourseNumber += " (R)";
                    dataGridView1.Rows[i].Cells["Course" + j++].Value = disPlayableCourseNumber;
                }
                for (  ; ; j++)
                {
                    if (listIterator + j < reg_and_mark_List.Count && reg_and_mark_List[listIterator + j].Registered_Session_ID == reg_session_ID)
                    {
                        if (reg_and_mark_List[listIterator + j].Course.ID != null)
                        {
                            string disPlayableCourseNumber=reg_and_mark_List[listIterator + j].Course.DisplayableCourseNumber;
                            if (reg_and_mark_List[listIterator + j].Marks.IsRetake==true)
                                disPlayableCourseNumber += " (R)";
                            dataGridView1.Rows[i].Cells["Course" + j].Value = disPlayableCourseNumber;
                        }
                    }
                    else
                        break;
                }
                listIterator = listIterator + j;
            }
            numberOfRegisteredStudentsLabel.Text = dataGridView1.RowCount.ToString();
        }

        private void NewRegistrationToolStripButton_Click(object sender, EventArgs e)
        {
            NewRegistrationForm newRegistrationForm = new NewRegistrationForm();
            newRegistrationForm.Show();
            //newRegistrationForm.registrationFormControl1.LoadCoursesButton.PerformClick();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int session = (int)dataGridView1["SessionIDColumn", e.RowIndex].Value;
            int stdID = (int)dataGridView1["stdIDColumn", e.RowIndex].Value;
            int year = (int)dataGridView1["regYearColumn", e.RowIndex].Value;
            int term = (int)dataGridView1["regTermColumn", e.RowIndex].Value;
            NewRegistrationForm newRegistrationForm = new NewRegistrationForm(session,year,term,stdID);
            newRegistrationForm.Show();
            //newRegistrationForm.registrationFormControl1.LoadCoursesButton.PerformClick();
        }
    }
}
