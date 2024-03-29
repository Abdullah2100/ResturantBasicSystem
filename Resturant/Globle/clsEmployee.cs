using Microsoft.Win32;
using ResturantBuisness;
using System;
using System.Configuration;

namespace Resturant.Globle
{
    internal class clsEmployee
    {
        public static clsEmployeeBuiness employee;


        private static string _keyPath = ConfigurationManager.ConnectionStrings["rgistaryAppUrl"].ConnectionString;

        public static void saveEmployeeToRegistory(string userNamee, string password)
        {
            string userName = "username";
            string userData = userNamee;
            string passwordName = "password";
            string passwordData = password;
            try
            {

                Microsoft.Win32.Registry.SetValue(_keyPath, userName, userData, RegistryValueKind.String);
                Microsoft.Win32.Registry.SetValue(_keyPath, passwordName, passwordData, RegistryValueKind.String);
            }
            catch (Exception e)
            {
                clsEventHandlerBuisness.createEventError(e.Message);

            }

        }
        public static bool isUserInRegistory(ref string userName, ref string password)
        {
            bool isFound = false;

            try
            {
                userName = Registry.GetValue(_keyPath, "userName", null) as string;
                password = Registry.GetValue(_keyPath, "password", null) as string;
                if (!string.IsNullOrEmpty(userName + password))
                    isFound = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
                //  clsEventHandlerBuisness.addingEvent(e.Message);

            }
            return isFound;
        }
    }
}
