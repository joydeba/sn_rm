namespace ResultManagement
{
    partial class CourseUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.YearToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.TermToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewCourseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.LoadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CourseIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursePrefixColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditHourColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsOptionalColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.NumberOfCoursesTextBox = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(48, 24);
            this.toolStripLabel3.Text = "Year      ";
            // 
            // YearToolStripComboBox
            // 
            this.YearToolStripComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4"});
            this.YearToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.YearToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearToolStripComboBox.Name = "YearToolStripComboBox";
            this.YearToolStripComboBox.Size = new System.Drawing.Size(75, 27);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(53, 24);
            this.toolStripLabel4.Text = "Term      ";
            // 
            // TermToolStripComboBox
            // 
            this.TermToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TermToolStripComboBox.Name = "TermToolStripComboBox";
            this.TermToolStripComboBox.Size = new System.Drawing.Size(75, 27);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(190)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCourseToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.YearToolStripComboBox,
            this.toolStripSeparator5,
            this.toolStripLabel4,
            this.TermToolStripComboBox,
            this.toolStripSeparator6,
            this.LoadToolStripButton,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NewCourseToolStripButton
            // 
            this.NewCourseToolStripButton.Image = global::ResultManagement.Properties.Resources.plus_32;
            this.NewCourseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewCourseToolStripButton.Name = "NewCourseToolStripButton";
            this.NewCourseToolStripButton.Size = new System.Drawing.Size(113, 24);
            this.NewCourseToolStripButton.Text = "New Course      ";
            // 
            // LoadToolStripButton
            // 
            this.LoadToolStripButton.Image = global::ResultManagement.Properties.Resources.forum_search;
            this.LoadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadToolStripButton.Name = "LoadToolStripButton";
            this.LoadToolStripButton.Size = new System.Drawing.Size(75, 24);
            this.LoadToolStripButton.Text = "Load      ";
            this.LoadToolStripButton.Click += new System.EventHandler(this.LoadToolStripButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseIDColumn,
            this.CoursePrefixColumn,
            this.CourseNumberColumn,
            this.CourseTitleColumn,
            this.CreditHourColumn,
            this.IsOptionalColumn,
            this.DeleteColumn});
            this.dataGridView1.Location = new System.Drawing.Point(27, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(764, 258);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // CourseIDColumn
            // 
            this.CourseIDColumn.HeaderText = "Course ID";
            this.CourseIDColumn.Name = "CourseIDColumn";
            this.CourseIDColumn.Visible = false;
            // 
            // CoursePrefixColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CoursePrefixColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CoursePrefixColumn.HeaderText = "Course Prefix";
            this.CoursePrefixColumn.Name = "CoursePrefixColumn";
            // 
            // CourseNumberColumn
            // 
            this.CourseNumberColumn.HeaderText = "Course Number";
            this.CourseNumberColumn.MaxInputLength = 4;
            this.CourseNumberColumn.Name = "CourseNumberColumn";
            this.CourseNumberColumn.Width = 120;
            // 
            // CourseTitleColumn
            // 
            this.CourseTitleColumn.HeaderText = "Course Title";
            this.CourseTitleColumn.Name = "CourseTitleColumn";
            this.CourseTitleColumn.Width = 350;
            // 
            // CreditHourColumn
            // 
            dataGridViewCellStyle2.NullValue = "0.00";
            this.CreditHourColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreditHourColumn.HeaderText = "Credit Hour";
            this.CreditHourColumn.Name = "CreditHourColumn";
            // 
            // IsOptionalColumn
            // 
            this.IsOptionalColumn.HeaderText = "Optional";
            this.IsOptionalColumn.Name = "IsOptionalColumn";
            this.IsOptionalColumn.Width = 50;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Text = "X";
            this.DeleteColumn.UseColumnTextForButtonValue = true;
            this.DeleteColumn.Width = 40;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Total Number of Courses";
            // 
            // NumberOfCoursesTextBox
            // 
            this.NumberOfCoursesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NumberOfCoursesTextBox.Location = new System.Drawing.Point(181, 341);
            this.NumberOfCoursesTextBox.Name = "NumberOfCoursesTextBox";
            this.NumberOfCoursesTextBox.Size = new System.Drawing.Size(103, 20);
            this.NumberOfCoursesTextBox.TabIndex = 69;
            this.NumberOfCoursesTextBox.Text = "0";
            // 
            // InsertButton
            // 
            this.InsertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertButton.Image = global::ResultManagement.Properties.Resources.save_16;
            this.InsertButton.Location = new System.Drawing.Point(716, 339);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 73;
            this.InsertButton.Text = "Update";
            this.InsertButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // CourseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfCoursesTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CourseUserControl";
            this.Size = new System.Drawing.Size(821, 380);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton NewCourseToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox YearToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox TermToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton LoadToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NumberOfCoursesTextBox;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursePrefixColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditHourColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOptionalColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;

    }
}
