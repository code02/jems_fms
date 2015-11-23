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
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;

namespace JEMS_Fees_Management_System
{
    public partial class SetUp : Form
    {
        Boolean session_complete = false;                           //All session Fields Complete
        String[] terminals = new String[10] {"","","","","",
                                             "","","","",""};


        String connectionString; 

        public SetUp()
        {
            InitializeComponent();
            ButtonReset();
            dbconnect_next.Enabled = false;
            terminalPanel.Visible = false;
            dbConnectPanel.Visible = true;

            for (int i = 1; i <= 10; i++)
                dataGridView1.Rows.Add("" + i, "");
            dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TerminalCellModified);

            setDatabaseFields();
        }
        
        void setDatabaseFields()
        {
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\config.ini";
            try                                                             // Reading config file for connection string
            {
                if (File.Exists(configPath))
                using (StreamReader sr = File.OpenText(configPath))
                {
                    String readString;
                    if ((readString = sr.ReadLine()) != null)
                    {
                        int i = -1, j = -1;
                        int count = 0;
                        foreach (char c in readString)
                        {
                            if (c == '"' || c == '\'')
                            {
                                if (i == -1) i = count;
                                else
                                {
                                    j = count;
                                    break;
                                }
                            }
                            count++;
                        }
                        if (i < j - 1 && i >= 0)
                        {
                            readString = readString.Substring(i + 1, j - i - 1);
                            GlobalVariables.dbConnectString = readString;
                            int k = 0, field = 0;
                            //Boolean rd = false;
                            count=0;
                            try
                            {
                                foreach (char c in readString)
                                {
                                    if (c == '=') k = count + 1;
                                    if (c == ';')
                                    {
                                        String sub = readString.Substring(k, count - k );
                                        if (field == 0) db_id.Text = sub;
                                        if (field == 1) db_password.Text = sub;
                                        if (field == 2) db_server.Text = sub;
                                        if (field == 4) db_name.Text = sub;
                                        if (field == 5) db_timeout.Value = Int32.Parse(sub);
                                        field++;
                                    }
                                    count++;
                                }
                            }
                            catch (Exception ex)
                            {
                                db_id.Text = "";
                                db_password.Text = "";
                                db_server.Text = "";
                                db_name.Text = "";
                                db_timeout.Value = 5;
                                
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                db_id.Text = "";
                db_password.Text = "";
                db_server.Text = "";
                db_name.Text = "";
                db_timeout.Value = 5;
            }


            String query = "select * from terminal_names;";
            SqlDataReader dr;
            using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    myConnection.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                    {
                        dr = myCommand.ExecuteReader();
                        while(dr.Read())
                        {

                            terminals[Convert.ToInt32(dr["id"]) - 1] = dr["name"].ToString();
                            dataGridView1[1, Convert.ToInt32(dr["id"]) - 1].Value = dr["name"].ToString();
                        }

                        dr.Close();
                    }
                }
                catch
                {

                }
                finally
                {
                    myConnection.Close();
                }
            }




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

        private void dbconnect_next_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = false;
            terminalPanel.Visible = true;
        }


    //Database Connection End


    // Terminal Panel

        
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
                session_complete = false;
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
                        session_complete = false;
                        ButtonReset();
                        return;
                    }
                    else
                    {
                        terminals[i] = text;
                    }
                }
            }
            session_complete = true;
            ButtonReset();
        }
                
        void ButtonReset()
        {
            if (session_complete)
            {
                terminalDone.Enabled = true;
            }
            else
            {
                terminalDone.Enabled = false;
            }
        }

        private void terminalPrevious_Click(object sender, EventArgs e)
        {
            dbConnectPanel.Visible = true;
            terminalPanel.Visible = false;

        }

        private void TerminalCellModification(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DataModified();
        }

        private void terminalDone_Click(object sender, EventArgs e)
        {
            
            //Save to configuration File and Database terminal table
            int dualCheck = 0;
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\config.ini";
            try
            {
                if(File.Exists(configPath))
                {
                    File.Delete(configPath);
                }
                using(FileStream fs = File.Create(configPath))
                {
                    Byte[] data = new UTF8Encoding(true).GetBytes("dbconnect String = \"" + connectionString + "\"");
                    fs.Write(data, 0, data.Length);
                    dualCheck++;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try 
                {
                    connection.Open();
                    SqlCommand dumpTable = new SqlCommand("truncate table terminal_names", connection);
                    dumpTable.ExecuteNonQuery();
                    for(int i=0;i<=9;i++)
                    {
                        if (terminals[i] != null && terminals[i].Length != 0)
                        {
                            String addString = "insert into terminal_names (id,name)" +
                                                   " values(" + (i + 1) + "," + "'" + terminals[i] + "')";
                            SqlCommand addTerminal = new SqlCommand(addString, connection);
                            addTerminal.ExecuteNonQuery();
                        }
                    }
                    dualCheck++;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (dualCheck == 2) 
            { 
                AllSet = true;
                GlobalVariables.dbConnectString = connectionString;
            }

            this.Close();
        }

        private void TerminalCellModified(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataModified();
        }

        
    //Session Panel End

    }
}
