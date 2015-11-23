using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEMS_Fees_Management_System
{
    public static class GlobalVariables
    {
        public static String dbConnectString;
    
    }

    public static class Receipt
    {
        public static String admission = "AD";
        public static String provisional = "PR";
        public static String adForm = "AF";
        public static String annual = "AN";
        public static String monthly = "MT";
        public static String other = "OT";


    }
    public static class Table
    {
        public static class session_info
        {

            public static String tableName = "session_info";
            public static String session = "session";
            public static String admission_rec_start = "admission_receipt_start";
            public static String prov_rec_start = "provisional_receipt_start";
            public static String ad_form_rec_start = "ad_form_receipt_start";
            public static String annual_rec_start = "annual_receipt_start";
            public static String monthly_rec_start = "monthly_receipt_start";
            public static String other_rec_start = "other_receipt_start";
            public static String belt_tie = "belt_tie";
            public static String warn_fees_date = "warn_fees_date";
            public static String default_warn_fees_date = "default_warn_fees_date";
            public static String warn_fees = "warn_fees";
            public static String late_fees = "late_fees";
            public static String dup_diary = "dup_diary";
            public static String dup_rc = "dup_report";
            public static String dup_tc = "dup_tc";
            public static String ad_form = "ad_form";
        }
        public static class terminal_names
        { 
            public static String tableName = "terminal_names";
        }
    }
    class CommonMethods
    {

        static public Boolean isNumeric(String str, int size)
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

        static public Boolean valueBetween(String str,int min,int max)
        {
            if (!isNumeric(str, 0)) return false;
            else
            {
               
                    int val = Int32.Parse(str);
                    if (val < min || val > max)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
             }
        }

    }
}
