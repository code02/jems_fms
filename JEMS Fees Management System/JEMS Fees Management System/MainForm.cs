using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class MainForm : Form
    {
        static public RegularAdmissionForm rAForm;
        static public ProvisionalForm pForm;
        static public OldStudentForm oSForm;
        static public ProvisionConfirmForm pCForm;

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

        private void oldStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oSForm == null)
            {
                oSForm = new OldStudentForm();
                oSForm.MdiParent = this;
                oSForm.WindowState = FormWindowState.Maximized;
                oSForm.Show();
            }
            oSForm.BringToFront();
        }

        private void provisionalConfirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pCForm == null)
            {
                pCForm = new ProvisionConfirmForm();
                pCForm.MdiParent = this;
                pCForm.WindowState = FormWindowState.Maximized;
                pCForm.Show();
            }
            pCForm.BringToFront();
        }

        private void mainFormLoad(object sender, EventArgs e)
        {

            // Check database Connectivity and database integrity
            //if()
            
            {
                using (SetUp setUp = new SetUp())
                {
                    setUp.Owner = this;
                    setUp.ShowDialog();
                    if (!setUp.AllSet) this.Close();

                }
            }
        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
