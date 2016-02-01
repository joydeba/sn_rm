namespace ResultManagement
{
    partial class MarksEntryControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SessionToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CourseNoToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ReloadCourseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MarksIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendenceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_or_VivaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SA_or_secAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecBColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetakeColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.AutoAttendenceButton = new System.Windows.Forms.Button();
            this.ClearColumnButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SessionLabel = new System.Windows.Forms.Label();
            this.CourseNoLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(190)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.SessionToolStripComboBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.CourseNoToolStripComboBox,
            this.toolStripSeparator3,
            this.SearchToolStripButton,
            this.toolStripSeparator2,
            this.ReloadCourseToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 24);
            this.toolStripLabel1.Text = "      Session :  ";
            // 
            // SessionToolStripComboBox
            // 
            this.SessionToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SessionToolStripComboBox.Name = "SessionToolStripComboBox";
            this.SessionToolStripComboBox.Size = new System.Drawing.Size(100, 27);
            this.SessionToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.SessionToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(93, 24);
            this.toolStripLabel2.Text = "      Course No :  ";
            // 
            // CourseNoToolStripComboBox
            // 
            this.CourseNoToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CourseNoToolStripComboBox.Name = "CourseNoToolStripComboBox";
            this.CourseNoToolStripComboBox.Size = new System.Drawing.Size(400, 27);
            this.CourseNoToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseNoToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // SearchToolStripButton
            // 
            this.SearchToolStripButton.Image = global::ResultManagement.Properties.Resources.forum_search;
            this.SearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchToolStripButton.Name = "SearchToolStripButton";
            this.SearchToolStripButton.Size = new System.Drawing.Size(78, 24);
            this.SearchToolStripButton.Text = "Search    ";
            this.SearchToolStripButton.Click += new System.EventHandler(this.SearchToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ReloadCourseToolStripButton
            // 
            this.ReloadCourseToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ReloadCourseToolStripButton.Image = global::ResultManagement.Properties.Resources.Refresh_16x16;
            this.ReloadCourseToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReloadCourseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadCourseToolStripButton.Name = "ReloadCourseToolStripButton";
            this.ReloadCourseToolStripButton.Size = new System.Drawing.Size(108, 24);
            this.ReloadCourseToolStripButton.Text = "Reload Courses";
            this.ReloadCourseToolStripButton.Click += new System.EventHandler(this.ReloadCourseToolStripButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarksIDColumn,
            this.StdIDColumn,
            this.AttendenceColumn,
            this.CT_or_VivaColumn,
            this.SA_or_secAColumn,
            this.SecBColumn,
            this.TotalColumn,
            this.GPColumn,
            this.GradeColumn,
            this.RetakeColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(882, 308);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // MarksIDColumn
            // 
            this.MarksIDColumn.HeaderText = "MarksID";
            this.MarksIDColumn.Name = "MarksIDColumn";
            this.MarksIDColumn.Visible = false;
            // 
            // StdIDColumn
            // 
            this.StdIDColumn.HeaderText = "Student ID";
            this.StdIDColumn.Name = "StdIDColumn";
            this.StdIDColumn.ReadOnly = true;
            // 
            // AttendenceColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AttendenceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.AttendenceColumn.HeaderText = "Attendence (10)";
            this.AttendenceColumn.Name = "AttendenceColumn";
            // 
            // CT_or_VivaColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.CT_or_VivaColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.CT_or_VivaColumn.HeaderText = "CT or Viva (30)";
            this.CT_or_VivaColumn.Name = "CT_or_VivaColumn";
            // 
            // SA_or_secAColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.SA_or_secAColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.SA_or_secAColumn.HeaderText = "SA or Section A (30)";
            this.SA_or_secAColumn.Name = "SA_or_secAColumn";
            // 
            // SecBColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.SecBColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.SecBColumn.HeaderText = "Section B (30)";
            this.SecBColumn.Name = "SecBColumn";
            // 
            // TotalColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalColumn.HeaderText = "Total (100)";
            this.TotalColumn.Name = "TotalColumn";
            this.TotalColumn.ReadOnly = true;
            // 
            // GPColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GPColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.GPColumn.HeaderText = "GP";
            this.GPColumn.Name = "GPColumn";
            this.GPColumn.ReadOnly = true;
            // 
            // GradeColumn
            // 
            this.GradeColumn.HeaderText = "Grade";
            this.GradeColumn.Name = "GradeColumn";
            this.GradeColumn.ReadOnly = true;
            // 
            // RetakeColumn
            // 
            this.RetakeColumn.HeaderText = "Retake";
            this.RetakeColumn.Name = "RetakeColumn";
            this.RetakeColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExitButton);
            this.groupBox1.Controls.Add(this.PrintButton);
            this.groupBox1.Controls.Add(this.AutoAttendenceButton);
            this.groupBox1.Controls.Add(this.ClearColumnButton);
            this.groupBox1.Controls.Add(this.ReloadButton);
            this.groupBox1.Controls.Add(this.UpdateButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(800, 19);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Location = new System.Drawing.Point(655, 19);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(100, 23);
            this.PrintButton.TabIndex = 4;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // AutoAttendenceButton
            // 
            this.AutoAttendenceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.AutoAttendenceButton.Location = new System.Drawing.Point(290, 19);
            this.AutoAttendenceButton.Name = "AutoAttendenceButton";
            this.AutoAttendenceButton.Size = new System.Drawing.Size(149, 23);
            this.AutoAttendenceButton.TabIndex = 3;
            this.AutoAttendenceButton.Text = "Auto Attendence (10)";
            this.AutoAttendenceButton.UseVisualStyleBackColor = true;
            this.AutoAttendenceButton.Click += new System.EventHandler(this.AutoAttendenceButton_Click);
            // 
            // ClearColumnButton
            // 
            this.ClearColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearColumnButton.Location = new System.Drawing.Point(458, 19);
            this.ClearColumnButton.Name = "ClearColumnButton";
            this.ClearColumnButton.Size = new System.Drawing.Size(149, 23);
            this.ClearColumnButton.TabIndex = 2;
            this.ClearColumnButton.Text = "Clear Column";
            this.ClearColumnButton.UseVisualStyleBackColor = true;
            this.ClearColumnButton.Click += new System.EventHandler(this.ClearColumnButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ReloadButton.Location = new System.Drawing.Point(144, 19);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(100, 23);
            this.ReloadButton.TabIndex = 1;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateButton.Location = new System.Drawing.Point(6, 19);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 23);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Session:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Course No:";
            // 
            // SessionLabel
            // 
            this.SessionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SessionLabel.AutoSize = true;
            this.SessionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionLabel.ForeColor = System.Drawing.Color.Red;
            this.SessionLabel.Location = new System.Drawing.Point(94, 14);
            this.SessionLabel.Name = "SessionLabel";
            this.SessionLabel.Size = new System.Drawing.Size(78, 20);
            this.SessionLabel.TabIndex = 7;
            this.SessionLabel.Text = "Session:";
            // 
            // CourseNoLabel
            // 
            this.CourseNoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.CourseNoLabel.AutoSize = true;
            this.CourseNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseNoLabel.ForeColor = System.Drawing.Color.Red;
            this.CourseNoLabel.Location = new System.Drawing.Point(290, 14);
            this.CourseNoLabel.Name = "CourseNoLabel";
            this.CourseNoLabel.Size = new System.Drawing.Size(98, 20);
            this.CourseNoLabel.TabIndex = 8;
            this.CourseNoLabel.Text = "Course No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CourseNoLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SessionLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 40);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // MarksEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MarksEntryControl";
            this.Size = new System.Drawing.Size(906, 440);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton SearchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button AutoAttendenceButton;
        private System.Windows.Forms.Button ClearColumnButton;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ToolStripComboBox SessionToolStripComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SessionLabel;
        private System.Windows.Forms.Label CourseNoLabel;
        private System.Windows.Forms.ToolStripComboBox CourseNoToolStripComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarksIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendenceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_or_VivaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SA_or_secAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecBColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RetakeColumn;
        private System.Windows.Forms.ToolStripButton ReloadCourseToolStripButton;
    }
}
