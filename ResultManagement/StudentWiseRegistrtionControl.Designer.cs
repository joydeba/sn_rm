namespace ResultManagement
{
    partial class StudentWiseRegistrtionControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewRegistrationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SessionToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.BatchToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.YearToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.TermToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stdIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regYearColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regTermColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfRegisteredStudentsLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(190)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewRegistrationToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.SessionToolStripComboBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.BatchToolStripComboBox,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.YearToolStripComboBox,
            this.toolStripSeparator5,
            this.toolStripLabel4,
            this.TermToolStripComboBox,
            this.toolStripSeparator6,
            this.SearchToolStripButton,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NewRegistrationToolStripButton
            // 
            this.NewRegistrationToolStripButton.Image = global::ResultManagement.Properties.Resources.plus_32;
            this.NewRegistrationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewRegistrationToolStripButton.Name = "NewRegistrationToolStripButton";
            this.NewRegistrationToolStripButton.Size = new System.Drawing.Size(121, 24);
            this.NewRegistrationToolStripButton.Text = "New Registration";
            this.NewRegistrationToolStripButton.Click += new System.EventHandler(this.NewRegistrationToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 24);
            this.toolStripLabel1.Text = "Session :      ";
            // 
            // SessionToolStripComboBox
            // 
            this.SessionToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SessionToolStripComboBox.Name = "SessionToolStripComboBox";
            this.SessionToolStripComboBox.Size = new System.Drawing.Size(90, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(58, 24);
            this.toolStripLabel2.Text = "Batch:      ";
            // 
            // BatchToolStripComboBox
            // 
            this.BatchToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BatchToolStripComboBox.Name = "BatchToolStripComboBox";
            this.BatchToolStripComboBox.Size = new System.Drawing.Size(75, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
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
            // SearchToolStripButton
            // 
            this.SearchToolStripButton.Image = global::ResultManagement.Properties.Resources.forum_search;
            this.SearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchToolStripButton.Name = "SearchToolStripButton";
            this.SearchToolStripButton.Size = new System.Drawing.Size(84, 24);
            this.SearchToolStripButton.Text = "Search      ";
            this.SearchToolStripButton.Click += new System.EventHandler(this.SearchToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdIDColumn,
            this.SessionIDColumn,
            this.SessionColumn,
            this.StudentIDColumn,
            this.regYearColumn,
            this.regTermColumn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 357);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // stdIDColumn
            // 
            this.stdIDColumn.HeaderText = "StdID";
            this.stdIDColumn.Name = "stdIDColumn";
            this.stdIDColumn.ReadOnly = true;
            this.stdIDColumn.Visible = false;
            this.stdIDColumn.Width = 40;
            // 
            // SessionIDColumn
            // 
            this.SessionIDColumn.HeaderText = "SessionID";
            this.SessionIDColumn.Name = "SessionIDColumn";
            this.SessionIDColumn.ReadOnly = true;
            this.SessionIDColumn.Visible = false;
            this.SessionIDColumn.Width = 61;
            // 
            // SessionColumn
            // 
            this.SessionColumn.FillWeight = 24.44988F;
            this.SessionColumn.HeaderText = "Session";
            this.SessionColumn.Name = "SessionColumn";
            this.SessionColumn.ReadOnly = true;
            this.SessionColumn.Width = 69;
            // 
            // StudentIDColumn
            // 
            this.StudentIDColumn.FillWeight = 175.5502F;
            this.StudentIDColumn.HeaderText = "Student ID";
            this.StudentIDColumn.Name = "StudentIDColumn";
            this.StudentIDColumn.ReadOnly = true;
            this.StudentIDColumn.Width = 83;
            // 
            // regYearColumn
            // 
            this.regYearColumn.HeaderText = "Year";
            this.regYearColumn.Name = "regYearColumn";
            this.regYearColumn.ReadOnly = true;
            this.regYearColumn.Width = 54;
            // 
            // regTermColumn
            // 
            this.regTermColumn.HeaderText = "Term";
            this.regTermColumn.Name = "regTermColumn";
            this.regTermColumn.ReadOnly = true;
            this.regTermColumn.Width = 56;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(28, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 357);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Registered Students:";
            // 
            // numberOfRegisteredStudentsLabel
            // 
            this.numberOfRegisteredStudentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfRegisteredStudentsLabel.AutoSize = true;
            this.numberOfRegisteredStudentsLabel.Location = new System.Drawing.Point(189, 427);
            this.numberOfRegisteredStudentsLabel.Name = "numberOfRegisteredStudentsLabel";
            this.numberOfRegisteredStudentsLabel.Size = new System.Drawing.Size(13, 13);
            this.numberOfRegisteredStudentsLabel.TabIndex = 6;
            this.numberOfRegisteredStudentsLabel.Text = "0";
            // 
            // StudentWiseRegistrtionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numberOfRegisteredStudentsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StudentWiseRegistrtionControl";
            this.Size = new System.Drawing.Size(878, 459);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton NewRegistrationToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox SessionToolStripComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox BatchToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton SearchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox YearToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox TermToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regYearColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regTermColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numberOfRegisteredStudentsLabel;
    }
}
