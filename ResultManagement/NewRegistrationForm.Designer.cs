namespace ResultManagement
{
    partial class NewRegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewStudentForm));
            this.registrationFormControl1 = new ResultManagement.RegistrationFormControl();
            this.SuspendLayout();
            // 
            // registrationFormControl1
            // 
            this.registrationFormControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationFormControl1.Location = new System.Drawing.Point(0, 0);
            this.registrationFormControl1.Name = "registrationFormControl1";
            this.registrationFormControl1.Size = new System.Drawing.Size(890, 668);
            this.registrationFormControl1.TabIndex = 0;
            // 
            // NewRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ClientSize = new System.Drawing.Size(890, 668);
            this.Controls.Add(this.registrationFormControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NewRegistrationForm";
            this.Text = "New Registration";
            this.ResumeLayout(false);

        }

        #endregion

        public RegistrationFormControl registrationFormControl1;

    }
}