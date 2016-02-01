using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using ResultManagement.UserManagement;

namespace ResultManagement.UserManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (this.userNameTextBox.Text == "" || this.passTextBox.Text == "")
            {
                MessageBox.Show("Invalid input. Please complete all the fields above.");
                return;
            }

            User.Login(this.userNameTextBox.Text.Trim(), this.passTextBox.Text.Trim());

            if (!User.IsLoggedIn)
            {
                this.userNameTextBox.Text = "";
                this.passTextBox.Text = "";
            }
            else
            {
                this.Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}