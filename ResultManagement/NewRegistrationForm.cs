using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResultManagement
{
    public partial class NewRegistrationForm : Form
    {
        public NewRegistrationForm()
        {
            InitializeComponent();
        }
        public NewRegistrationForm(int sessionID, int year, int term, int stdID)
        {
            InitializeComponent();
            this.registrationFormControl1.showRegistration(sessionID, year, term, stdID);
        }
    }
}