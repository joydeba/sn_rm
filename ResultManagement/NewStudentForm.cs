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
    public partial class NewStudentForm : Form
    {
        List<Student> studentList;
        public NewStudentForm()
        {
            InitializeComponent();
            dataGridView1.Rows[0].Tag = UpdateType.Insert;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            Student s;
            int rows = dataGridView1.Rows.Count - 1;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Insert)
                {
                    s = new Student();
                    if (makeStudent(dataGridView1.Rows[i], s) == true)
                    {
                        if (s.Insert() == true)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if ((UpdateType)dataGridView1.Rows[i].Tag == UpdateType.Update)
                {
                    int ID = (int)dataGridView1["IDColumn", i].Value;
                    int j;
                    for (j = 0; j < studentList.Count; j++)
                    {
                        if (studentList[j].StudentId == ID)
                            break;
                    }
                    string studentdID = (string)dataGridView1["StudentIDColumn", i].Value;
                    bool update = false;
                    if (studentdID.Length == Depertment.StudentIDLength && studentdID.Substring(0, 2) == studentList[j].Batch && studentdID.Substring(2, 2) == Depertment.DepartmentCode)
                    {
                        studentList[j].Roll = studentdID.Substring(4, 2);
                        studentList[j].Name = (string)dataGridView1["NameColumn", i].Value + " ";
                        update = studentList[j].Update();
                    }
                    if (update)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                }
            }
            if (rows > 0)
            {
                if (this.dataGridView1.Rows.Count - 1 > 0)
                {
                    MessageBox.Show("Invalid or Duplicate input in " + (this.dataGridView1.Rows.Count - 1) + " rows!\n\n" + (rows - this.dataGridView1.Rows.Count + 1) + " rows Saved successfully.");
                }
                else
                {
                    MessageBox.Show("Saved successfully.");
                }
            }
        }
        private Boolean makeStudent(DataGridViewRow row, Student s)
        {
            try
            {
                s.Name = row.Cells["NameColumn"].Value.ToString() + " ";
            }
            catch { }
            try
            {
                return Student.parseStudentID(row.Cells["StudentIDColumn"].Value.ToString(), s);
            }
            catch
            {
                return false;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = UpdateType.Insert;
            TotalLabel.Text = "Total: " + (dataGridView1.Rows.Count - 1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TotalLabel.Text = "Total: " + (dataGridView1.Rows.Count - 1);
        }

        private void AutoGenerateButton_Click(object sender, EventArgs e)
        {
            AutoGenerateForm autoGenerateForm = new AutoGenerateForm();
            if (autoGenerateForm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                studentList = autoGenerateForm.StudentList;
                for (int i = 0; i < studentList.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Tag = UpdateType.None;
                    dataGridView1["IDColumn", i].Value = studentList[i].StudentId;
                    dataGridView1["StudentIDColumn", i].Value = studentList[i].DisplayableStudentID;
                    dataGridView1["NameColumn", i].Value = studentList[i].Name;
                    if (studentList[i].StudentId == null)
                        dataGridView1.Rows[i].Tag = UpdateType.Insert;
                    else
                        dataGridView1.Rows[i].Tag = UpdateType.None;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if ((UpdateType)dataGridView1.Rows[e.RowIndex].Tag != UpdateType.Insert)
                dataGridView1.Rows[e.RowIndex].Tag = UpdateType.Update;
        }
    }
}