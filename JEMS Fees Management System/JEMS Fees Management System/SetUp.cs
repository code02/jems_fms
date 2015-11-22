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
using System.Resources;

namespace JEMS_Fees_Management_System
{
    public partial class SetUp : Form
    {
        Boolean[] session_complete = new Boolean[2]{false,false};
        String[] terminals = new String[10] {"","","","","",
                                             "","","","",""};
        


        String connectionString;

        public SetUp()
        {
            InitializeComponent();
            ButtonReset();
            dbconnect_next.Enabled = false;
            sessionPanel.Visible = true; ;
            dbConnectPanel.Visible = false;
            for (int i = 1; i <= 10; i++ )
                dataGridView1.Rows.Add("" + i, "");
            
        }
        
        Boolean isNumeric(String str,int size)
        {
            if (str == null || str.Length == 0) return false;
            if (size != 0 && str.Length != size) return false;
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

    //Database Connection 


        private void dbconnect_test_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (db_server.Text == null || db_server.Text.Length <= 1 ||
                db_server.Text.Contains(" ") || db_server.Text.Contains(","))
            {
                db_server_invalid.Visible = true;
                check = false;
            }
            else db_server_invalid.Visible = false;

            if (db_id.Text == null || db_id.Text.Length <= 1 ||
                            db_id.Text.Contains(" ") || db_id.Text.Contains(","))
            {
                db_id_invalid.Visible = true;
                check = false;
            }
            else db_id_invalid.Visible = false;

            if (db_password.Text == null || db_password.Text.Length <= 1)
            {
                db_password_invalid.Visible = true;
                check = false;
            }
            else db_password_invalid.Visible = false;

            if (db_name.Text == null || db_name.Text.Length <= 1 ||
                db_name.Text.Contains(" ") || db_name.Text.Contains(","))
            {
                db_name_invalid.Visible = true;
                check = false;
            }
            else db_name_invalid.Visible = false;

            connectionString = "user id=" + db_id.Text + ";" +
                "password=" + db_password.Text + ";" +
                "server=" + db_server.Text + ";" +
                "Trusted_Connection=no;" +
                "database=" + db_name.Text + ";" +
                "connection timeout=" + db_timeout.Value.ToString() + ";";

            if(check)
                if(checkConnectivity())
                {
                    MessageBox.Show("Connection Successful!", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbconnect_next.Enabled = true;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Unable to establish Connection, check if server is ON", "Database Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dbconnect_next.Enabled = false;
                    check = false;

                }
        }

        bool checkConnectivity()
        { 
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    db_server.Enabled = false;
                    db_id.Enabled = false;
                    db_password.Enabled = false;
                    db_name.Enabled = false;
                    db_timeout.Enabled = false;
                    dbconnect_test.Enabled = false;
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    db_server.Enabled = true;
                    db_id.Enabled = true;
                    db_password.Enabled = true;
                    db_name.Enabled = true;
                    db_timeout.Enabled = true;
                    dbconnect_test.Enabled = true;
                    connection.Close();
                }
            }
            
        }

        private void dbConnectMod(object sender, EventArgs e)
        {
            db_server_invalid.Visible = false;
            db_id_invalid.Visible = false;
            db_password_invalid.Visible = false;
            db_name_invalid.Visible = false;
            dbconnect_next.Enabled = false;
        }



    //Database Connection End

    // Session Panel

        private void RowDeleted(object sender, DataGridViewRowEventArgs e)
        {
            DataModified();
        }

        private void DataModified()
        {
            //if (sessionPanel.Visible == false) return;
            bool empty = true;
            for(int i=0;i<=9;i++)
            {
                if (dataGridView1[1, i].Value != null && dataGridView1[1, i].Value.ToString().Length != 0)
                {
                    empty = false;
                }
            }
            if(empty)
            {   
                session_complete[1] = false;
                ButtonReset();
                return;
            }
            terminals = new String[10] {"","","","","",
                                        "","","","",""};
            for(int i=0;i<=9;i++)
            {
                if (dataGridView1[1, i].Value != null && dataGridView1[1, i].Value.ToString().Length != 0)
                {
                    String text = dataGridView1[1, i].Value.ToString();
                    if (terminals.Contains(text))
                    {
                        session_complete[1] = false;
                        ButtonReset();
                        return;
                    }
                    else
                    {
                        terminals[i] = text;
                    }
                }
            }
            session_complete[1] = true;
            ButtonReset();
        }
                
        private void session_TextChanged(object sender, EventArgs e)
        {
            if (sessionTextBox.Text!=null && isNumeric(sessionTextBox.Text,4))
            { 
                int val = Int32.Parse(sessionTextBox.Text);
                if(val > 2014 && val <= 2050)
                {
                    session_complete[0] = true;
                    ButtonReset();
                    endSessionLabel.Text = "-" + (val + 1);
                    return;
                }
            }
            endSessionLabel.Text = "-20XX";
            session_complete[0] = false;
            ButtonReset();
                    

        }

        void ButtonReset()
        {
            if (session_complete[0] && session_complete[1])
            {
                sessionNext.Enabled = true;
                
            }
            else
            {
                sessionNext.Enabled = false;
                //if (!session_complete[0] && !session_complete[1]) info.Text = "both not true";
                //else if (!session_complete[0]) info.Text = "0 not true";
                //else info.Text = "1 not true";
            }
        }

        private void dbconnect_next_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = false;
            sessionPanel.Visible = true;
        }

        private void sessionPrevious_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = true;
            sessionPanel.Visible = false;

        }

        private void TerminalCellModification(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DataModified();
        }

        private void sessionNext_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = null;
                    SqlCommand command = new SqlCommand("select * from config where session = " + sessionTextBox, connection);
                    reader = command.ExecuteReader();
                    bool table_status = false;
                    while (reader.Read())
                    {
                        table_status = true; ;
                    }
                    if (table_status == false)
                    {
                        // Start Fees Filling Form

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();

            //Save to configuration File and Database config table


                }
            }

        }

        private void TerminalCellModified(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataModified();
        }

        
    //Session Panel End

    }
}
