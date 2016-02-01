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
    public partial class CourseUserControl : UserControl
    {

        private List<Course> courseList=new List<Course>();

        public CourseUserControl()
        {
            InitializeComponent();
            initControl();
        }
        public void initControl()
        {
            YearToolStripComboBox.ComboBox.DataSource = Year.getYearListWithAllMapping();
            YearToolStripComboBox.ComboBox.DisplayMember = "yearName";
            YearToolStripComboBox.ComboBox.ValueMember = "yearID";
            YearToolStripComboBox.ComboBox.SelectedIndex = 0;

            TermToolStripComboBox.ComboBox.DataSource = Term.getTermListWithAllMapping();
            TermToolStripComboBox.ComboBox.DisplayMember = "termName";
            TermToolStripComboBox.ComboBox.ValueMember = "termID";
            TermToolStripComboBox.ComboBox.SelectedIndex = 0;

            dataGridView1.Rows.Clear();

            try
            {
                Settings s = new Settings("Settings.xml");

                YearToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                TermToolStripComboBox.ComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadToolStripButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            courseList= Course.getCourseListOfATerm((int?)YearToolStripComboBox.ComboBox.SelectedValue, (int?)TermToolStripComboBox.ComboBox.SelectedValue);
            for (int i = 0; i < courseList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Tag = UpdateType.None;
                dataGridView1["courseIDColumn", i].Value = courseList[i].ID;
                dataGridView1["coursePrefixColumn", i].Value = courseList[i].Prefix;
                dataGridView1["courseNumberColumn", i].Value = courseList[i].Year.ToString() + courseList[i].Term.ToString() + courseList[i].Course_No;
                dataGridView1["courseTitleColumn", i].Value = courseList[i].Title;
                dataGridView1["CreditHourColumn", i].Value = courseList[i].Credit;
                dataGridView1["IsOptionalColumn", i].Value = courseList[i].Is_Optional;
                dataGridView1.Rows[i].Tag = UpdateType.None;
            }
            NumberOfCoursesTextBox.Text = courseList.Count.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
            //return;
            if (e.RowIndex < 0)
                return;
            //if (e.RowIndex == 0)
                //dataGridView1.Rows[e.RowIndex].Tag = UpdateType.None;
            else
                //dataGridView1.Rows[e.RowIndex - 1].Tag = UpdateType.Insert;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = UpdateType.Insert;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 )
                return;
            //try
            {
                if ((UpdateType)dataGridView1.Rows[e.RowIndex].Tag != UpdateType.Insert)
                {
                    dataGridView1.Rows[e.RowIndex].Tag = UpdateType.Update;
                }
            }
            //catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || e.RowIndex == dataGridView1.RowCount-1)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                if ((UpdateType)dataGridView1.Rows[e.RowIndex].Tag == UpdateType.Insert)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Tag = UpdateType.Delete;
                    dataGridView1.Rows[e.RowIndex].Visible = false;
                }
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            int deleteFailureCounter = 0, updateFailureCounter = 0, insertFailureCounter = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Delete)
                {
                    if (!Course.Delete((int?)dataGridView1["courseIDColumn",i].Value))
                    {
                        deleteFailureCounter++;
                    }
                }
                else if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Insert)
                {
                    Course course = new Course();
                    course.Prefix = (string)dataGridView1["CoursePrefixColumn", i].Value;
                    course.Title = (string)dataGridView1["CourseTitleColumn", i].Value;
                    course.Is_Optional = (bool?)dataGridView1["IsOptionalColumn", i].Value;
                    string CourseNumber = (string)dataGridView1["courseNumberColumn", i].Value;
                    if (CourseNumber.Length == 4)
                    {
                        int courseYear = int.Parse(CourseNumber[0].ToString());
                        if (courseYear > 0 && courseYear <= 4)
                        {
                            int courseTerm = int.Parse(CourseNumber[1].ToString());
                            if (courseTerm > 0 && courseTerm <= 2)
                            {
                                course.Year = courseYear;
                                course.Term = courseTerm;
                                course.Course_No = CourseNumber.Substring(2, 2);
                                try
                                {
                                    course.Credit = (decimal?)decimal.Parse("0" + dataGridView1["CreditHourColumn", i].Value.ToString());
                                    if (!course.Insert())
                                    {
                                        insertFailureCounter++;
                                    }
                                    courseList.Add(course);
                                    dataGridView1.Rows[i].Tag = UpdateType.Update;
                                }
                                catch {
                                    insertFailureCounter++;
                                }
                            }
                            else
                                insertFailureCounter++;
                        }
                        else
                            insertFailureCounter++;
                    }
                    else
                        insertFailureCounter++;
                }
                else if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Update)
                { 
                    Course course = courseList[i];
                    course.ID = (int?)dataGridView1["CourseIDColumn", i].Value;
                    course.Prefix = (string)dataGridView1["CoursePrefixColumn", i].Value;
                    course.Title = (string)dataGridView1["CourseTitleColumn", i].Value;
                    course.Is_Optional = (bool?)dataGridView1["IsOptionalColumn", i].Value;
                    string CourseNumber = (string)dataGridView1["courseNumberColumn", i].Value;
                    if (CourseNumber.Length == 4)
                    {
                        int courseYear = int.Parse(CourseNumber[0].ToString());
                        if (courseYear > 0 && courseYear <= 4)
                        {
                            int courseTerm = int.Parse(CourseNumber[1].ToString());
                            if (courseTerm > 0 && courseTerm <= 2)
                            {
                                course.Year = courseYear;
                                course.Term = courseTerm;
                                course.Course_No = CourseNumber.Substring(2, 2);
                                try
                                {
                                    course.Credit = (decimal?)decimal.Parse("0" + dataGridView1["CreditHourColumn", i].Value.ToString());
                                    if (!course.Update())
                                    {
                                        updateFailureCounter++;
                                    }
                                }
                                catch
                                {
                                    updateFailureCounter++;
                                }
                            }
                            else
                                updateFailureCounter++;
                        }
                        else
                            updateFailureCounter++;
                    }
                    else
                        updateFailureCounter++;
                }
            }
            if (updateFailureCounter == 0 && deleteFailureCounter == 0 && insertFailureCounter == 0)
                MessageBox.Show("Updated Successfully");
            else
            {
                string s = "";
                if(deleteFailureCounter != 0)
                    s+=deleteFailureCounter + " rows failed to delete.\r\n";
                if(updateFailureCounter != 0)
                    s += updateFailureCounter + " rows failed to update.Pssible Reason is Duplicate/Invalid Course Number or Invalid Credit Hour\r\n";
                if(insertFailureCounter != 0)
                    s += insertFailureCounter + " rows failed to Insert. Pssible Reason is Duplicate/Invalid Course Number or Invalid Credit Hour";
                MessageBox.Show(s);
            }
        }
    }
}
