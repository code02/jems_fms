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
        public static int currentSession = 0;
    }

    public static class Classes
    {
        public static String nur = "NUR";
        public static String kg_1 = "KG1";
        public static String kg_2 = "KG2";
        public static String cl_1 = "001";
        public static String cl_2 = "002";
        public static String cl_3 = "003";
        public static String cl_4 = "004";
        public static String cl_5 = "005";
        public static String cl_6 = "006";
        public static String cl_7 = "007";
        public static String cl_8 = "008";
        public static String cl_9 = "009";
        public static String cl_10 = "010";
        public static String cl_11_CM_P = "C1P";    //11 Commerce plain
        public static String cl_11_CM_I = "C1I";    //11 Commerce IP
        public static String cl_11_SC = "S11";      //11 Science
        public static String cl_12_CM_P = "C2P";    //12 Commerce plain
        public static String cl_12_CM_I = "C2I";    //12 Commerce IP
        public static String cl_12_SC = "S12";      //12 Science

        public static String[] classArray = {nur,kg_1,kg_2,cl_1,cl_2,cl_3,cl_4,cl_5,
            cl_6,cl_7,cl_8,cl_9,cl_10,cl_11_CM_P,cl_11_CM_I,cl_11_SC,cl_12_CM_P,cl_12_CM_I,cl_12_SC};
        
        public static String getClassBranch(String cl)
        {
            if (cl == nur) return "Nursery";
            if (cl == kg_1) return "KG-1";
            if (cl == kg_2) return "KG-2";
            if (cl == cl_1) return "Class 1";
            if (cl == cl_2) return "Class 2";
            if (cl == cl_3) return "Class 3";
            if (cl == cl_4) return "Class 4";
            if (cl == cl_5) return "Class 5";
            if (cl == cl_6) return "Class 6";
            if (cl == cl_7) return "Class 7";
            if (cl == cl_8) return "Class 8";
            if (cl == cl_9) return "Class 9";
            if (cl == cl_10) return "Class 10";
            if (cl == cl_11_CM_I)  return "Class 11 Com (IP)";
            if (cl == cl_11_CM_P) return "Class 11 Com (Plain)";
            if (cl == cl_11_SC) return "Class 11 Science";
            if (cl == cl_12_CM_I) return "Class 12 Com (IP)"; 
            if (cl == cl_12_CM_P) return "Class 12 Com (Plain)";
            if (cl == cl_12_SC) return "Class 12 Science";
            return null;
        }

        public static String getClass(String cl)
        {
            if (cl == nur) return "Nursery";
            if (cl == kg_1) return "KG-1";
            if (cl == kg_2) return "KG-2";
            if (cl == cl_1) return "Class 1";
            if (cl == cl_2) return "Class 2";
            if (cl == cl_3) return "Class 3";
            if (cl == cl_4) return "Class 4";
            if (cl == cl_5) return "Class 5";
            if (cl == cl_6) return "Class 6";
            if (cl == cl_7) return "Class 7";
            if (cl == cl_8) return "Class 8";
            if (cl == cl_9) return "Class 9";
            if (cl == cl_10) return "Class 10";
            if (cl == cl_11_CM_I || cl == cl_11_CM_P || cl == cl_11_SC) return "Class 11";
            if (cl == cl_12_CM_I || cl == cl_12_CM_P || cl == cl_12_SC) return "Class 12";
            return null;
        }


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
            public static String caution = "caution";
            public static String st_id_start = "student_id_start";
            public static String prov_id_start = "prov_id_start";
        }

        public static class terminal_names
        { 
            public static String tableName = "terminal_names";
        }

        public static class admission_base_struct
        {
            public static String tableName = "admission_base_struct";
            public static String clss = "class";
            public static String session = "session";
            public static String ad_fees = "admission_fees";
            public static String school_dev = "school_dev";
            public static String furn_fund = "furniture_fund";
            public static String lab_dev = "lab_dev";
            public static String caution = "caution";
            public static String belt_tie = "belt_tie";
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
