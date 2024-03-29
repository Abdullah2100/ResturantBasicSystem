using ResturantData;
using System.Data;

namespace ResturantBuisness
{
    public class clsOrderItemBuisness
    {
        public enum enMode { add, update }
        public enMode mode { get; set; }
        public int id { get; set; }
        public decimal quantity { get; set; }
        public int menuID { get; set; }
        public int orderID { get; set; }
        public clsOrderItemBuisness()
        {
            id = 0;
            quantity = 0;
            menuID = 2;
            orderID = 0;
            mode = enMode.add;
        }


        private clsOrderItemBuisness(enMode mode, int id, decimal quantity, int menuID, int orderID)
        {
            this.id = id;
            this.quantity = quantity;
            this.menuID = menuID;
            this.orderID = orderID;
            this.mode = mode;
        }

        private bool _addOrderItem()
        {
            this.id = clsOrderItemData.createOrderItem(quantity, orderID, menuID);
            return (this.id != 0);
        }

        private bool _updateOrderItmeQuantity()
        {
            return clsOrderItemData.updateOrderItemQuantity(this.id, this.quantity);
        }

        public bool save()
        {
            switch (this.mode)
            {
                case enMode.add:
                    {
                        if (_addOrderItem())
                        {
                            //        _mode = enMode.update;
                            return true;
                        }
                    }
                    break;
                case enMode.update:
                    {
                        if (_updateOrderItmeQuantity())
                        {
                            return true;
                        }

                    }
                    break;
            }
            return false;
        }

        public static bool deleteOrderItem(int orderID)
        {
            return clsOrderItemData.deleteOrderItem(orderID);
        }


        public static DataTable getOrders(int orderID)
        {
            return clsOrderItemData.geOrderItem(orderID);
        }

    }
}
