using ResturantData;
using System;
using System.Data;

namespace ResturantBuisness
{
    public class clsMenueBuisness
    {
        enum enMode { add, update }
        private enMode _mode = enMode.add;
        public int id { get; set; }
        public int? addBy { get; set; } = null;
        public int categoryID { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public DateTime addDate { get; set; }
        public double price { get; set; }

        public clsCategoryBuisness categoryInfo { get; set; }

        public clsEmployeeBuiness employeeInfo { get; set; }


        public clsMenueBuisness()
        {

            this.id = 0;
            this.addBy = 0;
            this.name = "";
            this.addDate = DateTime.Now;
            this.price = 0;
            this.categoryID = 0;
            this.image = "";
            this._mode = enMode.add;
        }

        private clsMenueBuisness(enMode mode, int id, int? addBy, int categoryID, string name, string image, DateTime addDate, double price)
        {
            this.id = id;
            this.addBy = addBy;
            this.name = name;
            this.addDate = addDate;
            this._mode = mode;
            this.categoryID = categoryID;
            this.price = price;
            this.image = image;
            categoryInfo = clsCategoryBuisness.findCategory(categoryID);
            if (addBy != null)
                this.employeeInfo = clsEmployeeBuiness.findEmployeeByID(addBy ?? 0);
        }

        public static clsMenueBuisness findMenu(int id)
        {
            int? addBy = null;
            string name = "";
            DateTime addDate = DateTime.Now;
            string image = "";
            double price = 0;
            int categoryID = 0;

            if (clsMenusData.findMenu(id, ref addBy, ref categoryID, ref image, ref name, ref addDate, ref price))
            {
                return new clsMenueBuisness(enMode.update, id, addBy, categoryID, name, image, addDate, price);
            }
            return null;
        }




        public static clsMenueBuisness findMenu(string name)
        {
            int? addBy = null;
            int id = 0;
            DateTime addDate = DateTime.Now;
            string image = "";
            double price = 0;
            int categoryID = 0;

            if (clsMenusData.findMenu(ref id, ref addBy, ref categoryID, ref image, name, ref addDate, ref price))
            {
                return new clsMenueBuisness(enMode.update, id, addBy, categoryID, name, image, addDate, price);
            }
            return null;
        }

        private bool _addMenu()
        {
            this.id = clsMenusData.createMenu(addBy, categoryID, image, name, price);
            return (this.id != 0);
        }
        private bool _updateMenu()
        {
            return clsMenusData.updateMenu(id, addBy, categoryID, image, name, price); ;
        }

        public bool save()
        {
            switch (_mode)
            {
                case enMode.add:
                    {
                        if (_addMenu())
                        {
                            _mode = enMode.add;
                            return true;
                        }

                        return false;
                    }
                case enMode.update:
                    {
                        if (_updateMenu())
                        {
                            return true;
                        }
                        return false;
                    }
            }

            return false;
        }


        public static DataTable getMenu()
        {
            return clsMenusData.getMenus();
        }


        public static bool deleteMenu(int id)
        {
            return clsMenusData.deleteMenu(id);
        }

        public static bool isCategoriExistByName(string name)
        {
            return clsMenusData.isMenuExistByName(name);
        }

    }
}
