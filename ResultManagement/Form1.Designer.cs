namespace ResultManagement
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplineNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.HomeTSButton = new System.Windows.Forms.ToolStripButton();
            this.StudentTSButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.RegistrationTSButton = new System.Windows.Forms.ToolStripButton();
            this.MarksTSButton = new System.Windows.Forms.ToolStripButton();
            this.ResultTSButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.userToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculatorToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Visible = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schoolNameToolStripMenuItem,
            this.disciplineNameToolStripMenuItem,
            this.disciplinePictureToolStripMenuItem,
            this.defaultValuesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Visible = false;
            // 
            // schoolNameToolStripMenuItem
            // 
            this.schoolNameToolStripMenuItem.Name = "schoolNameToolStripMenuItem";
            this.schoolNameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.schoolNameToolStripMenuItem.Text = "School Name";
            // 
            // disciplineNameToolStripMenuItem
            // 
            this.disciplineNameToolStripMenuItem.Name = "disciplineNameToolStripMenuItem";
            this.disciplineNameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.disciplineNameToolStripMenuItem.Text = "Discipline Name";
            // 
            // disciplinePictureToolStripMenuItem
            // 
            this.disciplinePictureToolStripMenuItem.Name = "disciplinePictureToolStripMenuItem";
            this.disciplinePictureToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.disciplinePictureToolStripMenuItem.Text = "Discipline Picture";
            // 
            // defaultValuesToolStripMenuItem
            // 
            this.defaultValuesToolStripMenuItem.Name = "defaultValuesToolStripMenuItem";
            this.defaultValuesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.defaultValuesToolStripMenuItem.Text = "Default Values";
            this.defaultValuesToolStripMenuItem.Click += new System.EventHandler(this.defaultValuesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeTSButton,
            this.StudentTSButton,
            this.toolStripButton1,
            this.RegistrationTSButton,
            this.MarksTSButton,
            this.ResultTSButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // HomeTSButton
            // 
            this.HomeTSButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeTSButton.Image = global::ResultManagement.Properties.Resources.home;
            this.HomeTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HomeTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HomeTSButton.Name = "HomeTSButton";
            this.HomeTSButton.Size = new System.Drawing.Size(97, 36);
            this.HomeTSButton.Text = " Home      ";
            this.HomeTSButton.Click += new System.EventHandler(this.HomeTSButton_Click);
            // 
            // StudentTSButton
            // 
            this.StudentTSButton.Image = global::ResultManagement.Properties.Resources.people_32x32;
            this.StudentTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StudentTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StudentTSButton.Name = "StudentTSButton";
            this.StudentTSButton.Size = new System.Drawing.Size(102, 36);
            this.StudentTSButton.Text = "Student      ";
            this.StudentTSButton.Click += new System.EventHandler(this.StudentTSButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ResultManagement.Properties.Resources.Course;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(98, 36);
            this.toolStripButton1.Text = "Course      ";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // RegistrationTSButton
            // 
            this.RegistrationTSButton.Image = ((System.Drawing.Image)(resources.GetObject("RegistrationTSButton.Image")));
            this.RegistrationTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RegistrationTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RegistrationTSButton.Name = "RegistrationTSButton";
            this.RegistrationTSButton.Size = new System.Drawing.Size(124, 36);
            this.RegistrationTSButton.Text = "Registration      ";
            this.RegistrationTSButton.Click += new System.EventHandler(this.RegistrationTSButton_Click);
            // 
            // MarksTSButton
            // 
            this.MarksTSButton.Image = global::ResultManagement.Properties.Resources.notes_edit_32x32;
            this.MarksTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MarksTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MarksTSButton.Name = "MarksTSButton";
            this.MarksTSButton.Size = new System.Drawing.Size(93, 36);
            this.MarksTSButton.Text = "Marks      ";
            this.MarksTSButton.Click += new System.EventHandler(this.MarksTSButton_Click);
            // 
            // ResultTSButton
            // 
            this.ResultTSButton.Image = global::ResultManagement.Properties.Resources.ist2_6216050_business_icon_;
            this.ResultTSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ResultTSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResultTSButton.Name = "ResultTSButton";
            this.ResultTSButton.Size = new System.Drawing.Size(93, 36);
            this.ResultTSButton.Text = "Result      ";
            this.ResultTSButton.Click += new System.EventHandler(this.ResultTSButton_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 499);
            this.panel1.TabIndex = 2;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabulation System of KU";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton HomeTSButton;
        private System.Windows.Forms.ToolStripButton StudentTSButton;
        private System.Windows.Forms.ToolStripButton RegistrationTSButton;
        private System.Windows.Forms.ToolStripButton MarksTSButton;
        private System.Windows.Forms.ToolStripButton ResultTSButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplineNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoolNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinePictureToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem defaultValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

