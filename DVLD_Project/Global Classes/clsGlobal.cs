using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using Microsoft.Win32;

namespace DVLD_Project.Global_Classes
{
    internal static class clsGlobal
    {
        private const string RegistryKeyPath = @"HKEY_CURRENT_USER\SOFTWARE\LoginInfo";

        private const int PasswordEncryptKey = 22;

        public static clsUser CurrentUser;

        private static string EncryptPassword(string Password)
        {
            string EncryptPassword = "";

            for (int i =0; i < Password.Length; i++)
            {
                EncryptPassword += (char)(Password[i] + PasswordEncryptKey);
            }

            return EncryptPassword;
        }

        private static string DecryptPassword(string Password)
        {
            string DecryptPassword = "";

            for (int i = 0; i < Password.Length; i++)
            {
                DecryptPassword += (char)(Password[i] - PasswordEncryptKey);
            }

            return DecryptPassword;
        }

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string NewPassword = EncryptPassword(Password);
            try
            {
                Registry.SetValue(RegistryKeyPath, "Username", Username);
                Registry.SetValue(RegistryKeyPath, "Password", NewPassword);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            //return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                Username = Registry.GetValue(RegistryKeyPath, "Username", null) as string;
                string EncryptPassword = Registry.GetValue(RegistryKeyPath, "Password", null) as string;

                if (Username == null || Password == null) return false;
                {
                    Password = DecryptPassword(EncryptPassword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

            return true;
        }

    }
}
