using sportDataLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ResturantData
{
    public class clsCategoryData
    {
        static string connectionUrl = ConfigurationManager.ConnectionStrings["conncetionUrl"].ConnectionString;

        public static bool findCategory
            (
            int id,
            ref int? addBy,
            ref string name,
            ref DateTime addDate
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Categories where categoryID = @id";
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
                                addDate = (DateTime)reader["addDate"];
                                name = (string)reader["name"];
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


        public static bool findCategory
            (
            ref int id,
            ref int? addBy,
            string name,
            ref DateTime addDate
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Categories where name = @name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                id = (int)reader["categoryID"];
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int)reader["addBy"];
                                addDate = (DateTime)reader["addDate"];
                                name = (string)reader["name"];
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





        public static int createCategory
            (
            int? addBy,
            string name
            )
        {
            int id = 0;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"insert into Categories (name ,addBy) values(@name,@addBy);
                                    select  SCOPE_IDENTITY();  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@name", name);

                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);


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

        public static bool updateCategory
            (
            int id,
            int? addBy,
            string name
            )
        {

            bool isUpdate = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"update Categories set name = @name ,addBy = @addBy where categoryID = @id
";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);

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

        public static bool deleteCategory
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
                    string query = @"delete Categories where categoryID = @id";
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

        public static DataTable getCategories()
        {

            bool isUpdate = false;
            DataTable dtCategories = new DataTable();
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from  Categories";
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




        public static bool isCategoryExistByName
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
                    string query = @"select found = 1 from  Categories where name = @name";
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
