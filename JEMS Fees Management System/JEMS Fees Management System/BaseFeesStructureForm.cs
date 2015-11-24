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
    public partial class BaseFeesStructureForm : Form
    {
        public Boolean complete = false;

        struct ADFees
        {
            public int ad_fees, school_dev, furn_fund, lab_dev, caution, belt_tie, total;
        }

        ADFees[] classes = new ADFees[19];

        public BaseFeesStructureForm()
        {
            InitializeComponent();

            //Admission Panel
            setUPAdmissionPanel();

            
        }

        void setUPAdmissionPanel()
        {
            admissionTable.Rows.Add("", "", "", "", "", "", "");
            for(int i=0;i<19;i++)
            {
                classes[i].ad_fees = 0;
                classes[i].school_dev = 0;
                classes[i].furn_fund = 0;
                classes[i].lab_dev = 0;
                classes[i].caution = 0;
                classes[i].belt_tie = 0;
                classes[i].total = 0;

                ComboBoxItem cls = new ComboBoxItem();
                cls.Value = Classes.classArray[i];
                cls.Text = Classes.getClassBranch(cls.Value);
                classComboBox.Items.Add(cls);
            }
            classComboBox.SelectedIndex = 0;
        }
    }

    public class ComboBoxItem
    {
        public String Text { get; set; }
        public String Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
