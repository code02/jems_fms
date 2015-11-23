namespace JEMS_Fees_Management_System
{
    partial class SessionConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.currentSession = new System.Windows.Forms.TextBox();
            this.endSessionLabel = new System.Windows.Forms.Label();
            this.warnFees = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lateFees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.warnDate = new System.Windows.Forms.NumericUpDown();
            this.adFFees = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.beltTie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dupDiary = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dupRC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dupTC = new System.Windows.Forms.TextBox();
            this.sessionDone = new System.Windows.Forms.Button();
            this.warn_fees_invalid = new System.Windows.Forms.Label();
            this.late_fees_invalid = new System.Windows.Forms.Label();
            this.adf_invalid = new System.Windows.Forms.Label();
            this.belttie_invalid = new System.Windows.Forms.Label();
            this.dupDiary_invalid = new System.Windows.Forms.Label();
            this.dupRC_invalid = new System.Windows.Forms.Label();
            this.dupTC_invalid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Session";
            // 
            // currentSession
            // 
            this.currentSession.Location = new System.Drawing.Point(130, 13);
            this.currentSession.MaxLength = 4;
            this.currentSession.Name = "currentSession";
            this.currentSession.Size = new System.Drawing.Size(35, 20);
            this.currentSession.TabIndex = 1;
            this.currentSession.TextChanged += new System.EventHandler(this.currentSession_TextChanged);
            // 
            // endSessionLabel
            // 
            this.endSessionLabel.AutoSize = true;
            this.endSessionLabel.Location = new System.Drawing.Point(171, 16);
            this.endSessionLabel.Name = "endSessionLabel";
            this.endSessionLabel.Size = new System.Drawing.Size(36, 13);
            this.endSessionLabel.TabIndex = 2;
            this.endSessionLabel.Text = "-20XX";
            // 
            // warnFees
            // 
            this.warnFees.Location = new System.Drawing.Point(130, 40);
            this.warnFees.MaxLength = 4;
            this.warnFees.Name = "warnFees";
            this.warnFees.Size = new System.Drawing.Size(35, 20);
            this.warnFees.TabIndex = 2;
            this.warnFees.TextChanged += new System.EventHandler(this.warnFees_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Warning Fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Warn Date";
            // 
            // lateFees
            // 
            this.lateFees.Location = new System.Drawing.Point(130, 92);
            this.lateFees.MaxLength = 4;
            this.lateFees.Name = "lateFees";
            this.lateFees.Size = new System.Drawing.Size(35, 20);
            this.lateFees.TabIndex = 4;
            this.lateFees.TextChanged += new System.EventHandler(this.lateFees_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Late Fees";
            // 
            // warnDate
            // 
            this.warnDate.Location = new System.Drawing.Point(130, 66);
            this.warnDate.Maximum = new decimal(new int[] {
            27,
            0,
            0,
            0});
            this.warnDate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.warnDate.Name = "warnDate";
            this.warnDate.Size = new System.Drawing.Size(40, 20);
            this.warnDate.TabIndex = 3;
            this.warnDate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // adFFees
            // 
            this.adFFees.Location = new System.Drawing.Point(130, 118);
            this.adFFees.MaxLength = 4;
            this.adFFees.Name = "adFFees";
            this.adFFees.Size = new System.Drawing.Size(35, 20);
            this.adFFees.TabIndex = 5;
            this.adFFees.TextChanged += new System.EventHandler(this.adFFees_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Admission Form";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Belt && Tie";
            // 
            // beltTie
            // 
            this.beltTie.Location = new System.Drawing.Point(130, 144);
            this.beltTie.MaxLength = 4;
            this.beltTie.Name = "beltTie";
            this.beltTie.Size = new System.Drawing.Size(35, 20);
            this.beltTie.TabIndex = 6;
            this.beltTie.TextChanged += new System.EventHandler(this.beltTie_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Duplicate Diary";
            // 
            // dupDiary
            // 
            this.dupDiary.Location = new System.Drawing.Point(130, 170);
            this.dupDiary.MaxLength = 4;
            this.dupDiary.Name = "dupDiary";
            this.dupDiary.Size = new System.Drawing.Size(35, 20);
            this.dupDiary.TabIndex = 7;
            this.dupDiary.TextChanged += new System.EventHandler(this.dupDiary_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Duplicate Report Card";
            // 
            // dupRC
            // 
            this.dupRC.Location = new System.Drawing.Point(130, 196);
            this.dupRC.MaxLength = 4;
            this.dupRC.Name = "dupRC";
            this.dupRC.Size = new System.Drawing.Size(35, 20);
            this.dupRC.TabIndex = 8;
            this.dupRC.TextChanged += new System.EventHandler(this.dupRC_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Duplicate TC";
            // 
            // dupTC
            // 
            this.dupTC.Location = new System.Drawing.Point(130, 222);
            this.dupTC.MaxLength = 4;
            this.dupTC.Name = "dupTC";
            this.dupTC.Size = new System.Drawing.Size(35, 20);
            this.dupTC.TabIndex = 9;
            this.dupTC.TextChanged += new System.EventHandler(this.dupTC_TextChanged);
            // 
            // sessionDone
            // 
            this.sessionDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.sessionDone.Location = new System.Drawing.Point(136, 257);
            this.sessionDone.Name = "sessionDone";
            this.sessionDone.Size = new System.Drawing.Size(75, 23);
            this.sessionDone.TabIndex = 10;
            this.sessionDone.Text = "Done";
            this.sessionDone.UseVisualStyleBackColor = false;
            this.sessionDone.Click += new System.EventHandler(this.sessionDone_Click);
            // 
            // warn_fees_invalid
            // 
            this.warn_fees_invalid.AutoSize = true;
            this.warn_fees_invalid.ForeColor = System.Drawing.Color.Red;
            this.warn_fees_invalid.Location = new System.Drawing.Point(171, 43);
            this.warn_fees_invalid.Name = "warn_fees_invalid";
            this.warn_fees_invalid.Size = new System.Drawing.Size(38, 13);
            this.warn_fees_invalid.TabIndex = 20;
            this.warn_fees_invalid.Text = "Invalid";
            this.warn_fees_invalid.Visible = false;
            // 
            // late_fees_invalid
            // 
            this.late_fees_invalid.AutoSize = true;
            this.late_fees_invalid.ForeColor = System.Drawing.Color.Red;
            this.late_fees_invalid.Location = new System.Drawing.Point(171, 94);
            this.late_fees_invalid.Name = "late_fees_invalid";
            this.late_fees_invalid.Size = new System.Drawing.Size(38, 13);
            this.late_fees_invalid.TabIndex = 22;
            this.late_fees_invalid.Text = "Invalid";
            this.late_fees_invalid.Visible = false;
            // 
            // adf_invalid
            // 
            this.adf_invalid.AutoSize = true;
            this.adf_invalid.ForeColor = System.Drawing.Color.Red;
            this.adf_invalid.Location = new System.Drawing.Point(171, 121);
            this.adf_invalid.Name = "adf_invalid";
            this.adf_invalid.Size = new System.Drawing.Size(38, 13);
            this.adf_invalid.TabIndex = 23;
            this.adf_invalid.Text = "Invalid";
            this.adf_invalid.Visible = false;
            // 
            // belttie_invalid
            // 
            this.belttie_invalid.AutoSize = true;
            this.belttie_invalid.ForeColor = System.Drawing.Color.Red;
            this.belttie_invalid.Location = new System.Drawing.Point(171, 147);
            this.belttie_invalid.Name = "belttie_invalid";
            this.belttie_invalid.Size = new System.Drawing.Size(38, 13);
            this.belttie_invalid.TabIndex = 24;
            this.belttie_invalid.Text = "Invalid";
            this.belttie_invalid.Visible = false;
            // 
            // dupDiary_invalid
            // 
            this.dupDiary_invalid.AutoSize = true;
            this.dupDiary_invalid.ForeColor = System.Drawing.Color.Red;
            this.dupDiary_invalid.Location = new System.Drawing.Point(171, 173);
            this.dupDiary_invalid.Name = "dupDiary_invalid";
            this.dupDiary_invalid.Size = new System.Drawing.Size(38, 13);
            this.dupDiary_invalid.TabIndex = 25;
            this.dupDiary_invalid.Text = "Invalid";
            this.dupDiary_invalid.Visible = false;
            // 
            // dupRC_invalid
            // 
            this.dupRC_invalid.AutoSize = true;
            this.dupRC_invalid.ForeColor = System.Drawing.Color.Red;
            this.dupRC_invalid.Location = new System.Drawing.Point(171, 199);
            this.dupRC_invalid.Name = "dupRC_invalid";
            this.dupRC_invalid.Size = new System.Drawing.Size(38, 13);
            this.dupRC_invalid.TabIndex = 26;
            this.dupRC_invalid.Text = "Invalid";
            this.dupRC_invalid.Visible = false;
            // 
            // dupTC_invalid
            // 
            this.dupTC_invalid.AutoSize = true;
            this.dupTC_invalid.ForeColor = System.Drawing.Color.Red;
            this.dupTC_invalid.Location = new System.Drawing.Point(171, 225);
            this.dupTC_invalid.Name = "dupTC_invalid";
            this.dupTC_invalid.Size = new System.Drawing.Size(38, 13);
            this.dupTC_invalid.TabIndex = 27;
            this.dupTC_invalid.Text = "Invalid";
            this.dupTC_invalid.Visible = false;
            // 
            // SessionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 297);
            this.Controls.Add(this.dupTC_invalid);
            this.Controls.Add(this.dupRC_invalid);
            this.Controls.Add(this.dupDiary_invalid);
            this.Controls.Add(this.belttie_invalid);
            this.Controls.Add(this.adf_invalid);
            this.Controls.Add(this.late_fees_invalid);
            this.Controls.Add(this.warn_fees_invalid);
            this.Controls.Add(this.sessionDone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dupTC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dupRC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dupDiary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.beltTie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.adFFees);
            this.Controls.Add(this.warnDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lateFees);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.warnFees);
            this.Controls.Add(this.endSessionLabel);
            this.Controls.Add(this.currentSession);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionConfig";
            this.Text = "Session Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            ((System.ComponentModel.ISupportInitialize)(this.warnDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentSession;
        private System.Windows.Forms.Label endSessionLabel;
        private System.Windows.Forms.TextBox warnFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lateFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown warnDate;
        private System.Windows.Forms.TextBox adFFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox beltTie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dupDiary;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dupRC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dupTC;
        private System.Windows.Forms.Button sessionDone;
        private System.Windows.Forms.Label warn_fees_invalid;
        private System.Windows.Forms.Label late_fees_invalid;
        private System.Windows.Forms.Label adf_invalid;
        private System.Windows.Forms.Label belttie_invalid;
        private System.Windows.Forms.Label dupDiary_invalid;
        private System.Windows.Forms.Label dupRC_invalid;
        private System.Windows.Forms.Label dupTC_invalid;
    }
}