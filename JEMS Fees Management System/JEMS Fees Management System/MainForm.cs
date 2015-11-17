using System;
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
    public partial class MainForm : Form
    {
        static public RegularAdmissionForm rAForm;
        static public ProvisionalForm pForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if(rAForm == null)
            { 
                rAForm = new RegularAdmissionForm();
                rAForm.MdiParent = this;
                rAForm.WindowState = FormWindowState.Maximized;
                rAForm.Show();   
            }
            rAForm.BringToFront();
        }

        private void provisionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pForm == null)
            {
                pForm = new ProvisionalForm();
                pForm.MdiParent = this;
                pForm.WindowState = FormWindowState.Maximized;
                pForm.Show();
            }
            pForm.BringToFront();
        }
    }
}
