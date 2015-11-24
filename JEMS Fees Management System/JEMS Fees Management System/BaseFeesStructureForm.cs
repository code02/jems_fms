using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JEMS_Fees_Management_System
{
    public partial class BaseFeesStructureForm : Form
    {
        public Boolean complete ;
        static public Boolean copyReady ;

        struct ADFees
        {
            public int ad_fees, school_dev, furn_fund, lab_dev, caution, belt_tie, total;
        }

        ADFees[] classes = new ADFees[19];

        public BaseFeesStructureForm()
        {
            complete = false;
            copyReady = false;

            InitializeComponent();

            //Admission Panel
            setUPAdmissionPanel();

            copyReady = true;
            
        }

        void setUPAdmissionPanel()
        {
            admissionTable.Rows.Add("", "", "", "", "", "", "");

            for(int i=0;i<19;i++)
            {
                String getQuery = "Select * from " + Table.admission_base_struct.tableName +
                            " where " + Table.admission_base_struct.session + "=" + GlobalVariables.currentSession +
                            " and " + Table.admission_base_struct.clss + "= '" + Classes.classArray[i] + "'";

                classes[i].ad_fees = 0;
                classes[i].school_dev = 0;
                classes[i].furn_fund = 0;
                classes[i].lab_dev = 0;
                classes[i].caution = 0;
                classes[i].belt_tie = 0;
                classes[i].total = 0;

                using(SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                classes[i].total = 0;
                                classes[i].total += classes[i].ad_fees = Convert.ToInt32(dr[Table.admission_base_struct.ad_fees]);
                                classes[i].total += classes[i].school_dev = Convert.ToInt32(dr[Table.admission_base_struct.school_dev]);
                                classes[i].total += classes[i].furn_fund = Convert.ToInt32(dr[Table.admission_base_struct.furn_fund]);
                                classes[i].total += classes[i].lab_dev = Convert.ToInt32(dr[Table.admission_base_struct.lab_dev]);
                                classes[i].total += classes[i].caution = Convert.ToInt32(dr[Table.admission_base_struct.caution]);
                                classes[i].total += classes[i].belt_tie = Convert.ToInt32(dr[Table.admission_base_struct.belt_tie]);

                            }
                            dr.Close();
                        }
                        connection.Close();
                    }
                    catch (Exception)
                    { }


                }

                ComboBoxItem cls = new ComboBoxItem();
                cls.Value = Classes.classArray[i];
                cls.Text = Classes.getClassBranch(cls.Value);
                classComboBox.Items.Add(cls);
            }
            classComboBox.SelectedIndex = 0;
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            admissionTable[0, 0].Value = classes[classComboBox.SelectedIndex].ad_fees.ToString();
            admissionTable[1, 0].Value = classes[classComboBox.SelectedIndex].school_dev.ToString();
            admissionTable[2, 0].Value = classes[classComboBox.SelectedIndex].furn_fund.ToString();
            admissionTable[3, 0].Value = classes[classComboBox.SelectedIndex].lab_dev.ToString();
            admissionTable[4, 0].Value = classes[classComboBox.SelectedIndex].caution.ToString();
            admissionTable[5, 0].Value = classes[classComboBox.SelectedIndex].belt_tie.ToString();
            admissionTable[6, 0].Value = classes[classComboBox.SelectedIndex].total.ToString();

            copyReady = true;
        }

        private void admissionTableCopy()
        {
            bool ok = true;
            for(int i = 0; i < 19; i++ )
            { 
                if(classes[i].total == 0)
                {
                    ok = false;
                }
            }
            if (ok) 
                baseAdFeesDone.Enabled = true;
            else baseAdFeesDone.Enabled = false;

            ok = true;

            if (!copyReady) return;

            for(int i = 0; i < 7; i++)
            {
                if(!CommonMethods.valueBetween(admissionTable[i, 0].Value.ToString(), 0, 20000))
                {
                    ok = false;
                    break;
                }
            }
            
            if(ok && copyReady)
            {
                copyReady = false;
                classes[classComboBox.SelectedIndex].ad_fees = Int32.Parse(admissionTable[0, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].school_dev = Int32.Parse(admissionTable[1, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].furn_fund = Int32.Parse(admissionTable[2, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].lab_dev = Int32.Parse(admissionTable[3, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].caution = Int32.Parse(admissionTable[4, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].belt_tie = Int32.Parse(admissionTable[5, 0].Value.ToString());
                classes[classComboBox.SelectedIndex].total = 0;
                for (int i = 0; i < 6; i++)
                    classes[classComboBox.SelectedIndex].total += Int32.Parse(admissionTable[i, 0].Value.ToString());
                admissionTable[6, 0].Value = classes[classComboBox.SelectedIndex].total.ToString();
                copyReady = true;
            }
        }

        private void admissionTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            admissionTableCopy();
        }

        private void admissionTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            admissionTableCopy();
        }

        private void admissionTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            admissionTableCopy();
        }

        private void baseAdFeesDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    for (int i = 0; i < 19; i++)
                    {
                        String deleteQuery = "delete from " + Table.admission_base_struct.tableName + " where " +
                            Table.admission_base_struct.session + "=" + GlobalVariables.currentSession +
                            " and " + Table.admission_base_struct.clss + " ='" + Classes.classArray[i] + "'";
                        using (SqlCommand delCommand = new SqlCommand(deleteQuery, connection))
                        {
                            delCommand.ExecuteNonQuery();
                        }

                        String saveQuery = "insert into " + Table.admission_base_struct.tableName + " (" +
                            Table.admission_base_struct.session + ", " +
                            Table.admission_base_struct.clss + ", " +
                            Table.admission_base_struct.ad_fees + ", " +
                            Table.admission_base_struct.school_dev + ", " +
                            Table.admission_base_struct.furn_fund + ", " +
                            Table.admission_base_struct.lab_dev + ", " +
                            Table.admission_base_struct.caution + ", " +
                            Table.admission_base_struct.belt_tie + ") " + " values (" +
                            GlobalVariables.currentSession + ", '" +
                            Classes.classArray[i] + "', " +
                            classes[i].ad_fees + ", " +
                            classes[i].school_dev + ", " +
                            classes[i].furn_fund + ", " +
                            classes[i].lab_dev + ", " +
                            classes[i].caution + ", " +
                            classes[i].belt_tie + ");";
                        using (SqlCommand saveCommand = new SqlCommand(saveQuery, connection))
                        {
                            saveCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
            Close();
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
