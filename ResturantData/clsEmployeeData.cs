using sportDataLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ResturantData
{
    public class clsEmployeeData
    {
        static string connectionUrl = ConfigurationManager.ConnectionStrings["conncetionUrl"].ConnectionString;

        public static bool findEmployeeByID
            (
            int id,
            ref int personID,
            ref int? addBy,
            ref string userName,
            ref string password,
            ref DateTime createDate,
            ref bool isActive
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select * from Employees where employeeID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["personID"];
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int?)reader["addBy"];
                                createDate = (DateTime)reader["createdDate"];
                                userName = (string)reader["userName"];
                                password = (string)reader["password"];
                                isActive = (bool)reader["isActive"];
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


        public static bool findEmpoyeeByUserPersonID
            (
            ref int id,
             int personID,
             ref int? addBy,
            ref string userName,
            ref string password,
            ref DateTime createdDate,
            ref bool isActive
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select * from Employees where personID = @personID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@personID", personID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int?)reader["addBy"];
                                userName = (string)reader["userName"];
                                createdDate = (DateTime)reader["createdDate"];
                                id = (int)reader["employeeID"];
                                password = (string)reader["password"];
                                isActive = (bool)reader["isActive"];
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


        public static bool findEmpoyeeByUserNameAndPassword
            (
            ref int id,
            ref int personID,
            ref int? addBy,
            string userName,
            string password,
            ref DateTime createdDate,
            ref bool isActive
            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select * from Employees where userName = @userName and password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["personID"];
                                if (reader["addBy"] == DBNull.Value)
                                    addBy = null;
                                else
                                    addBy = (int?)reader["addBy"];
                                createdDate = (DateTime)reader["createdDate"];
                                id = (int)reader["employeeID"];
                                isActive = (bool)reader["isActive"];
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



        public static int createEmployee
            (
            int personID,
            int? addBy,
            string userName,
            string password,
            bool isActive
            )
        {
            int id = 0;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"
                                  update Peoples set isLinked  = 1 where personID = @personID;  
                                  INSERT INTO Employees (personID,addBy,userName,password,isActive)
                                  VALUES(@personID,@addBy,@userName,@password,@isActive);
                                  select SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@personID", personID);
                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@isActive", personID);
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int cachID))
                        {
                            id = cachID;
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


        public static bool updateEmployee
            (
            int? id,
            int personID,
            int? addBy,
            string userName,
            string password,
            bool isActive
            )
        {
            bool isUpdated = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"
                                  Update Employees set personID = @personID
                                  ,addBy = @addBy
                                  ,userName = @userName,
                                   password = @password,
                                   isActive =@isActive
                                   where employeeID = @id;
                                   ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);
                        cmd.Parameters.AddWithValue("@personID", personID);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isUpdated = true;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is : " + ex.Message);
            }
            return isUpdated;

        }


        public static bool deleteEmployee(int id)
        {
            bool isDelete = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @" update Peoples set isLinked  = 0 where personID = (select personID from Employees where  employeeID = @id);  
                                     delete from Employees where employeeID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isDelete = true;
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isDelete;

        }

        public static DataTable getAllEmployee()


        {
            DataTable dtPoepleList = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Employee_view";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dtPoepleList.Load(reader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is :" + ex.Message);
            }
            return dtPoepleList;

        }


        public static bool UpdateEmployeeState(int id, bool isActive)
        {
            bool isAdd = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"update Employees set
                                     isActive = @isActive
                                     where employeeID = @id
";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            isAdd = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is :" + ex.Message);
            }
            return isAdd;

        }


        public static bool isEmployeeActive(int id)
        {
            bool isActive = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select found =1 from Employees where employeeID = @id and isActive =1 ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        Object result = cmd.ExecuteScalar();

                        if (result != null)
                            isActive = true;



                    }

                }
            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is : " + ex.Message);
            }
            return isActive;

        }

        public static bool isEmployeeExistByID(int id)
        {
            bool isExist = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select found =1 from Employee where employeeID = @id ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        Object result = cmd.ExecuteScalar();

                        isExist = (bool)result ? true : false;



                    }

                }
            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is : " + ex.Message);
            }
            return isExist;


        }

        public static bool isEmployeeExistByPersonID(int personID)
        {
            bool isExist = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select found =1 from Employees where personID = @personID ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@personID", personID);

                        Object result = cmd.ExecuteScalar();

                        if (result != null)
                            isExist = true;



                    }

                }
            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is : " + ex.Message);
            }
            return isExist;


        }

        public static bool isEmployeeExistByUserNameD(string userName)
        {
            bool isExist = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {


                    con.Open();
                    string query = @"select found =1 from Employees where userName = @userName ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        Object result = cmd.ExecuteScalar();
                        if (result != null)
                            isExist = true;
                    }

                }
            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);

                Console.WriteLine("Error is : " + ex.Message);
            }
            return isExist;


        }



    }
}
