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
    public partial class RegistrationFormControl : UserControl
    {
        decimal creditsTaken = 0;
        private List<Course> courseList;
        private int? sessionID;
        private int? year;
        private int? term;
        private int? stdID;
        private int? Registered_Session_ID;
        private List<Registration_and_Marks> registeredCourseList;
        
        public RegistrationFormControl()
        {
            InitializeComponent();
            initControls();
            courseList = Course.getCourseListOfATerm((int?)null, (int?)null);
            
        }

        public int showRegistration(int sessionID, int year, int term, int stdID)
        {
            this.sessionID = sessionID;
            this.year = year;
            this.term = term;
            this.stdID = stdID;
            for (int i = 0; i < SessionComboBox.Items.Count; i++)
            {
                if (((Session)SessionComboBox.Items[i]).SessionID == sessionID)
                {
                    SessionComboBox.SelectedIndex = i;
                    break;
                }
            }
            YearComboBox.SelectedValue = year;
            TermComboBox.SelectedValue = term;
            LoadCoursesYearComboBox.SelectedValue = year;
            LoadCoursesTermComboBox.SelectedValue = term;
            Student s = Student.getStudent(stdID);
            RollTextBox.Text = s.DisplayableStudentID;
            CheckRegistrationLabel.Text = s.Name;

            registeredCourseList = RegisteredCoursesAgainstSingleStudent.getCourseList((int?)sessionID, (int?)year, (int?)term, (int?)stdID);
            TakenCoursesDataGridView.Rows.Clear();
            RetakeCoursesDataGridView.Rows.Clear();
            for (int i = 0; i < registeredCourseList.Count; i++)
            {
                if (registeredCourseList[i].Course.ID != null)
                {
                    TakenCoursesDataGridView.Rows.Add();
                    TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                    TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value = registeredCourseList[i].Course.ID;
                    TakenCoursesDataGridView["TakenCoursesDisplayableCourseNoColumn", i].Value = registeredCourseList[i].Course.DisplayableCourseNumber;
                    TakenCoursesDataGridView["TakenCoursesCourseTitleColumn", i].Value = registeredCourseList[i].Course.Title;
                    TakenCoursesDataGridView["TakenCoursesCreditHourColumn", i].Value = registeredCourseList[i].Course.Credit;
                    TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value = registeredCourseList[i].Marks.IsRetake;
                    TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                    if (registeredCourseList[i].Marks.IsRetake == true)
                    {
                        int j = RetakeCoursesDataGridView.RowCount;
                        RetakeCoursesDataGridView.Rows.Add();
                        RetakeCoursesDataGridView["RetakeCoursesCourseIDColumn", j].Value = registeredCourseList[i].Course.ID;
                        RetakeCoursesDataGridView["RetakeCoursesDisplayableCourseNoColumn", j].Value = registeredCourseList[i].Course.DisplayableCourseNumber;
                        RetakeCoursesDataGridView["RetakeCoursesCourseTitleColumn", j].Value = registeredCourseList[i].Course.Title;
                        RetakeCoursesDataGridView["RetakeCoursesCreditHourColumn", j].Value = registeredCourseList[i].Course.Credit;
                    }
                    creditsTaken += (decimal)registeredCourseList[i].Course.Credit;
                }
            }
            updateCredits();
            InsertButton.Text = "Update";
            InsertButton.Enabled = true;
            //CheckRegistrationLabel.Text = "";
            SessionComboBox.Enabled = false;
            YearComboBox.Enabled = false;
            TermComboBox.Enabled = false;
            RollTextBox.Enabled = false;
            this.Registered_Session_ID = registeredCourseList[0].Registered_Session_ID;
            return registeredCourseList.Count;
        }

        private void initControls()
        {
            YearComboBox.DataSource = Year.getYearList();
            YearComboBox.DisplayMember = "YearName";
            YearComboBox.ValueMember = "YearID";
            YearComboBox.SelectedIndex = 0;

            TermComboBox.DataSource = Term.getTermList();
            TermComboBox.DisplayMember = "TermName";
            TermComboBox.ValueMember = "TermID";
            TermComboBox.SelectedIndex = 0;

            SessionComboBox.DataSource = Session.getSessionList((int?)null,null);
            SessionComboBox.DisplayMember = "SessionName";
            SessionComboBox.ValueMember = "SessionID";
            SessionComboBox.SelectedIndex = 0;

            LoadCoursesYearComboBox.DataSource = Year.getYearListWithAllMapping();
            LoadCoursesYearComboBox.DisplayMember = "YearName";
            LoadCoursesYearComboBox.ValueMember = "YearID";
            LoadCoursesYearComboBox.SelectedIndex = 0;

            LoadCoursesTermComboBox.DataSource = Term.getTermListWithAllMapping();
            LoadCoursesTermComboBox.DisplayMember = "TermName";
            LoadCoursesTermComboBox.ValueMember = "TermID";
            LoadCoursesTermComboBox.SelectedIndex = 0;

            try
            {
                Settings s = new Settings("Settings.xml");

                this.SessionComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);
                this.YearComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                this.TermComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);

                this.LoadCoursesYearComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                this.LoadCoursesTermComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void LoadCoursesButton_Click(object sender, EventArgs e)
        {
            courseList = Course.getCourseListOfATerm((int?)LoadCoursesYearComboBox.SelectedValue, (int?)LoadCoursesTermComboBox.SelectedValue);
            CoreCoursesDataGridView.Rows.Clear();
            OptionalCoursesDataGridView.Rows.Clear();
            int CoreCoursesGridViewIterator = 0;
            int OptionalCoursesGridViewIterator = 0;
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].Is_Optional==false)
                {
                    CoreCoursesDataGridView.Rows.Add();
                    CoreCoursesDataGridView["CoreCoursesCourseIDColumn", CoreCoursesGridViewIterator].Value = courseList[i].ID;
                    CoreCoursesDataGridView["CoreCoursesDisplayableCourseNoColumn", CoreCoursesGridViewIterator].Value = courseList[i].DisplayableCourseNumber;
                    CoreCoursesDataGridView["CoreCoursesCourseTitleColumn", CoreCoursesGridViewIterator].Value = courseList[i].Title;
                    CoreCoursesDataGridView["CoreCoursesCreditHourColumn", CoreCoursesGridViewIterator].Value = courseList[i].Credit;
                    CoreCoursesGridViewIterator++;
                }
                else
                {
                    OptionalCoursesDataGridView.Rows.Add();
                    OptionalCoursesDataGridView["OptionalCoursesCourseIDColumn", OptionalCoursesGridViewIterator].Value = courseList[i].ID;
                    OptionalCoursesDataGridView["OptionalCoursesDisplayableCourseNoColumn", OptionalCoursesGridViewIterator].Value = courseList[i].DisplayableCourseNumber;
                    OptionalCoursesDataGridView["OptionalCoursesCourseTitleColumn", OptionalCoursesGridViewIterator].Value = courseList[i].Title;
                    OptionalCoursesDataGridView["OptionalCoursesCreditHourColumn", OptionalCoursesGridViewIterator].Value = courseList[i].Credit;
                    OptionalCoursesGridViewIterator++;
                }
            }
            //MessageBox.Show(courseList.Count+"");
        }

        private void CoreCoursesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            int courseID = (int)CoreCoursesDataGridView["CoreCoursesCourseIDColumn", e.RowIndex].Value;
            addCourseToTakenGridView(courseID);
        }

        private void TakenCoursesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            int courseID = (int)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", e.RowIndex].Value;
            if (TakenCoursesDataGridView.Columns[e.ColumnIndex].Name == "TakenCoursesDeleteColumn")
            {
                creditsTaken -= (decimal)TakenCoursesDataGridView["TakenCoursesCreditHourColumn", e.RowIndex].Value;
                updateCredits();
                //this.TakenCoursesDataGridView.Rows.RemoveAt(e.RowIndex);
                TakenCoursesDataGridView.Rows[e.RowIndex].Tag = UpdateType.Delete;
                TakenCoursesDataGridView.Rows[e.RowIndex].Visible = false;
                for (int i = 0; i < RetakeCoursesDataGridView.RowCount; i++)
                {
                    if ((int)RetakeCoursesDataGridView["RetakeCoursesCourseIDColumn", i].Value == courseID)
                    {
                        RetakeCoursesDataGridView.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (TakenCoursesDataGridView.Columns[e.ColumnIndex].Name == "TakenCoursesIsRetakeColumn")
            {
                if ((bool)TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", e.RowIndex].Value == false)
                {
                    TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", e.RowIndex].Value = true;
                    addCourseToRetakeGridView(courseID);
                }
                else
                {
                    TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", e.RowIndex].Value = false;
                    for (int i = 0; i < RetakeCoursesDataGridView.RowCount; i++)
                    {
                        if ((int)RetakeCoursesDataGridView["RetakeCoursesCourseIDColumn", i].Value == courseID)
                        {
                            RetakeCoursesDataGridView.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                if ((UpdateType)this.TakenCoursesDataGridView.Rows[e.RowIndex].Tag != UpdateType.Insert)
                    this.TakenCoursesDataGridView.Rows[e.RowIndex].Tag = UpdateType.Update;
            }
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < CoreCoursesDataGridView.RowCount; k++)
            {
                bool alreadyAdded = false;
                int courseID = (int)CoreCoursesDataGridView["CoreCoursesCourseIDColumn", k].Value;
                int i, j;
                for (i = 0; i < TakenCoursesDataGridView.RowCount; i++)
                {
                    if ((int)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value == courseID)
                    {
                        if (TakenCoursesDataGridView.Rows[i].Visible == false)
                        {
                            TakenCoursesDataGridView.Rows[i].Visible = true;
                            TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                            if ((bool)TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value == true)
                                addCourseToRetakeGridView(courseID);
                            creditsTaken += (decimal)TakenCoursesDataGridView["TakenCoursesCreditHourColumn", i].Value;
                            updateCredits();
                        }
                        alreadyAdded = true;
                        break;
                    }
                }
                if (alreadyAdded)
                    continue;
                for (j = 0; j < courseList.Count; j++)
                {
                    if (courseList[j].ID == courseID)
                        break;
                }
                if (courseList[j].Credit + creditsTaken > Depertment.MaxCredit)
                {
                    updateCredits();
                    MessageBox.Show("Adding More Course will exceed the credit limit of 25 Vredit Hour");
                    break;
                }
                else
                {
                    TakenCoursesDataGridView.Rows.Add();
                    TakenCoursesDataGridView.Rows[i].Tag = UpdateType.Insert;
                    TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value = courseList[j].ID;
                    TakenCoursesDataGridView["TakenCoursesDisplayableCourseNoColumn", i].Value = courseList[j].DisplayableCourseNumber;
                    TakenCoursesDataGridView["TakenCoursesCourseTitleColumn", i].Value = courseList[j].Title;
                    TakenCoursesDataGridView["TakenCoursesCreditHourColumn", i].Value = courseList[j].Credit;
                    TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value = false;
                    creditsTaken += (decimal)courseList[j].Credit;
                }
            }
            updateCredits();
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            TakenCoursesDataGridView.Rows.Clear();
            RetakeCoursesDataGridView.Rows.Clear();
            creditsTaken = 0;
            updateCredits();
        }

        private void updateCredits()
        {
            CreditTakenTextBox.Text = creditsTaken.ToString();
            CreditsAvailableTextBox.Text = (Depertment.MaxCredit - creditsTaken).ToString();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Registration?", "Delete Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Registered_Session_ID != null)
                {
                    if (RegisteredCoursesAgainstSingleStudent.Delete((int)Registered_Session_ID))
                    {
                        MessageBox.Show("Deleted Succesfully");
                        this.Parent.Dispose();
                    }
                    else
                        MessageBox.Show("Delete Error. Can not Delete.\r\nPlease Contact System Administrator.");
                }
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (RollTextBox.Text.Length != 6)
            {
                MessageBox.Show("Invalid Student ID");
                return;
            }
            if (InsertButton.Text == "Save")  //insert
            {
                RegisteredCoursesAgainstSingleStudent registeredCoursesAgainstSingleStudent = new RegisteredCoursesAgainstSingleStudent();
                registeredCoursesAgainstSingleStudent.Session.SessionID = (int)this.SessionComboBox.SelectedValue;
                registeredCoursesAgainstSingleStudent.Year.YearID = (int)this.YearComboBox.SelectedValue;
                registeredCoursesAgainstSingleStudent.Term.TermID = (int)this.TermComboBox.SelectedValue;
                registeredCoursesAgainstSingleStudent.Student = Student.getStudent(RollTextBox.Text);

                this.sessionID = registeredCoursesAgainstSingleStudent.Session.SessionID;
                this.year = registeredCoursesAgainstSingleStudent.Year.YearID;
                this.term = registeredCoursesAgainstSingleStudent.Term.TermID;
                this.stdID = registeredCoursesAgainstSingleStudent.Student.StudentId;

                List<Registration_and_Marks> courseList = new List<Registration_and_Marks>();
                for(int i=0;i<TakenCoursesDataGridView.RowCount;i++)
                {
                    if ((UpdateType)TakenCoursesDataGridView.Rows[i].Tag == UpdateType.Delete)
                    {
                        TakenCoursesDataGridView.Rows.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Registration_and_Marks registration_and_Marks = new Registration_and_Marks();
                        registration_and_Marks.Course.ID = (int)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value;
                        registration_and_Marks.Marks.IsRetake = (bool)TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value;
                        courseList.Add(registration_and_Marks);
                        TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                    }
                }
                registeredCoursesAgainstSingleStudent.CourseList = courseList;
                Registered_Session_ID = registeredCoursesAgainstSingleStudent.insert();
                MessageBox.Show("Inserted Successfully");
                InsertButton.Text = "Update";
                CheckRegistrationLabel.Text = registeredCoursesAgainstSingleStudent.Student.Name;
                SessionComboBox.Enabled = false;
                YearComboBox.Enabled = false;
                TermComboBox.Enabled = false;
                RollTextBox.Enabled = false;
                registeredCourseList = RegisteredCoursesAgainstSingleStudent.getCourseList((int?)sessionID, (int?)year, (int?)term, (int?)stdID);
            
            }
            else    //update
            {
                if (Registered_Session_ID != null)
                {
                    int updateFailureCounter = 0;
                    int deleteFailureCounter = 0;
                    int insertFailureCounter = 0;
                    for (int i = 0; i < TakenCoursesDataGridView.RowCount; i++)
                    {
                        if ((UpdateType)TakenCoursesDataGridView.Rows[i].Tag != UpdateType.None)
                        {
                            Registration_and_Marks reg_and_marks = null;
                            for (int j = 0; j < registeredCourseList.Count; j++)
                            {
                                if (registeredCourseList[j].Registered_Session_ID == Registered_Session_ID
                                    && registeredCourseList[j].Course.ID == (int?)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value)
                                {
                                    reg_and_marks = registeredCourseList[j];
                                }
                            }
                            //reg_and_marks.Registered_Session_ID = Registered_Session_ID;
                            //reg_and_marks.Course.ID = (int?)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value;
                            if (reg_and_marks == null)
                            {
                                reg_and_marks = new Registration_and_Marks();
                                reg_and_marks.Registered_Session_ID = Registered_Session_ID;
                                //reg_and_marks.Reg_Year = this.year;
                                //reg_and_marks.Reg_Term = this.term;
                                //reg_and_marks.Course = new Course();
                                reg_and_marks.Course.ID = (int)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value;
                            }
                            reg_and_marks.Marks.IsRetake = (bool?)TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value;
                                
                            if ((UpdateType)TakenCoursesDataGridView.Rows[i].Tag == UpdateType.Update)
                            {
                                if (Registration_and_Marks.Update(reg_and_marks))
                                    TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                                else
                                    updateFailureCounter++;
                            }
                            else if ((UpdateType)TakenCoursesDataGridView.Rows[i].Tag == UpdateType.Delete)
                            {
                                if (Registration_and_Marks.delete(reg_and_marks))
                                {
                                    TakenCoursesDataGridView.Rows.RemoveAt(i);
                                    i--;
                                }
                                else
                                    deleteFailureCounter++;
                            }
                            else if ((UpdateType)TakenCoursesDataGridView.Rows[i].Tag == UpdateType.Insert)
                            {
                                if (Registration_and_Marks.insert(reg_and_marks))
                                    TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                                else
                                    insertFailureCounter++;
                            }
                        }
                    }
                    if (updateFailureCounter == 0 && deleteFailureCounter == 0 && insertFailureCounter == 0)
                        MessageBox.Show("Updated Successfully");
                    else
                        MessageBox.Show((updateFailureCounter + deleteFailureCounter + insertFailureCounter) + " rows failed to update");
                }
            }
        }

        private void OptionalCoursesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            int courseID = (int)OptionalCoursesDataGridView["OptionalCoursesCourseIDColumn", e.RowIndex].Value;
            addCourseToTakenGridView(courseID);
        }
        
        private void addCourseToTakenGridView(int courseID)
        {
            int i, j;
            for (i = 0; i < TakenCoursesDataGridView.RowCount; i++)
            {
                if ((int)TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value == courseID)
                {
                    if (TakenCoursesDataGridView.Rows[i].Visible == false)
                    {
                        TakenCoursesDataGridView.Rows[i].Visible = true;
                        TakenCoursesDataGridView.Rows[i].Tag = UpdateType.None;
                        if ((bool)TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value == true)
                            addCourseToRetakeGridView(courseID);
                        creditsTaken += (decimal)TakenCoursesDataGridView["TakenCoursesCreditHourColumn", i].Value;
                        updateCredits();
                    }
                    else
                        MessageBox.Show("Already Added");
                    return;
                }
            }
            for (j = 0; j < courseList.Count; j++)
            {
                if (courseList[j].ID == courseID)
                    break;
            }
            if (courseList[j].Credit + creditsTaken > Depertment.MaxCredit)
            {
                MessageBox.Show("Adding More Course will exceed the credit limit of 25 Vredit Hour");
                return;
            }
            TakenCoursesDataGridView.Rows.Add();
            TakenCoursesDataGridView.Rows[i].Tag = UpdateType.Insert;
            TakenCoursesDataGridView["TakenCoursesCourseIDColumn", i].Value = courseList[j].ID;
            TakenCoursesDataGridView["TakenCoursesDisplayableCourseNoColumn", i].Value = courseList[j].DisplayableCourseNumber;
            TakenCoursesDataGridView["TakenCoursesCourseTitleColumn", i].Value = courseList[j].Title;
            TakenCoursesDataGridView["TakenCoursesCreditHourColumn", i].Value = courseList[j].Credit;
            TakenCoursesDataGridView["TakenCoursesIsRetakeColumn", i].Value = false;
            creditsTaken += (decimal)courseList[j].Credit;
            updateCredits();
        }
        
        private void addCourseToRetakeGridView(int courseID)
        {
            int j;
            for (j = 0; j < courseList.Count; j++)
            {
                if (courseList[j].ID == courseID)
                    break;
            }
            RetakeCoursesDataGridView.Rows.Add();
            int i = RetakeCoursesDataGridView.RowCount - 1;
            RetakeCoursesDataGridView["RetakeCoursesCourseIDColumn", i].Value = courseList[j].ID;
            RetakeCoursesDataGridView["RetakeCoursesDisplayableCourseNoColumn", i].Value = courseList[j].DisplayableCourseNumber;
            RetakeCoursesDataGridView["RetakeCoursesCourseTitleColumn", i].Value = courseList[j].Title;
            RetakeCoursesDataGridView["RetakeCoursesCreditHourColumn", i].Value = courseList[j].Credit;
        }

        private void checkAndLoadRegistration()
        {
            if (RollTextBox.Text.Length == 6)
            {
                Student student = Student.getStudent(RollTextBox.Text);
                if (student == null)
                {
                    CheckRegistrationLabel.ForeColor = Color.Red;
                    CheckRegistrationLabel.Text = "Student doesn't exist";
                    ReloadButton.PerformClick();
                    InsertButton.Text = "Save";
                    InsertButton.Enabled = false;
                    return;
                }
                int sessionID = (int)SessionComboBox.SelectedValue;
                int year = (int)YearComboBox.SelectedValue;
                int term = (int)TermComboBox.SelectedValue;
                int stdID = (int)student.StudentId;
                if (RegisteredCoursesAgainstSingleStudent.isStudentRegistered(sessionID, year, term, stdID) != null)
                {
                    CheckRegistrationLabel.ForeColor = Color.Red;
                    CheckRegistrationLabel.Text = "Student " + RollTextBox.Text + " is already Registered for\r\nSession:"
                        + SessionComboBox.Text + " Year: " + YearComboBox.Text + " Term: " + TermComboBox.Text;
                    //InsertButton.Text = "Update";
                    InsertButton.Enabled = false;
                }
                else
                {
                    CheckRegistrationLabel.ForeColor = Color.Green;
                    CheckRegistrationLabel.Text = "Student " + RollTextBox.Text + " is not registered Yet.\r\nYou may proceed the registration process.";
                    InsertButton.Text = "Save";
                    InsertButton.Enabled = true;
                }
            }
            else
            {
                CheckRegistrationLabel.ForeColor = Color.Black;
                CheckRegistrationLabel.Text = "Invalid Student ID";
                ReloadButton.PerformClick();
                InsertButton.Enabled = false;
            }
        }

        private void RollTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            checkAndLoadRegistration();
        }

        private void SessionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkAndLoadRegistration();
        }

        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkAndLoadRegistration();
        }

        private void TermComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkAndLoadRegistration();
        }

        private void TakenCoursesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            if ((UpdateType)this.TakenCoursesDataGridView.Rows[e.RowIndex].Tag != UpdateType.Insert)
                this.TakenCoursesDataGridView.Rows[e.RowIndex].Tag = UpdateType.Update;
        }
    }
}
