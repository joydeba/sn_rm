namespace ResultManagement
{
    partial class RegistrationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.studentWiseRegistrtionControl1 = new ResultManagement.StudentWiseRegistrtionControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 484);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.studentWiseRegistrtionControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Studentwise Registration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coursewise Registration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // studentWiseRegistrtionControl1
            // 
            this.studentWiseRegistrtionControl1.BackColor = System.Drawing.SystemColors.Control;
            this.studentWiseRegistrtionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentWiseRegistrtionControl1.Location = new System.Drawing.Point(3, 3);
            this.studentWiseRegistrtionControl1.Name = "studentWiseRegistrtionControl1";
            this.studentWiseRegistrtionControl1.Size = new System.Drawing.Size(887, 452);
            this.studentWiseRegistrtionControl1.TabIndex = 0;
            // 
            // RegistrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "RegistrationControl";
            this.Size = new System.Drawing.Size(901, 484);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private StudentWiseRegistrtionControl studentWiseRegistrtionControl1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
