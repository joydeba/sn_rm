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
    public partial class DefaultValuesForm : Form
    {
        private List<Session> sessionList = new List<Session>();
        private List<Year> yearList = new List<Year>();
        private List<Term> termList = new List<Term>();


        public DefaultValuesForm()
        {
            InitializeComponent();

            initControls();
        }

        private void initControls()
        {
            ///////////////////////////////////////
            try
            {
                this.sessionList = Session.getSessionList((int?)null, (string)null);
                this.yearList = Year.getYearList();
                this.termList = Term.getTermList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.sessionComboBox.DataSource = this.sessionList;
            this.sessionComboBox.DisplayMember = "sessionName";
            this.sessionComboBox.ValueMember = "sessionID";

            this.yearComboBox.DataSource = this.yearList;
            this.yearComboBox.DisplayMember = "yearName";
            this.yearComboBox.ValueMember = "yearID";

            this.termComboBox.DataSource = this.termList;
            this.termComboBox.DisplayMember = "termName";
            this.termComboBox.ValueMember = "termID";
            /////////////////////////////////////////////////////

            try
            {
                Settings s = new Settings("Settings.xml");

                this.sessionComboBox.SelectedValue = (int)s.GetValue("DefaultSessionID", SettingType.Int32);
                this.yearComboBox.SelectedValue = (int)s.GetValue("DefaultYearID", SettingType.Int32);
                this.termComboBox.SelectedValue = (int)s.GetValue("DefaultTermID", SettingType.Int32);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Settings s = new Settings("Settings.xml");

                s.SetValue("DefaultSessionID", SettingType.Int32, this.sessionComboBox.SelectedValue);
                s.SetValue("DefaultYearID", SettingType.Int32, this.yearComboBox.SelectedValue);
                s.SetValue("DefaultTermID", SettingType.Int32, this.termComboBox.SelectedValue);

                s.Save();
                MessageBox.Show("Saved successfully");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}