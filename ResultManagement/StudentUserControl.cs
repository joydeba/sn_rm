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
    public partial class StudentUserControl : UserControl
    {
        private Size clbMaxSize = new Size(200, 95);
        private Size clbMinSize = new Size(117, 19);

        public StudentUserControl()
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in this.dataGridView1.Columns)
            {
                if (!(col.Name == "IdColumn" || col.Name == "StudentIDColumn"))
                {
                    int i = this.checkedListBox1.Items.Add(col.HeaderText);

                    if (col.Name == "BatchColumn" || col.Name == "DeptColumn" || col.Name == "RollColumn")
                    {
                        col.Visible = false;
                        this.checkedListBox1.SetItemChecked(i, false);
                    }
                    else
                    {
                        col.Visible = true;
                        this.checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                StudentSearchCriteria sc = makeSearchCriteria();
                if (sc == null)
                    return;
                List<Student> sList = Student.GetStudentList(sc);
                showStudents(sList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private StudentSearchCriteria makeSearchCriteria()
        {
            StudentSearchCriteria sc = new StudentSearchCriteria();


            if (Student.parseStudentID(RollTextBox.Text.Trim(), sc) == false)
            {
                MessageBox.Show("Invalid Student ID");
                return null;
            }
            //sc.RollLike = this.rollTextBox.Text.Trim();
            sc.Name = this.NameTextBox.Text.Trim();

            if (sc.Batch != null)
            {
                if (this.BatchTextBox.Text.Trim() != "" && !this.BatchTextBox.Text.Trim().Equals(sc.Batch))
                {
                    MessageBox.Show("Student ID and Batch do not match.");
                    return null;
                }
            }
            else
                sc.Batch = this.BatchTextBox.Text.Trim();
            //////////////////////////////////////////////

            return sc;
        }

        private void showStudents(List<Student> sList)
        {
            this.dataGridView1.Rows.Clear();

            //int totalPaid = 0;
            //int totalDue = 0;

            foreach (Student s in sList)
            {
                int i = this.dataGridView1.Rows.Add();

                this.dataGridView1.Rows[i].Cells["IdColumn"].Value = s.StudentId;
                this.dataGridView1.Rows[i].Cells["RollColumn"].Value = s.Roll;
                this.dataGridView1.Rows[i].Cells["NameColumn"].Value = s.Name;
                //////////////////////////////////////////////////////

                this.dataGridView1.Rows[i].Cells["DeptColumn"].Value = Depertment.DepartmentCode;
                this.dataGridView1.Rows[i].Cells["BatchColumn"].Value = s.Batch;
                this.dataGridView1.Rows[i].Cells["StudentIDColumn"].Value = s.Batch + Depertment.DepartmentCode + s.Roll;
                this.dataGridView1.Rows[i].Cells["SelectColumn"].Value = false;
                ///////////////////////////////////////////////////////
            }

            this.NumberOfStudentsTextBox.Text = sList.Count.ToString();
            //this.totalDueTextBox.Text = totalDue.ToString();

        }

        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.checkedListBox1.Size = this.clbMaxSize;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (DataGridViewColumn col in this.dataGridView1.Columns)
            {
                if (col.HeaderText == (string)this.checkedListBox1.Items[e.Index])
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
            }      
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.checkedListBox1.Size = this.clbMinSize;
        }

        private void splitContainer1_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.checkedListBox1.Size = this.clbMinSize;
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            NewStudentForm newStudentForm = new NewStudentForm();
            newStudentForm.Show();
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount;i++ )
                dataGridView1["SelectColumn", i].Value = SelectAllCheckBox.Checked;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete the selected Students??\r\nDeleting a student will delete all his conrresponding Exams and marks\r\nOnce Deleted, you wont be able to retrive the information of that Student", 
                                "Delete Student",
                                MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                int deleteCounter = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if ((bool)dataGridView1["SelectColumn", i].Value == true)
                    {
                        if (Student.Delete((int)dataGridView1["IdColumn", i].Value))
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            i--;
                            deleteCounter++;
                        }
                    }
                }
                MessageBox.Show(deleteCounter + " Students Deleted Successfully");
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            NameTextBox.Text = "";
            BatchTextBox.Text = "";
            RollTextBox.Text = "";
        }

    }
}
