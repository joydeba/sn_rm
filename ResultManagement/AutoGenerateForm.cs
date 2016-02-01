using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ResultManagement.DAObjects;

namespace ResultManagement
{
    public partial class AutoGenerateForm : Form
    {
        List<Student> studentList;

        public List<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public AutoGenerateForm()
        {
            InitializeComponent();
            label6.Text = Depertment.DepartmentCode;
            label7.Text = Depertment.DepartmentCode;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (batchTextBox.Text.Length != 2)
            {
                MessageBox.Show("Invalid Batch.");
                return;
            }
            else if (startRollTextBox.Text.Length != 2)
            {
                MessageBox.Show("Invalid Start Roll.");
                return;
            }
            else if (endRollTextBox.Text.Length != 2)
            {
                MessageBox.Show("Invalid End Roll.");
                return;
            }
            int startRoll = int.Parse(startRollTextBox.Text);
            int endRoll = int.Parse(endRollTextBox.Text);
            if ( endRoll<startRoll )
            {
                MessageBox.Show("End Roll Must be Greater than Start Roll");
                return;
            }
            int numOfStudents = endRoll - startRoll + 1;
            studentList = new List<Student>(numOfStudents);
            for (int i = 0; i < numOfStudents; i++)
            {
                studentList.Add(new Student());
                studentList[i].Batch = batchTextBox.Text;
                studentList[i].Roll = startRoll++.ToString("D2");
            }
            StudentSearchCriteria sc = new StudentSearchCriteria();
            sc.Batch = batchTextBox.Text;
            List<Student> existingStudentList = new List<Student>();
            existingStudentList = Student.GetStudentList(sc);
            for (int i = 0; i < numOfStudents; i++)
            {
                for (int j = 0; j < existingStudentList.Count; j++)
                {
                    if (studentList[i].Roll == existingStudentList[j].Roll)
                    {
                        studentList[i].StudentId = existingStudentList[j].StudentId;
                        studentList[i].Name = existingStudentList[j].Name;
                        break;
                    }
                }
            }
            for (int i = 0; i < numOfStudents; i++)
            { 
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            startingLabel.Text = batchTextBox.Text + Depertment.DepartmentCode + startRollTextBox.Text;
            endingLabel.Text = batchTextBox.Text + Depertment.DepartmentCode + endRollTextBox.Text;
            BatchTextBox2.Text = batchTextBox.Text;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}