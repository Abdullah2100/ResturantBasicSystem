using sportDataLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ResturantData
{
    public class clsOrderData
    {
        static string connectionUrl = ConfigurationManager.ConnectionStrings["conncetionUrl"].ConnectionString;





        public static bool findOrderByID
                (
            int id,
            ref int? addBy,
            ref decimal state,
            ref double totalPrice,
            ref DateTime addDate,
            ref bool inResturant
                )
        {

            bool isFound = false;

            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from Orders where orderID = @id ";
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

                                state = Convert.ToDecimal(reader["state"]);
                                totalPrice = (double)reader["totalPrice"];
                                addDate = (DateTime)reader["addDate"];
                                inResturant = (bool)reader["inRestorant"];


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











        public static int createOrder
            (
            int? addBy,
            double totalPrice,
            bool inRestorant
            )
        {
            int id = 0;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"INSERT INTO Orders(totalPrice,inRestorant,addBy)
                                   VALUES (@totalPrice,@inRestorant,@addBy);
                                    select  SCOPE_IDENTITY();  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {


                        if (addBy == null)
                            cmd.Parameters.AddWithValue("@addBy", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@addBy", addBy);


                        cmd.Parameters.AddWithValue("@totalPrice", totalPrice);

                        cmd.Parameters.AddWithValue("@inRestorant", inRestorant);


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





        public static bool updateOrderState
            (
            int id,
            decimal state,
            double totlaPrice
            )
        {

            bool isUpdate = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"update Orders set state = @state ,totalPrice = @totalPrice where orderID = @id  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {


                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@state", state);
                        cmd.Parameters.AddWithValue("@totalPrice", totlaPrice);


                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            isUpdate = true; ;
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

        public static bool deleteOrderState
            (
            int id
            )
        {

            bool isDelete = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"delete Orders  where orderID = @id  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {


                        cmd.Parameters.AddWithValue("@id", id);


                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            isDelete = true; ;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsAppEventHandler.createNewEventLog(ex.Message);
                Console.WriteLine("Error is : " + ex.Message);
            }
            return isDelete;

        }



        public static DataTable geOrders()
        {

            DataTable dtOrders = new DataTable();
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select * from  order_view order by orderID desc";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {



                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtOrders.Load(reader);
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
            return dtOrders;

        }




    }
}
