using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ResultManagement.DAObjects;
using ResultManagement.Reports;
using ResultManagement.DAObjects.ResultCourseWiseDataSetTableAdapters;

namespace ResultManagement
{
    public partial class MarksEntryControl : UserControl
    {
        private int currentValue = 0;
        private int SelectedColumn = 0;
        private List<Registration_and_Marks> marksList;
        private List<Course> courseList;
        private bool isTheory = false;
        public MarksEntryControl()
        {
            InitializeComponent();
            initControls();
        }
        private void initControls()
        {
            SessionToolStripComboBox.ComboBox.DataSource = Session.getSessionList((int?)null, (string)null); ;
            SessionToolStripComboBox.ComboBox.DisplayMember = "sessionName";
            SessionToolStripComboBox.ComboBox.ValueMember = "sessionID";
            SessionToolStripComboBox.SelectedIndex = 0;
            SessionLabel.Text = SessionToolStripComboBox.Text;

            courseList = Course.getCourseListOfATerm((int?)null, (int?)null);
            CourseNoToolStripComboBox.ComboBox.DataSource = courseList;
            CourseNoToolStripComboBox.ComboBox.DisplayMember = "DisplayableCourseNumberWithTitle";
            CourseNoToolStripComboBox.ComboBox.ValueMember = "ID";
            if (courseList.Count > 0)
            {
                CourseNoToolStripComboBox.SelectedIndex = 0;
                CourseNoLabel.Text = CourseNoToolStripComboBox.Text + " | " + courseList[0].Title;
            }
            try
            {
                Settings s = new Settings("Settings.xml");

                SessionToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SessionToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SessionLabel.Text = SessionToolStripComboBox.Text;
        }

        private void CourseNoToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CourseNoLabel.Text = CourseNoToolStripComboBox.Text + " | " + courseList[CourseNoToolStripComboBox.SelectedIndex].Title;
            isTheory = int.Parse(courseList[CourseNoToolStripComboBox.SelectedIndex].Course_No) % 2 == 1;
        }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            marksList = Registration_and_Marks.getAllRegistrationList
                ((int?)SessionToolStripComboBox.ComboBox.SelectedValue, null, null, null,
                    (int?)CourseNoToolStripComboBox.ComboBox.SelectedValue, null);
            //marksList.Sort(
            CourseNoLabel.Text = courseList[CourseNoToolStripComboBox.SelectedIndex].DisplayableCourseNumber + " | " + courseList[CourseNoToolStripComboBox.SelectedIndex].Title;
            dataGridView1.Rows.Clear();
            //if (int.Parse(CourseNoToolStripComboBox.ComboBox.Text.Substring(CourseNoToolStripComboBox.ComboBox.Text.Length-2,2)) % 2 == 0)
            if(!isTheory)
            {
                CT_or_VivaColumn.HeaderText = "Viva (30)";
                SA_or_secAColumn.HeaderText = "Sessional Assesment (60)";
                SecBColumn.Visible = false;
                isTheory = false;
            }
            else
            {
                CT_or_VivaColumn.HeaderText = "CT (30)";
                SA_or_secAColumn.HeaderText = "Section A (30)";
                SecBColumn.Visible = true;
                isTheory = true;
            }
            //marksList.Sort();
            for (int i = 0; i < marksList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1["MarksIDColumn", i].Value = marksList[i].Marks.MarksID;
                dataGridView1["StdIDColumn", i].Value = marksList[i].Student.DisplayableStudentID;
                dataGridView1["AttendenceColumn", i].Value = marksList[i].Marks.Attendence;
                dataGridView1["CT_or_VivaColumn", i].Value = marksList[i].Marks.Ct_or_Viva;
                dataGridView1["SA_or_SecAColumn", i].Value = marksList[i].Marks.SA_or_SecA;
                dataGridView1["SecBColumn", i].Value = marksList[i].Marks.SecB;
                dataGridView1["RetakeColumn", i].Value = marksList[i].Marks.IsRetake;
                dataGridView1["TotalColumn", i].Value = marksList[i].Marks.Total;
                dataGridView1["GPColumn", i].Value = calculateGP(marksList[i].Marks.Total, marksList[i].Marks.IsRetake);
                dataGridView1["GradeColumn", i].Value = calculateGrade(marksList[i].Marks.Total, marksList[i].Marks.IsRetake);
                dataGridView1.Rows[i].Tag = UpdateType.None;
                
            }
        }
        private float calculateGP(int mark, bool? retake)
        {
            float gp = 0;
            if (retake == true && mark >= 80)
                mark = Math.Min(mark - 5, 79);
            else if (retake == true && mark >= 40)
                mark = Math.Max(mark - 5, 40);

            if (mark >= 80)
                gp = 4;
            else if (mark >= 75)
                gp = 3.75f;
            else if (mark >= 70)
                gp = 3.5f;
            else if (mark >= 65)
                gp = 3.25f;
            else if (mark >= 60)
                gp = 3;
            else if (mark >= 55)
                gp = 2.75f;
            else if (mark >= 50)
                gp = 2.5f;
            else if (mark >= 45)
                gp = 2.25f;
            else if (mark >= 40)
                gp = 2;
            return gp;
        }
        private string calculateGrade(int mark, bool? retake)
        {
            string grade = "F";
            if (retake == true && mark >= 80)
                mark = Math.Min(mark - 5, 79);
            else if (retake == true && mark >= 40)
                mark = Math.Max(mark - 5, 40);
             

            if (mark >= 80)
                grade = "A+";
            else if (mark >= 75)
                grade = "A";
            else if (mark >= 70)
                grade = "A-";
            else if (mark >= 65)
                grade = "B+";
            else if (mark >= 60)
                grade = "B";
            else if (mark >= 55)
                grade = "B-";
            else if (mark >= 50)
                grade = "C+";
            else if (mark >= 45)
                grade = "C";
            else if (mark >= 40)
                grade = "D";
            return grade;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value==null)
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
            else if(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()=="")
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
            int attendence = 0, ct_viva = 0, sa_secA = 0, secB = 0;
            attendence = int.Parse(dataGridView1["AttendenceColumn", e.RowIndex].Value.ToString());
            if (attendence > 10)
            {
                MessageBox.Show("Attendence must be less than or equal 10");
                dataGridView1["AttendenceColumn", e.RowIndex].Value = currentValue;
            }    
            
            ct_viva = int.Parse(dataGridView1["CT_or_VivaColumn", e.RowIndex].Value.ToString());
            if(ct_viva>30)
            {
                if(isTheory)
                    MessageBox.Show("CT must be less than or equal 30");
                else
                    MessageBox.Show("Viva must be less than or equal 30");
                dataGridView1["CT_or_VivaColumn", e.RowIndex].Value = currentValue;
            }
            sa_secA = int.Parse(dataGridView1["SA_or_SecAColumn", e.RowIndex].Value.ToString());
            if (isTheory)
            {
                if (sa_secA > 30)
                {
                    MessageBox.Show("Section A must be less than or equal 30");
                    dataGridView1["SA_or_SecAColumn", e.RowIndex].Value = currentValue;
                }
            }
            else
            {
                if (sa_secA > 60)
                {
                    MessageBox.Show("Sessional Assesment must be less than or equal 60");
                    dataGridView1["SA_or_SecAColumn", e.RowIndex].Value = currentValue;
                }
            }
            secB = int.Parse(dataGridView1["SecBColumn", e.RowIndex].Value.ToString());
            if (secB > 30)
            {
                MessageBox.Show("Section B must be less than or equal 30");
                dataGridView1["SecBColumn", e.RowIndex].Value = currentValue;
            }

            int total = attendence + ct_viva + sa_secA + secB;
            dataGridView1["TotalColumn", e.RowIndex].Value = total;
            dataGridView1["GPColumn", e.RowIndex].Value = calculateGP(total, (bool?)dataGridView1["RetakeColumn", e.RowIndex].Value);
            dataGridView1["GradeColumn", e.RowIndex].Value = calculateGrade(total, (bool?)dataGridView1["RetakeColumn", e.RowIndex].Value);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric_KeyPress);
        }
        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean nonNumberEntered = true;

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                nonNumberEntered = false;
            }

            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            currentValue = int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            this.dataGridView1.Rows[e.RowIndex].Tag = UpdateType.Update;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No row to update");
                return;
            }
            int updateFailureCounter = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Update)
                {
                    for (int j = 0; j < marksList.Count; j++)
                    {
                        if ((int?)dataGridView1["MarksIDColumn", i].Value == marksList[j].Marks.MarksID)
                        {
                            marksList[j].Marks.Attendence = (int?)int.Parse(dataGridView1["AttendenceColumn", i].Value.ToString());
                            marksList[j].Marks.Ct_or_Viva = (int?)int.Parse(dataGridView1["CT_or_VivaColumn", i].Value.ToString());
                            marksList[j].Marks.SA_or_SecA = (int?)int.Parse(dataGridView1["SA_or_SecAColumn", i].Value.ToString());
                            marksList[j].Marks.SecB = (int?)int.Parse(dataGridView1["SecBColumn", i].Value.ToString());
                            if (!Registration_and_Marks.Update(marksList[j]))
                                updateFailureCounter++;
                            break;
                        }
                    }
                }
            }
            if (updateFailureCounter == 0)
                MessageBox.Show("Updated Successfully");
            else
                MessageBox.Show(updateFailureCounter + " rows failed to update");
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            SearchToolStripButton.PerformClick();
        }

        private void AutoAttendenceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1["AttendenceColumn", i].Value = 10;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ResultCourseWiseDataSet ds = new ResultCourseWiseDataSet();
            //course
            ResultCourseWiseTableAdapter resultCourseWiseTableAdapter = new ResultCourseWiseTableAdapter();
            resultCourseWiseTableAdapter.FillBy(ds.ResultCourseWiseDataTable,(int)SessionToolStripComboBox.ComboBox.SelectedValue, (int)CourseNoToolStripComboBox.ComboBox.SelectedValue);
            ReportForm rf = new ReportForm();
            rf.Show();
            if (isTheory)
            {
                ResultCourseWiseAllTheoryCR report = new ResultCourseWiseAllTheoryCR();
                report.SetDataSource(ds);
                rf.crystalReportViewer1.ReportSource = report;
            }
            else
            {
                ResultCourseWiseAllSessionalCR report = new ResultCourseWiseAllSessionalCR();
                report.SetDataSource(ds);
                rf.crystalReportViewer1.ReportSource = report;
            }
        }

        private void ReloadCourseToolStripButton_Click(object sender, EventArgs e)
        {
            initControls();
        }

        private void ClearColumnButton_Click(object sender, EventArgs e)
        {
            if (SelectedColumn <2 || SelectedColumn >5)
                return;
            int total = 0, attendence = 0, ct_viva = 0, sa_secA = 0, secB = 0; ;
            for(int i=0;i<dataGridView1.RowCount;i++)
            {
                dataGridView1[SelectedColumn, i].Value = 0;
                attendence = 0;
                ct_viva = 0;
                sa_secA = 0;
                secB = 0;
                total = 0;

                attendence = int.Parse(dataGridView1["AttendenceColumn", i].Value.ToString());
                ct_viva = int.Parse(dataGridView1["CT_or_VivaColumn", i].Value.ToString());
                sa_secA = int.Parse(dataGridView1["SA_or_SecAColumn", i].Value.ToString());
                secB = int.Parse(dataGridView1["SecBColumn", i].Value.ToString());
                
                total = attendence + ct_viva + sa_secA + secB;
                dataGridView1["TotalColumn", i].Value = total;
                dataGridView1["GPColumn", i].Value = calculateGP(total, (bool?)dataGridView1["RetakeColumn", i].Value);
                dataGridView1["GradeColumn", i].Value = calculateGrade(total, (bool?)dataGridView1["RetakeColumn", i].Value);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedColumn = e.ColumnIndex;
        }

    }
}
