﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class ProvisionConfirmForm : Form
    {
        public ProvisionConfirmForm()
        {
            InitializeComponent();
        }

        private void ProvisionConfirmForm_Load(object sender, EventArgs e)
        {

        }

        private void FormResize(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel0.Visible = false;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel0.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProvisionConfirmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cancelAdmission = MessageBox.Show("Are you sure you want to cancel Admission?", "Cancel Admission", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (cancelAdmission == System.Windows.Forms.DialogResult.No) e.Cancel = true;
            else e.Cancel = false;
        }

        private void ProvisionConfirmFormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.pCForm = null;
        }


    }
}