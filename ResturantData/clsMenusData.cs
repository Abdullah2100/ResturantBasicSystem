using sportDataLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ResturantData
{
    public class clsMenusData
    {
        static string connectionUrl = ConfigurationManager.ConnectionStrings["conncetionUrl"].ConnectionString;

        public static bool findMenu
            (
            int id,
            ref int? addBy,
            ref int categoryID,
            ref string image,
            ref string name,
            ref DateTime addDate,
            ref double price
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Menus where menuID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int)reader["addBy"];

                                categoryID = (int)reader["categoryID"];

                                if (reader["image"] == DBNull.Value)
                                    image = "";
                                else
                                    image = (string)reader["image"];
                                addDate = (DateTime)reader["addDate"];
                                name = (string)reader["name"];
                                price = (double)reader["price"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isFound;

        }





        public static bool findMenu
            (
            ref int id,
            ref int? addBy,
            ref int categoryID,
            ref string image,
             string name,
            ref DateTime addDate,
            ref double price
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Menus where name = @name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                id = (int)reader["menuID"];
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int)reader["addBy"];

                                categoryID = (int)reader["categoryID"];

                                if (reader["image"] == DBNull.Value)
                                    image = "";
                                else
                                    image = (string)reader["image"];
                                addDate = (DateTime)reader["addDate"];
                                name = (string)reader["name"];
                                price = (double)reader["price"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isFound;

        }


        public static int createMenu
            (
            int? addBy,
            int categoryID,
            string image,
            string name,
            double price
            )
        {
            int id = 0;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"insert into Menus (name,categoryID,image,addBy ,price) values (@name,@categoryID,@image,@addBy,@price)
                                    select  SCOPE_IDENTITY();  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@name", name);

                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);

                        if (string.IsNullOrEmpty(image))
                            cmd.Parameters.AddWithValue("@image", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@image", image);

                        cmd.Parameters.AddWithValue("@categoryID", categoryID);

                        cmd.Parameters.AddWithValue("@price", price);


                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int resultData))
                        {
                            id = resultData;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return id;

        }

        public static bool updateMenu
            (
            int id,
            int? addBy,
            int? categoryID,
            string image,
            string name,
            double price
            )
        {

            bool isUpdate = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"update Menus set name = @name , categoryID = @categoryID, image =@image , addBy = @addBy , price=@price   where menuID = @id ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.Parameters.AddWithValue("@name", name);

                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);

                        if (string.IsNullOrEmpty(image))
                            cmd.Parameters.AddWithValue("@image", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@image", image);

                        cmd.Parameters.AddWithValue("@categoryID", categoryID);

                        cmd.Parameters.AddWithValue("@price", price);


                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isUpdate = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isUpdate;

        }

        public static bool deleteMenu
            (
            int id
            )
        {

            bool isUpdate = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"delete Menus where menuID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isUpdate = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isUpdate;

        }

        public static DataTable getMenus()
        {

            bool isUpdate = false;
            DataTable dtCategories = new DataTable();
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select  menuID, name, price from Menus ;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtCategories.Load(reader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return dtCategories;

        }




        public static bool isMenuExistByName
            (
            string name
            )
        {

            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select found = 1 from  Menus where name = @name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isFound;

        }


    }
}
