using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
        public static class General
        {
            public static class ProcessType
            {
                public static String Login = "1";
                public static String AddCategory = "2";
                public static String UpdateCategory = "3";
                public static String DeleteCategory = "4";
                public static String AddTask = "5";
                public static String UpdateTask = "6";
                public static String DeleteTask = "7";
                public static String AddUser = "8";
                public static String UpdateUser = "9";
                public static String DeleteUser = "10";
                public static String AddReminder = "11";
                public static String UpdateReminder = "12";
                public static String DeleteReminder = "13";
            }
            public static class ProcessName
            {
                public static string Login = "Login";
                public static string AddCategory = "AddCategory";
                public static string UpdateCategory = "UpdateCategory";
                public static string DeleteCategory = "DeleteCategory";
                public static string AddTask = "AddTask";
                public static string UpdateTask = "UpdateTask";
                public static string DeleteTask = "DeleteTask";
                public static String AddUser = "AddUser";
                public static String UpdateUser = "UpdateUser";
                public static String DeleteUser = "UpdateUser";
                public static String AddReminder = "AddReminder";
                public static String UpdateReminder = "UpdateReminder";
                public static String DeleteReminder = "DeleteReminder";
            }
            public static class Messages
            {
                public static int AddSuccess = 1;
                public static int EmptyArea = 2;
                public static int UpdateSuccess = 3;
                public static int ImageMissing = 4;
                public static int ExtentionError = 5;
                public static int GeneralError = 6;

            }

        }
}
