using ResturantBuisness;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Resturant.Globle
{
    public class clsUtile
    {

        public static string[] imagePaths = { @"C:\\Users\\ali77\\OneDrive\\Desktop\\userResturantImages\\", "C:\\Users\\ali77\\OneDrive\\Desktop\\muneImage\\" };



        private static string _guid()
        {
            Guid value = Guid.NewGuid();
            return value.ToString();
        }

        private static string _replaceImageWithNewName(string image)
        {
            FileInfo info = new FileInfo(image);
            return _guid() + "." + info.Extension;
        }

        public static bool savePeopleImage(ref string image, int pathIndex = 0)
        {

            string speicalName = Guid.NewGuid().ToString();

            string fullName = imagePaths[pathIndex] + _replaceImageWithNewName(image);
            try
            {
                File.Copy(image, fullName, true);
                image = fullName;
                return true;
            }
            catch (Exception ex)
            {
                clsEventHandlerBuisness.createEventError(ex.Message);
                return false;
            }
        }

        public static bool deleteImage(string image)
        {
            try
            {
                File.Delete(image);
                return true;
            }
            catch (Exception ex)
            {
                clsEventHandlerBuisness.createEventError(ex.Message);
                return false;
            }
        }


        public static string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }

        }

        public static bool compareHash(string password, string decodedPassword)
        {
            return hashPassword(password).Equals(decodedPassword);
        }


    }
}
