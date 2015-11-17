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
    public partial class ProvisionalForm : Form
    {
        public ProvisionalForm()
        {
            InitializeComponent();
        }

        private void PFormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.pForm = null;
        }
    }
}
