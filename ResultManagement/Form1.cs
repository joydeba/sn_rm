using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ResultManagement.UserManagement;

namespace ResultManagement
{
    public partial class Form1 : Form
    {

        private HomeUserControl homeControl;
        private StudentUserControl studentControl;
        private RegistrationControl registrationControl;
        private MarksEntryControl marksEntryControl;
        private ResultUserControl resultUserControl;
        private CourseUserControl courseUserControl;

        public Form1()
        {
            InitializeComponent();
            homeControl = new HomeUserControl();
            studentControl = new StudentUserControl();
            registrationControl = new RegistrationControl();
            marksEntryControl = new MarksEntryControl();
            resultUserControl = new ResultUserControl();
            courseUserControl = new CourseUserControl();

            this.panel1.Controls.Add(homeControl);
            homeControl.Dock = DockStyle.Fill;

            //initilizeControls();
            //homeControl.BringToFront();
            //setLogin(true);
        }

        private void HomeTSButton_Click(object sender, EventArgs e)
        {
            homeControl.BringToFront();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loginToolStripMenuItem.Text == "Login")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

                if (User.IsLoggedIn)
                {
                    initilizeControls();
                    this.loginToolStripMenuItem.Text = "Logout";
                    setLogin(true);
                }
            }
            else
            {
                User.Logout();
                disposeControls();
                this.loginToolStripMenuItem.Text = "Login";
                setLogin(false);
            }
        }

        private void setLogin(Boolean b)
        {
            this.changePasswordToolStripMenuItem.Visible = b;
            this.settingsToolStripMenuItem.Visible = b;
        }

        private void initilizeControls()
        {
            this.panel1.Controls.Add(studentControl);
            studentControl.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(courseUserControl);
            courseUserControl.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(registrationControl);
            registrationControl.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(marksEntryControl);
            marksEntryControl.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(resultUserControl);
            resultUserControl.Dock = DockStyle.Fill;

            homeControl.BringToFront();
        }
        private void disposeControls()
        {
            //homeControl.Dispose();
            /*studentControl.Dispose();
            courseUserControl.Dispose();
            registrationControl.Dispose();
            marksEntryControl.Dispose();
            resultUserControl.Dispose();*/
            this.panel1.Controls.Remove(studentControl);

            this.panel1.Controls.Remove(courseUserControl);

            this.panel1.Controls.Remove(registrationControl);

            this.panel1.Controls.Remove(marksEntryControl);

            this.panel1.Controls.Remove(resultUserControl);
        }

        private void StudentTSButton_Click(object sender, EventArgs e)
        {
            studentControl.BringToFront();
        }

        private void RegistrationTSButton_Click(object sender, EventArgs e)
        {
            registrationControl.BringToFront();
        }

        private void MarksTSButton_Click(object sender, EventArgs e)
        {
            marksEntryControl.BringToFront();
        }

        private void ResultTSButton_Click(object sender, EventArgs e)
        {
            resultUserControl.BringToFront();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            courseUserControl.BringToFront();
        }

        private void defaultValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultValuesForm defaultValuesForm = new DefaultValuesForm();
            defaultValuesForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            developerAboutBox developerAboutBox = new developerAboutBox();
            developerAboutBox.ShowDialog();
        }
    }
}