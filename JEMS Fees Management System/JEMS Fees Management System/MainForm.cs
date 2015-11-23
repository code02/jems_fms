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

        void launchSetup()
        {
            using (SetUp setUp = new SetUp())
            {
                setUp.Owner = this;
                setUp.ShowDialog();
                if (!setUp.AllSet) this.Close();
            }
        }

        private void mainFormLoad(object sender, EventArgs e)
        {

            // Check database Connectivity and database integrity

            string configPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\config.ini";
            try                                                             // Reading config file for connection string
            {
                if (!File.Exists(configPath))
                {
                    DialogResult dr = MessageBox.Show("Database configuration problem encountered. Press OK to setup database configuration. (Contact Admininstrator)"
                                , "Database Connection not Configured", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        launchSetup();
                    else
                        this.Close();
                }
                using (StreamReader sr = File.OpenText(configPath))
                {
                    String readString;
                    if((readString = sr.ReadLine()) != null)
                    {   int i=-1,j=-1;
                        int count = 0;
                        foreach(char c in readString)
                        {
                            if(c == '"' || c == '\'')
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
                                launchSetup();
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
                    launchSetup();
                else
                    this.Close();
            }

            if(!checkConnectivity())
            {
                DialogResult dr = MessageBox.Show("Unable to connect to database. Check if database server is ON. Do you want to re-do Setup? Press 'No' to exit."
                                , "Could not connect to Database", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                    launchSetup();
                else
                    this.Close();
            }
            else
            {
                String query = "select count(*) from terminal_names;";
                int count = 0;
                using(SqlConnection myConnection = new SqlConnection(GlobalVariables.dbConnectString))
                {
                    try
                    {
                        myConnection.Open();
                        using(SqlCommand myCommand = new SqlCommand(query, myConnection))
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
                if(count == 0)
                {
                    DialogResult dr = MessageBox.Show("Setup Fees Terminals. (Contact Admininstrator)"
                                , "Fees Terminals Empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        launchSetup();
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


        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
