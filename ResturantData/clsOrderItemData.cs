using sportDataLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ResturantData
{

    public class clsOrderItemData
    {

        static string connectionUrl = ConfigurationManager.ConnectionStrings["conncetionUrl"].ConnectionString;

        public static int createOrderItem
            (
            decimal quantity,
            int orderID,
            int menuID
            )
        {
            int id = 0;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"insert into OrderItmes (quantity,orderID,menuID)
                                       values(@quantity,@orderID,@menuID);
                                    select  SCOPE_IDENTITY();  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {



                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@orderID", orderID);
                        cmd.Parameters.AddWithValue("@menuID", menuID);


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


        public static bool updateOrderItemQuantity
         (
         int id,
         decimal quantity
         )
        {

            bool isUpdate = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"update OrderItmes set quantity = @quantity where orderItmeID = @id;    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {


                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

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




        public static bool deleteOrderItem
            (
            int orderID
            )

        {

            bool isDelete = false;
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"  delete OrderItmes   where orderID = @orderID  ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {


                        cmd.Parameters.AddWithValue("@orderID", orderID);

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



        public static DataTable geOrderItem(int orderID)
        {

            DataTable dtOrders = new DataTable();
            try
            {


                using (SqlConnection con = new SqlConnection(connectionUrl))
                {
                    con.Open();
                    string query = @"select m.name,oi.quantity,(oi.quantity*m.price) as totalPrice,
                                     c.name as categoryName from Orders o
                                     inner join OrderItmes oi on o.orderID = oi.orderID
                                     inner join Menus m on oi.menuID = m.menuID
                                     inner join Categories c on c.categoryID = m.categoryID where o.orderID = @orderID ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@orderID", orderID);




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
