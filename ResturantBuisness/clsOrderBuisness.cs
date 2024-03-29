using ResturantData;
using System;
using System.Data;

namespace ResturantBuisness
{
    public class clsOrderBuisness
    {
        public enum enMode { add, update }
        public enMode mode { get; set; }
        public int id { get; set; }
        public int? addBy { get; set; }
        public decimal state { get; set; }
        public double totalPrice { get; set; }
        public DateTime addDate { get; set; }
        public bool inResturant { get; set; }

        public clsOrderBuisness()
        {
            id = 0;
            addBy = null;
            state = 2;
            totalPrice = 0;
            addDate = DateTime.Now;
            inResturant = true;
            mode = enMode.add;
        }


        private clsOrderBuisness(enMode mode, int id, int? addBy, decimal state, double totalPrice, DateTime addDate, bool inResturant)
        {
            this.id = id;
            this.addBy = addBy;
            this.state = state;
            this.totalPrice = totalPrice;
            this.addDate = addDate;
            this.mode = mode;
        }


        public static clsOrderBuisness findOrderByID(int id)
        {
            int? addBy = null;
            decimal state = 0;
            double totalPrice = 0;
            DateTime addDate = DateTime.Now;
            bool inResturant = false;
            if (clsOrderData.findOrderByID(id, ref addBy, ref state, ref totalPrice, ref addDate, ref inResturant))
            {

                return new clsOrderBuisness(enMode.update, id, addBy, state, totalPrice, addDate, inResturant);
            }
            return null;
        }

        private bool _addOrder()
        {
            this.id = clsOrderData.createOrder(addBy, totalPrice, inResturant);
            return (this.id != 0);
        }

        bool _updateOrderState()
        {
            return clsOrderData.updateOrderState(this.id, this.state, this.totalPrice);
        }

        public bool save()
        {
            switch (this.mode)
            {
                case enMode.add:
                    {
                        if (_addOrder())
                        {
                            //  mode = enMode.update;
                            return true;
                        }
                    }
                    break;
                case enMode.update:
                    {
                        if (_updateOrderState())
                        {
                            return true;
                        }

                    }
                    break;
            }
            return false;
        }

        public static bool deleteOrder(int id)
        {
            return clsOrderData.deleteOrderState(id);
        }


        public static DataTable getOrders()
        {
            return clsOrderData.geOrders();
        }

    }
}
