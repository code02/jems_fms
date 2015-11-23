using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JEMS_Fees_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static public String connectionString = "user id=sa;" +
                           "password=8349066713;server=DESKTOP-JHNU9A9\\SQLEXPRESS;" + //   DESKTOP-JHNU9A9\SQLEXPRESS
                           "Trusted_Connection=no;" +
                           "database=jems_database_1; " +
                           "connection timeout=5"; 
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
