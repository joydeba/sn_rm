using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ResultManagement.DAObjects;
using ResultManagement.DAObjects.ResultCourseWiseDataSetTableAdapters;
using ResultManagement.DAObjects.ResultStudentWiseDataSetTableAdapters;
using ResultManagement.Reports;

namespace ResultManagement
{
    public partial class ResultUserControl : UserControl
    {
        private List<Session> sessionList;
        private List<Course> courseList;
        private List<Year> yearList;
        private List<Term> termList;
        private Student student;

        public ResultUserControl()
        {
            InitializeComponent();
            initControls();
        }

        public void initControls()
        {
            sessionList = Session.getSessionList(null, null);
            courseList = Course.getCourseListOfATerm(null, null);
            yearList = Year.getYearList();
            termList = Term.getTermList();

            StudentWiseSessionComboBox.DataSource = sessionList;
            StudentWiseSessionComboBox.DisplayMember = "sessionName";
            StudentWiseSessionComboBox.ValueMember = "sessionID";
            StudentWiseSessionComboBox.SelectedIndex = 0;

            CourseWiseSessionComboBox.DataSource = sessionList;
            CourseWiseSessionComboBox.DisplayMember = "sessionName";
            CourseWiseSessionComboBox.ValueMember = "sessionID";
            CourseWiseSessionComboBox.SelectedIndex = 0;

            StudentWiseYearComboBox.DataSource = yearList;
            StudentWiseYearComboBox.DisplayMember = "yearName";
            StudentWiseYearComboBox.ValueMember = "yearID";
            StudentWiseYearComboBox.SelectedIndex = 0;

            CourseWiseYearComboBox.DataSource = yearList;
            CourseWiseYearComboBox.DisplayMember = "yearName";
            CourseWiseYearComboBox.ValueMember = "yearID";
            CourseWiseYearComboBox.SelectedIndex = 0;

            StudentWiseTermComboBox.DataSource = termList;
            StudentWiseTermComboBox.DisplayMember = "termName";
            StudentWiseTermComboBox.ValueMember = "termID";
            StudentWiseTermComboBox.SelectedIndex = 0;

            CourseWiseTermComboBox.DataSource = termList;
            CourseWiseTermComboBox.DisplayMember = "termName";
            CourseWiseTermComboBox.ValueMember = "termID";
            CourseWiseTermComboBox.SelectedIndex = 0;

            CourseWiseCourseNoComboBox.DataSource = courseList;
            CourseWiseCourseNoComboBox.DisplayMember = "displayableCourseNumber";
            CourseWiseCourseNoComboBox.ValueMember = "ID";
            if (courseList.Count>0)
                CourseWiseCourseNoComboBox.SelectedIndex = 0;

            try
            {
                Settings s = new Settings("Settings.xml");

                this.StudentWiseSessionComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);
                this.CourseWiseSessionComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);

                this.StudentWiseYearComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                this.CourseWiseYearComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);

                this.CourseWiseTermComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
                this.CourseWiseTermComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void StudentWiseStdIDTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (StudentWiseStdIDTextBox.Text.Length != 6)
            {
                StudentWiseStdNameLabel.ForeColor = Color.Red;
                StudentWiseStdNameLabel.Text = "Name: Invalid Student ID";
                StudentWisePrintSingleButton.Enabled = false;
                student = null;
                return;
            }
            else
            {
                student = Student.getStudent(StudentWiseStdIDTextBox.Text);
                if (student == null)
                {
                    StudentWiseStdNameLabel.ForeColor = Color.Red;
                    StudentWiseStdNameLabel.Text = "Name: Student ID " + StudentWiseStdIDTextBox.Text + " dosen't Exist";
                    StudentWisePrintSingleButton.Enabled = false;
                }
                else
                {
                    StudentWiseStdNameLabel.ForeColor = Color.Green;
                    StudentWiseStdNameLabel.Text = "Name: " + student.Name;
                    StudentWisePrintSingleButton.Enabled = true;
                }
            }
        }

        private void CourseWiseCourseNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseWiseTitleLabel.Text = "Title: "+courseList[CourseWiseCourseNoComboBox.SelectedIndex].Title;
        }

        private void CourseWisePrintSelectedButton_Click(object sender, EventArgs e)
        {
            ResultCourseWiseDataSet ds = new ResultCourseWiseDataSet();
            //course
            ResultCourseWiseTableAdapter resultCourseWiseTableAdapter = new ResultCourseWiseTableAdapter();
            resultCourseWiseTableAdapter.FillBy(ds.ResultCourseWiseDataTable, (int)CourseWiseSessionComboBox.SelectedValue, (int)CourseWiseCourseNoComboBox.SelectedValue);
            ReportForm rf = new ReportForm();
            rf.Show();
            bool isTheory = int.Parse(courseList[CourseWiseCourseNoComboBox.SelectedIndex].Course_No) % 2 == 1;
            if (isTheory)
            {
                ResultCourseWiseAllTheoryCR report = new ResultCourseWiseAllTheoryCR();
                report.SetDataSource(ds);
                report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
                report.SetParameterValue("SchoolName", Depertment.SchoolName);
                rf.crystalReportViewer1.ReportSource = report;
            }
            else
            {
                ResultCourseWiseAllSessionalCR report = new ResultCourseWiseAllSessionalCR();
                report.SetDataSource(ds);
                report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
                report.SetParameterValue("SchoolName", Depertment.SchoolName);
                rf.crystalReportViewer1.ReportSource = report;
            }
        }

        private void CourseWisePrintAllTheoryButton_Click(object sender, EventArgs e)
        {
            ResultCourseWiseDataSet ds = new ResultCourseWiseDataSet();
            ResultCourseWiseTableAdapter resultCourseWiseTableAdapter = new ResultCourseWiseTableAdapter();
            int isTheory = 1;
            resultCourseWiseTableAdapter.FillAllBy(ds.ResultCourseWiseDataTable, (int)CourseWiseSessionComboBox.SelectedValue, (int)CourseWiseYearComboBox.SelectedValue, (int)CourseWiseTermComboBox.SelectedValue, isTheory);
            ReportForm rf = new ReportForm();
            rf.Show();
            ResultCourseWiseAllTheoryCR report = new ResultCourseWiseAllTheoryCR();
            report.SetDataSource(ds);
            report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
            report.SetParameterValue("SchoolName", Depertment.SchoolName);
            rf.crystalReportViewer1.ReportSource = report;

        }

        private void CourseWisePrintAllSessionalButton_Click(object sender, EventArgs e)
        {
            ResultCourseWiseDataSet ds = new ResultCourseWiseDataSet();
            ResultCourseWiseTableAdapter resultCourseWiseTableAdapter = new ResultCourseWiseTableAdapter();
            int isTheory = 0;
            resultCourseWiseTableAdapter.FillAllBy(ds.ResultCourseWiseDataTable, (int)CourseWiseSessionComboBox.SelectedValue, (int)CourseWiseYearComboBox.SelectedValue, (int)CourseWiseTermComboBox.SelectedValue, isTheory);
            ReportForm rf = new ReportForm();
            rf.Show();
            ResultCourseWiseAllSessionalCR report = new ResultCourseWiseAllSessionalCR();
            report.SetDataSource(ds);
            report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
            report.SetParameterValue("SchoolName", Depertment.SchoolName);
            rf.crystalReportViewer1.ReportSource = report;

        }

        private void StudentWisePrintAllButton_Click(object sender, EventArgs e)
        {
            ResultStudentWiseDataSet ds = new ResultStudentWiseDataSet();
            ResultStudentWiseTableAdapter resultStudentWiseTableAdapter = new ResultStudentWiseTableAdapter();
            resultStudentWiseTableAdapter.FillAllBy(ds.ResultStudentWiseDataTable, (int)StudentWiseSessionComboBox.SelectedValue, (int)StudentWiseYearComboBox.SelectedValue, (int)StudentWiseTermComboBox.SelectedValue);
            ReportForm rf = new ReportForm();
            rf.Show();
            ResultStudentWiseCR report = new ResultStudentWiseCR();
            report.SetDataSource(ds);
            report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
            report.SetParameterValue("SchoolName", Depertment.SchoolName);
            rf.crystalReportViewer1.ReportSource = report;
        }

        private void StudentWisePrintSingleButton_Click(object sender, EventArgs e)
        {
            if (student.StudentId != null)
            {
                ResultStudentWiseDataSet ds = new ResultStudentWiseDataSet();
                ResultStudentWiseTableAdapter resultStudentWiseTableAdapter = new ResultStudentWiseTableAdapter();
                resultStudentWiseTableAdapter.FillStudentBy(ds.ResultStudentWiseDataTable, (int)StudentWiseSessionComboBox.SelectedValue, (int)StudentWiseYearComboBox.SelectedValue, (int)StudentWiseTermComboBox.SelectedValue,(int)student.StudentId);
                ReportForm rf = new ReportForm();
                rf.Show();
                ResultStudentWiseCR report = new ResultStudentWiseCR();
                report.SetDataSource(ds);
                report.SetParameterValue("DisciplineName", Depertment.DisciplineName);
                report.SetParameterValue("SchoolName", Depertment.SchoolName);
                rf.crystalReportViewer1.ReportSource = report;
            }
            else
            {
                MessageBox.Show("No such Student");
            }
        }
    }
}
