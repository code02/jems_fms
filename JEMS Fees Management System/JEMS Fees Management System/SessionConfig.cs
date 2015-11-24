using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    public partial class SessionConfig : Form
    {
        public bool cancellable = true;
        public bool killParent = false;
        public bool forceClose = false;
        public bool done = false;
        bool[] complete = new bool[9]{false,false,false,false,false,false,false,false,false};

        public SessionConfig()
        {
            InitializeComponent();
            ButtonReset();
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (cancellable || done)
            {
                e.Cancel = false;
            }
            else
            {   if(!forceClose)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to cancel session setup?", "Cancel Session Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        killParent = true;
                        e.Cancel = false;
                    }
                    else
                    e.Cancel = true;
                }
                else
                {
                    killParent = true;
                    e.Cancel = false;
                }

            }
        }

        void ButtonReset()
        { 
            bool check = true;
            for (int i = 0; i < 9; i++) 
            {
                check = check && complete[i];
                //if (!complete[i]) check = false;
            }
            if (check) sessionDone.Enabled = true;
            else sessionDone.Enabled = false;
        }

        private void currentSession_TextChanged(object sender, EventArgs e)
        {
            if (currentSession.Text.Length == 0)
            {
                endSessionLabel.ForeColor = Color.Black;
                endSessionLabel.Text = "-20XX";
                complete[0] = false;
            }
            else
                if (!CommonMethods.isNumeric(currentSession.Text, 4))
                {
                    endSessionLabel.ForeColor = Color.Red;
                    endSessionLabel.Text = "-20XX";
                    complete[0] = false;
                }
                else
                {
                    int val = Int32.Parse(currentSession.Text);
                    if (val < 2014 || val > 2050)
                    {
                        endSessionLabel.ForeColor = Color.Red;
                        endSessionLabel.Text = "-20XX";
                        complete[0] = false;
                    }
                    else
                    {
                        endSessionLabel.ForeColor = Color.Black;
                        complete[0] = true;
                        endSessionLabel.Text = "-" + (val + 1);
                    }
                }
            ButtonReset();
        }

        private void warnFees_TextChanged(object sender, EventArgs e)
        {
            if (warnFees.Text.Length==0)
            {
                complete[1] = false;
                warn_fees_invalid.Visible = false;
            }
            else
            {
                complete[1] = CommonMethods.valueBetween(warnFees.Text,0,1000);
                warn_fees_invalid.Visible = !complete[1];
            }
                
            ButtonReset();
        
        }

        private void lateFees_TextChanged(object sender, EventArgs e)
        {
            if (lateFees.Text.Length == 0)
            {
                complete[2] = false;
                late_fees_invalid.Visible = false;
            }
            else
            {
                complete[2] = CommonMethods.valueBetween(lateFees.Text, 0, 1000);
                late_fees_invalid.Visible = !complete[2];
            }

            ButtonReset();
        }

        private void adFFees_TextChanged(object sender, EventArgs e)
        {
            if (adFFees.Text.Length == 0)
            {
                complete[3] = false;
                adf_invalid.Visible = false;
            }
            else
            {
                complete[3] = CommonMethods.valueBetween(adFFees.Text, 0, 1000);
                adf_invalid.Visible = !complete[3];
            }
            ButtonReset();
        }

        private void beltTie_TextChanged(object sender, EventArgs e)
        {
            if (beltTie.Text.Length == 0)
            {
                complete[4] = false;
                belttie_invalid.Visible = false;
            }
            else
            {
                complete[4] = CommonMethods.valueBetween(beltTie.Text, 0, 1000);
                belttie_invalid.Visible = !complete[4];
            }

            ButtonReset();
        }

        private void dupDiary_TextChanged(object sender, EventArgs e)
        {
            if (dupDiary.Text.Length == 0)
            {
                complete[5] = false;
                dupDiary_invalid.Visible = false;
            }
            else
            {
                complete[5] = CommonMethods.valueBetween(dupDiary.Text, 0, 1000);
                dupDiary_invalid.Visible = !complete[5];
            }

            ButtonReset();
        }

        private void dupRC_TextChanged(object sender, EventArgs e)
        {
            if (dupRC.Text.Length == 0)
            {
                complete[6] = false;
                dupRC_invalid.Visible = false;
            }
            else
            {
                complete[6] = CommonMethods.valueBetween(dupRC.Text, 0, 1000);
                dupRC_invalid.Visible = !complete[6];
            }

            ButtonReset();
        }

        private void dupTC_TextChanged(object sender, EventArgs e)
        {
            if (dupTC.Text.Length == 0)
            {
                complete[7] = false;
                dupTC_invalid.Visible = false;
            }
            else
            {
                complete[7] = CommonMethods.valueBetween(dupTC.Text, 0, 1000);
                dupTC_invalid.Visible = !complete[7];
            }

            ButtonReset();
        }

        private void caution_TextChanged(object sender, EventArgs e)
        {
            if (caution.Text.Length == 0)
            {
                complete[8] = false;
                caution_invalid.Visible = false;
            }
            else
            {
                complete[8] = CommonMethods.valueBetween(caution.Text, 0, 1000);
                caution_invalid.Visible = !complete[8];
            }

            ButtonReset();
        }

        private void sessionDone_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(lateFees.Text)< Int32.Parse(warnFees.Text))
            {
                late_fees_invalid.Visible = true;
                complete[2] = false;
                ButtonReset();
                return;
            }

            String adrs, pvrs, afrs, anrs, mtrs, otrs, stid, prid;
            adrs = pvrs = afrs = anrs = mtrs = otrs = stid = prid = "";
            bool sessionExists = false;
            using(SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String query = "Select * from session_info where session = " + currentSession.Text;
                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        while(dr.Read())
                        {
                            sessionExists = true;
                            adrs = dr[Table.session_info.admission_rec_start].ToString();
                            pvrs = dr[Table.session_info.prov_rec_start].ToString();
                            afrs = dr[Table.session_info.ad_form_rec_start].ToString();
                            anrs = dr[Table.session_info.annual_rec_start].ToString();
                            mtrs = dr[Table.session_info.monthly_rec_start].ToString();
                            otrs = dr[Table.session_info.other_rec_start].ToString();
                            stid = dr[Table.session_info.st_id_start].ToString();
                            prid = dr[Table.session_info.prov_id_start].ToString();

                        }
                        dr.Close();
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    connection.Close();
                }
            }
            
            if(!sessionExists)
            {
                String ssn = currentSession.Text.Substring(2, 2);
                adrs = Receipt.admission + ssn + "0001";
                pvrs = Receipt.provisional + ssn + "0001";
                afrs = Receipt.adForm + ssn + "0001";
                anrs = Receipt.annual + ssn + "0001";
                mtrs = Receipt.monthly + ssn + "0001";
                otrs = Receipt.other + ssn + "0001";
                stid = "ST" + ssn + "0001";
                prid = "PV" + ssn + "0001";
            }
            else
            {
                using(SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        connection.Open();
                        String dumpQuery = "truncate table session_info ";
                        using(SqlCommand dumpCommand = new SqlCommand(dumpQuery,connection))
                        {
                            dumpCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {   DialogResult dr = MessageBox.Show("Some Error Occurred","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        if(dr == System.Windows.Forms.DialogResult.OK)
                        {   forceClose = true;
                            Close();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
            String insertQuery = "insert into " + Table.session_info.tableName + " (" +
            Table.session_info.session + ", " +
            Table.session_info.admission_rec_start + ", " +
            Table.session_info.prov_rec_start + ", " +
            Table.session_info.ad_form_rec_start + ", " +
            Table.session_info.annual_rec_start + ", " +
            Table.session_info.monthly_rec_start + ", " +
            Table.session_info.other_rec_start + ", " +
            Table.session_info.st_id_start + ", " +
            Table.session_info.prov_id_start + ", " +
            Table.session_info.belt_tie + ", " +
            Table.session_info.warn_fees_date + ", " +
            Table.session_info.default_warn_fees_date + ", " +
            Table.session_info.warn_fees + ", " +
            Table.session_info.late_fees + ", " +
            Table.session_info.dup_diary + ", " +
            Table.session_info.dup_rc + ", " +
            Table.session_info.dup_tc + ", " +
            Table.session_info.ad_form + ", " +
            Table.session_info.caution + ") " + " values ( " +
            currentSession.Text + ", " +
            "'" + adrs + "', " +
            "'" + pvrs + "', " +
            "'" + afrs + "', " +
            "'" + anrs + "', " +
            "'" + mtrs + "', " +
            "'" + otrs + "', " +
            "'" + stid + "', " +
            "'" + prid + "', " +
            beltTie.Text + ", " +
            warnDate.Value.ToString() + ", " +
            warnDate.Value.ToString() + ", " +
            warnFees.Text + ", " +
            lateFees.Text + ", " +
            dupDiary.Text + ", " +
            dupRC.Text + ", " +
            dupTC.Text + ", " +
            adFFees.Text + ", " +
            caution.Text + ")";

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        forceClose = true;
                        Close();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            done = true;
            Close();

        }
        
    }
}
