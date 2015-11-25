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
        public Boolean complete;
        static public Boolean copyReady;

        struct ADFees
        {
            public int ad_fees, school_dev, furn_fund, lab_dev, caution, belt_tie, total;
        }

        struct ANFees
        {
            public int school_dev, lab_dev, caution, total;
        }

        struct MTFees
        {
            public int a;
        }

        ADFees[] adClasses = new ADFees[19];

        ANFees[] anClasses = new ANFees[19];




        public BaseFeesStructureForm()
        {
            complete = false;
            copyReady = false;

            InitializeComponent();

            //Admission Panel
            setUPAdmissionPanel();

            //Annual Panel
            setUPAnnualPanel();

            //Monthly Panel
            setUPMonthlyPanel();


            copyReady = true;

            bringUp(ref adFeesPanel);

            
        }


        void bringUp(ref Panel panel)
        {
            adFeesPanel.Visible = false;
            anFeesPanel.Visible = false;
            mtFeesPanel.Visible = false;

            panel.Visible = true;

            if (panel.Equals(adFeesPanel))
            {
                this.Size = new Size(570, 280);
                this.MinimumSize = new Size(450,270);

            }
            
            if (panel.Equals(anFeesPanel))
            {
                this.Size = new Size(470, 270);
                this.MinimumSize = new Size(450, 270);
            }
            
            if (panel.Equals(mtFeesPanel))
            {
                this.Size = new Size(1000, 500);
                this.MinimumSize = new Size(450, 350);
            }

        }

        // Admission Panel

        void setUPAdmissionPanel()
        {
            admissionTable.Rows.Add("", "", "", "", "", "", "");

            for(int i=0;i<19;i++)
            {
                String getQuery = "Select * from " + Table.admission_base_struct.tableName +
                            " where " + Table.admission_base_struct.session + "=" + GlobalVariables.currentSession +
                            " and " + Table.admission_base_struct.clss + "= '" + Classes.classArray[i] + "'";

                adClasses[i].ad_fees = 0;
                adClasses[i].school_dev = 0;
                adClasses[i].furn_fund = 0;
                adClasses[i].lab_dev = 0;
                adClasses[i].caution = 0;
                adClasses[i].belt_tie = 0;
                adClasses[i].total = 0;

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
                                adClasses[i].total = 0;
                                adClasses[i].total += adClasses[i].ad_fees = Convert.ToInt32(dr[Table.admission_base_struct.ad_fees]);
                                adClasses[i].total += adClasses[i].school_dev = Convert.ToInt32(dr[Table.admission_base_struct.school_dev]);
                                adClasses[i].total += adClasses[i].furn_fund = Convert.ToInt32(dr[Table.admission_base_struct.furn_fund]);
                                adClasses[i].total += adClasses[i].lab_dev = Convert.ToInt32(dr[Table.admission_base_struct.lab_dev]);
                                adClasses[i].total += adClasses[i].caution = Convert.ToInt32(dr[Table.admission_base_struct.caution]);
                                adClasses[i].total += adClasses[i].belt_tie = Convert.ToInt32(dr[Table.admission_base_struct.belt_tie]);

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
                adClassSelect.Items.Add(cls);
            }
            adClassSelect.SelectedIndex = 0;
            baseAdFeesDone.Enabled = false;
            admissionTableCopy();
        }

        private void adClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            admissionTable[0, 0].Value = adClasses[adClassSelect.SelectedIndex].ad_fees.ToString();
            admissionTable[1, 0].Value = adClasses[adClassSelect.SelectedIndex].school_dev.ToString();
            admissionTable[2, 0].Value = adClasses[adClassSelect.SelectedIndex].furn_fund.ToString();
            admissionTable[3, 0].Value = adClasses[adClassSelect.SelectedIndex].lab_dev.ToString();
            admissionTable[4, 0].Value = adClasses[adClassSelect.SelectedIndex].caution.ToString();
            admissionTable[5, 0].Value = adClasses[adClassSelect.SelectedIndex].belt_tie.ToString();
            admissionTable[6, 0].Value = adClasses[adClassSelect.SelectedIndex].total.ToString();

            copyReady = true;
        }

        private void admissionTableCopy()
        {
            bool ok = true;
            for(int i = 0; i < 19; i++ )
            { 
                if(adClasses[i].total == 0)
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
                adClasses[adClassSelect.SelectedIndex].ad_fees = Int32.Parse(admissionTable[0, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].school_dev = Int32.Parse(admissionTable[1, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].furn_fund = Int32.Parse(admissionTable[2, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].lab_dev = Int32.Parse(admissionTable[3, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].caution = Int32.Parse(admissionTable[4, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].belt_tie = Int32.Parse(admissionTable[5, 0].Value.ToString());
                adClasses[adClassSelect.SelectedIndex].total = 0;
                for (int i = 0; i < 6; i++)
                    adClasses[adClassSelect.SelectedIndex].total += Int32.Parse(admissionTable[i, 0].Value.ToString());
                admissionTable[6, 0].Value = adClasses[adClassSelect.SelectedIndex].total.ToString();
                copyReady = true;
            }
        }

        private void admissionTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            admissionTableCopy();
        }

        private void admissionTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                            adClasses[i].ad_fees + ", " +
                            adClasses[i].school_dev + ", " +
                            adClasses[i].furn_fund + ", " +
                            adClasses[i].lab_dev + ", " +
                            adClasses[i].caution + ", " +
                            adClasses[i].belt_tie + ");";
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

            bringUp(ref anFeesPanel);


        }

        // End of Admission Panel

        // Annual Panel

        void setUPAnnualPanel()
        {
            annualTable.Rows.Add("", "", "", "");

            for (int i = 0; i < 19; i++)
            {
                String getQuery = "Select * from " + Table.annual_base_struct.tableName +
                            " where " + Table.annual_base_struct.session + "=" + GlobalVariables.currentSession +
                            " and " + Table.annual_base_struct.clss + "= '" + Classes.classArray[i] + "'";

                anClasses[i].school_dev = 0;
                anClasses[i].lab_dev = 0;
                anClasses[i].caution = 0;
                anClasses[i].total = 0;

                using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(getQuery, connection))
                        {
                            SqlDataReader dr = command.ExecuteReader();
                            if (dr.Read())
                            {
                                anClasses[i].total = 0;
                                anClasses[i].total += anClasses[i].school_dev = Convert.ToInt32(dr[Table.annual_base_struct.school_dev]);
                                anClasses[i].total += anClasses[i].lab_dev = Convert.ToInt32(dr[Table.annual_base_struct.lab_dev]);
                                anClasses[i].total += anClasses[i].caution = Convert.ToInt32(dr[Table.annual_base_struct.caution]);
                                
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
                anClassSelect.Items.Add(cls);
            }
            anClassSelect.SelectedIndex = 0;
            baseAnnualDone.Enabled = false;
            annualTableCopy();
        }

        private void anClassSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyReady = false;

            annualTable[0, 0].Value = anClasses[anClassSelect.SelectedIndex].school_dev.ToString();
            annualTable[1, 0].Value = anClasses[anClassSelect.SelectedIndex].lab_dev.ToString();
            annualTable[2, 0].Value = anClasses[anClassSelect.SelectedIndex].caution.ToString();
            annualTable[3, 0].Value = anClasses[anClassSelect.SelectedIndex].total.ToString();

            copyReady = true;
        }

        private void annualTableCopy()
        {
            bool ok = true;
            for (int i = 0; i < 19; i++)
            {
                if (anClasses[i].total == 0)
                {
                    ok = false;
                }
            }
            if (ok)
                baseAnnualDone.Enabled = true;
            else baseAnnualDone.Enabled = false;

            ok = true;

            if (!copyReady) return;

            for (int i = 0; i < 4; i++)
            {
                if (!CommonMethods.valueBetween(annualTable[i, 0].Value.ToString(), 0, 20000))
                {
                    ok = false;
                    break;
                }
            }

            if (ok && copyReady)
            {
                copyReady = false;
                anClasses[anClassSelect.SelectedIndex].school_dev = Int32.Parse(annualTable[0, 0].Value.ToString());
                anClasses[anClassSelect.SelectedIndex].lab_dev = Int32.Parse(annualTable[1, 0].Value.ToString());
                anClasses[anClassSelect.SelectedIndex].caution = Int32.Parse(annualTable[2, 0].Value.ToString());
                anClasses[anClassSelect.SelectedIndex].total = 0;
                for (int i = 0; i < 3; i++)
                    anClasses[anClassSelect.SelectedIndex].total += Int32.Parse(annualTable[i, 0].Value.ToString());
                annualTable[3, 0].Value = anClasses[anClassSelect.SelectedIndex].total.ToString();
                copyReady = true;
            }
        }

        private void annualTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            annualTableCopy();
        }

        private void annualTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            annualTableCopy();
        }

        private void baseAnnualPrev_Click(object sender, EventArgs e)
        {
            bringUp(ref adFeesPanel);
            
        }

        private void baseAnnualDone_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    for (int i = 0; i < 19; i++)
                    {
                        String deleteQuery = "delete from " + Table.annual_base_struct.tableName + " where " +
                            Table.annual_base_struct.session + "=" + GlobalVariables.currentSession +
                            " and " + Table.annual_base_struct.clss + " ='" + Classes.classArray[i] + "'";
                        using (SqlCommand delCommand = new SqlCommand(deleteQuery, connection))
                        {
                            delCommand.ExecuteNonQuery();
                        }

                        String saveQuery = "insert into " + Table.annual_base_struct.tableName + " (" +
                            Table.annual_base_struct.session + ", " +
                            Table.annual_base_struct.clss + ", " +
                            Table.annual_base_struct.school_dev + ", " +
                            Table.annual_base_struct.lab_dev + ", " +
                            Table.annual_base_struct.caution + ") " + " values (" +
                            GlobalVariables.currentSession + ", '" +
                            Classes.classArray[i] + "', " +
                            anClasses[i].school_dev + ", " +
                            anClasses[i].lab_dev + ", " +
                            anClasses[i].caution + ");";
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

            bringUp(ref mtFeesPanel);

        }

        //End of Annual


        // Monthly Panel

        void setUPMonthlyPanel()
        {
            String[] months = {"April", "May", "June", "July", "Aug",
                              "Sep", "Oct", "Nov", "Dec","Jan","Feb","March"};
            for(int i=0;i<12;i++)
            {
                monthlyTable.Rows.Add(months[i], "", "", "", "", "", "", "", "", "", "", "", "", "");
            }



        }

        private void monthlyPrev_Click(object sender, EventArgs e)
        {
            bringUp(ref anFeesPanel);

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
