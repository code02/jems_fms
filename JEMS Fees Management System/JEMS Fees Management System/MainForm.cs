using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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


        private void mainFormLoad(object sender, EventArgs e)
        {
            // Check database Connectivity (config file)
            checkConfigFile();
            
            // Check for terminal name entry in database
            checkTerminalEntry();

            //Check Session info
            checkSessionInfo();

           
        }

        void checkConfigFile()
        {
            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\config.ini";
            try                                                             // Reading config file for connection string
            {
                if (!File.Exists(configPath))
                {
                    DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                , "Database Connection not Configured", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        launchSetup(true);
                    else
                        this.Close();
                }
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
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                , "Database Configuration Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            if (dr == System.Windows.Forms.DialogResult.OK)
                                launchSetup(true);
                            else
                                this.Close();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                , "Database Configuration Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.OK)
                    launchSetup(true);
                else
                    this.Close();
            }

        }

        void checkTerminalEntry()
        {
            if (!checkConnectivity())
            {
                DialogResult dr = MessageBox.Show("Unable to connect to database. Check if database server is ON. Do you want to re-do Setup? Press 'No' to exit."
                                , "Could not connect to Database", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                    launchSetup(true);
                else
                    this.Close();
            }
            else
            {
                String query = "select count(*) from " + Table.terminal_names.tableName + ";";
                int count = 0;
                using (SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                        {
                            count = (int)myCommand.ExecuteScalar();
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
                if (count == 0)
                {
                    DialogResult dr = MessageBox.Show("Setup Fees Terminals. (Contact Admininstrator)"
                                , "Fees Terminals Empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        launchSetup(true);
                    else
                        this.Close();
                }
            }

        }

        bool checkConnectivity()
        {

            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {

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

                    connection.Close();
                }
            }

        }

        void checkSessionInfo()
        {
            
            int count =0;
            using (SqlConnection connection = new SqlConnection(GlobalVariables.dbConnectString))
            {
                try
                {
                    connection.Open();
                    String query = "Select count(*) from " + Table.session_info.tableName;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        count = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Some Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Close();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            if (count == 1) return;
            else
            {
                SessionConfig sConfig = new SessionConfig();
                sConfig.cancellable = false;
                sConfig.ShowDialog();
                if (sConfig.killParent) Close();
            }

        }

        void launchSetup(bool killParent)
        {
            using (SetUp setUp = new SetUp())
            {
                setUp.ShowDialog();
                if (!setUp.AllSet && killParent) Close();
            }
        }

        void launchBaseFeesForm(bool killParent)
        {
            using (BaseFeesStructureForm bFSForm = new BaseFeesStructureForm())
            {
                bFSForm.ShowDialog();
                if (!bFSForm.complete && killParent)
                    Close();
            }
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

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launchBaseFeesForm(false);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launchSetup(false);
        }
    }
}
