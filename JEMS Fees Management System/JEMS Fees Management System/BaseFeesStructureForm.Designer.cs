namespace JEMS_Fees_Management_System
{
    partial class BaseFeesStructureForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.adFeesPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prevClass = new System.Windows.Forms.Button();
            this.nextClass = new System.Windows.Forms.Button();
            this.admissionTable = new System.Windows.Forms.DataGridView();
            this.baseAdFeesDone = new System.Windows.Forms.Button();
            this.ad_fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school_dev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.furniture_fund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab_dev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belt_tie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adFeesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.admissionTable)).BeginInit();
            this.SuspendLayout();
            // 
            // adFeesPanel
            // 
            this.adFeesPanel.Controls.Add(this.baseAdFeesDone);
            this.adFeesPanel.Controls.Add(this.admissionTable);
            this.adFeesPanel.Controls.Add(this.nextClass);
            this.adFeesPanel.Controls.Add(this.prevClass);
            this.adFeesPanel.Controls.Add(this.label2);
            this.adFeesPanel.Controls.Add(this.classComboBox);
            this.adFeesPanel.Controls.Add(this.label1);
            this.adFeesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adFeesPanel.Location = new System.Drawing.Point(0, 0);
            this.adFeesPanel.Name = "adFeesPanel";
            this.adFeesPanel.Size = new System.Drawing.Size(561, 352);
            this.adFeesPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Admission Fees Structure";
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(54, 53);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(103, 21);
            this.classComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class";
            // 
            // prevClass
            // 
            this.prevClass.Location = new System.Drawing.Point(163, 53);
            this.prevClass.Name = "prevClass";
            this.prevClass.Size = new System.Drawing.Size(25, 21);
            this.prevClass.TabIndex = 3;
            this.prevClass.Text = "◀";
            this.prevClass.UseVisualStyleBackColor = true;
            // 
            // nextClass
            // 
            this.nextClass.Location = new System.Drawing.Point(194, 53);
            this.nextClass.Name = "nextClass";
            this.nextClass.Size = new System.Drawing.Size(25, 21);
            this.nextClass.TabIndex = 4;
            this.nextClass.Text = "▶";
            this.nextClass.UseVisualStyleBackColor = true;
            // 
            // admissionTable
            // 
            this.admissionTable.AllowUserToAddRows = false;
            this.admissionTable.AllowUserToDeleteRows = false;
            this.admissionTable.AllowUserToResizeColumns = false;
            this.admissionTable.AllowUserToResizeRows = false;
            this.admissionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.admissionTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ad_fees,
            this.school_dev,
            this.furniture_fund,
            this.lab_dev,
            this.caution,
            this.belt_tie,
            this.total});
            this.admissionTable.Location = new System.Drawing.Point(16, 99);
            this.admissionTable.Name = "admissionTable";
            this.admissionTable.RowHeadersVisible = false;
            this.admissionTable.Size = new System.Drawing.Size(517, 98);
            this.admissionTable.TabIndex = 5;
            // 
            // baseAdFeesDone
            // 
            this.baseAdFeesDone.BackColor = System.Drawing.SystemColors.Highlight;
            this.baseAdFeesDone.Location = new System.Drawing.Point(457, 317);
            this.baseAdFeesDone.Name = "baseAdFeesDone";
            this.baseAdFeesDone.Size = new System.Drawing.Size(75, 23);
            this.baseAdFeesDone.TabIndex = 6;
            this.baseAdFeesDone.Text = "Done";
            this.baseAdFeesDone.UseVisualStyleBackColor = false;
            // 
            // ad_fees
            // 
            this.ad_fees.HeaderText = "Admission Fees";
            this.ad_fees.MaxInputLength = 4;
            this.ad_fees.Name = "ad_fees";
            this.ad_fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ad_fees.Width = 70;
            // 
            // school_dev
            // 
            this.school_dev.HeaderText = "School Development";
            this.school_dev.MaxInputLength = 4;
            this.school_dev.Name = "school_dev";
            this.school_dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.school_dev.Width = 80;
            // 
            // furniture_fund
            // 
            this.furniture_fund.HeaderText = "Furniture Fund";
            this.furniture_fund.MaxInputLength = 4;
            this.furniture_fund.Name = "furniture_fund";
            this.furniture_fund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.furniture_fund.Width = 70;
            // 
            // lab_dev
            // 
            this.lab_dev.HeaderText = "Lab Development";
            this.lab_dev.MaxInputLength = 4;
            this.lab_dev.Name = "lab_dev";
            this.lab_dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lab_dev.Width = 80;
            // 
            // caution
            // 
            this.caution.HeaderText = "Caution Money";
            this.caution.MaxInputLength = 4;
            this.caution.Name = "caution";
            this.caution.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.caution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.caution.Width = 70;
            // 
            // belt_tie
            // 
            this.belt_tie.HeaderText = "Belt & Tie";
            this.belt_tie.MaxInputLength = 4;
            this.belt_tie.Name = "belt_tie";
            this.belt_tie.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.belt_tie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.belt_tie.Width = 70;
            // 
            // total
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.DefaultCellStyle = dataGridViewCellStyle2;
            this.total.HeaderText = "Total";
            this.total.MaxInputLength = 5;
            this.total.Name = "total";
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total.Width = 70;
            // 
            // BaseFeesStructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 352);
            this.Controls.Add(this.adFeesPanel);
            this.MinimizeBox = false;
            this.Name = "BaseFeesStructureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base Fees Structure";
            this.adFeesPanel.ResumeLayout(false);
            this.adFeesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.admissionTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel adFeesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView admissionTable;
        private System.Windows.Forms.Button nextClass;
        private System.Windows.Forms.Button prevClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Button baseAdFeesDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad_fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn school_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn furniture_fund;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab_dev;
        private System.Windows.Forms.DataGridViewTextBoxColumn caution;
        private System.Windows.Forms.DataGridViewTextBoxColumn belt_tie;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;

    }
}