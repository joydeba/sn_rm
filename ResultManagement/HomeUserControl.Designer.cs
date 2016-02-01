namespace ResultManagement
{
    partial class HomeUserControl
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
            this.TabulationSystemNameLabel = new System.Windows.Forms.Label();
            this.SchoolNameLabel = new System.Windows.Forms.Label();
            this.DisciplineNameLabel = new System.Windows.Forms.Label();
            this.UniversityNameLabel = new System.Windows.Forms.Label();
            this.UniversityPictureBox = new System.Windows.Forms.PictureBox();
            this.DisciplinePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.UniversityPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisciplinePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabulationSystemNameLabel
            // 
            this.TabulationSystemNameLabel.AutoSize = true;
            this.TabulationSystemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabulationSystemNameLabel.Location = new System.Drawing.Point(12, 18);
            this.TabulationSystemNameLabel.Name = "TabulationSystemNameLabel";
            this.TabulationSystemNameLabel.Size = new System.Drawing.Size(157, 20);
            this.TabulationSystemNameLabel.TabIndex = 1;
            this.TabulationSystemNameLabel.Text = "Tabulation System";
            // 
            // SchoolNameLabel
            // 
            this.SchoolNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SchoolNameLabel.AutoSize = true;
            this.SchoolNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolNameLabel.ForeColor = System.Drawing.Color.Blue;
            this.SchoolNameLabel.Location = new System.Drawing.Point(12, 83);
            this.SchoolNameLabel.Name = "SchoolNameLabel";
            this.SchoolNameLabel.Size = new System.Drawing.Size(534, 24);
            this.SchoolNameLabel.TabIndex = 2;
            this.SchoolNameLabel.Text = DAObjects.Depertment.SchoolName;
            // 
            // DisciplineNameLabel
            // 
            this.DisciplineNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DisciplineNameLabel.AutoSize = true;
            this.DisciplineNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisciplineNameLabel.ForeColor = System.Drawing.Color.Red;
            this.DisciplineNameLabel.Location = new System.Drawing.Point(12, 139);
            this.DisciplineNameLabel.Name = "DisciplineNameLabel";
            this.DisciplineNameLabel.Size = new System.Drawing.Size(593, 25);
            this.DisciplineNameLabel.TabIndex = 3;
            this.DisciplineNameLabel.Text = DAObjects.Depertment.DisciplineName;
            // 
            // UniversityNameLabel
            // 
            this.UniversityNameLabel.AutoSize = true;
            this.UniversityNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniversityNameLabel.Location = new System.Drawing.Point(272, 381);
            this.UniversityNameLabel.Name = "UniversityNameLabel";
            this.UniversityNameLabel.Size = new System.Drawing.Size(245, 25);
            this.UniversityNameLabel.TabIndex = 5;
            this.UniversityNameLabel.Text = "KHULNA UNIVERSITY";
            // 
            // UniversityPictureBox
            // 
            this.UniversityPictureBox.Image = global::ResultManagement.Properties.Resources.KU_logo;
            this.UniversityPictureBox.Location = new System.Drawing.Point(90, 287);
            this.UniversityPictureBox.Name = "UniversityPictureBox";
            this.UniversityPictureBox.Size = new System.Drawing.Size(150, 179);
            this.UniversityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UniversityPictureBox.TabIndex = 4;
            this.UniversityPictureBox.TabStop = false;
            // 
            // DisciplinePictureBox
            // 
            this.DisciplinePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DisciplinePictureBox.Location = new System.Drawing.Point(90, 78);
            this.DisciplinePictureBox.Name = "DisciplinePictureBox";
            this.DisciplinePictureBox.Size = new System.Drawing.Size(150, 175);
            this.DisciplinePictureBox.TabIndex = 0;
            this.DisciplinePictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TabulationSystemNameLabel);
            this.groupBox1.Controls.Add(this.SchoolNameLabel);
            this.groupBox1.Controls.Add(this.DisciplineNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(261, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 174);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // HomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UniversityNameLabel);
            this.Controls.Add(this.UniversityPictureBox);
            this.Controls.Add(this.DisciplinePictureBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "HomeUserControl";
            this.Size = new System.Drawing.Size(887, 497);
            ((System.ComponentModel.ISupportInitialize)(this.UniversityPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisciplinePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisciplinePictureBox;
        private System.Windows.Forms.Label TabulationSystemNameLabel;
        private System.Windows.Forms.Label SchoolNameLabel;
        private System.Windows.Forms.Label DisciplineNameLabel;
        private System.Windows.Forms.PictureBox UniversityPictureBox;
        private System.Windows.Forms.Label UniversityNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
