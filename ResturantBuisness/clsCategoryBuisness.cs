using ResturantData;
using System;
using System.Data;

namespace ResturantBuisness
{
    public class clsCategoryBuisness
    {
        enum enMode { add, update }
        private enMode _mode = enMode.add;
        public int id { get; set; }
        public int? addBy { get; set; } = null;
        public string name { get; set; }

        public DateTime addDate { get; set; }

        public clsEmployeeBuiness employeeInfo { get; set; }


        public clsCategoryBuisness()
        {

            this.id = 0;
            this.addBy = 0;
            this.name = "";
            this.addDate = DateTime.Now;
            this._mode = enMode.add;
        }

        private clsCategoryBuisness(enMode mode, int id, int? addBy, string name, DateTime addDate)
        {
            this.id = id;
            this.addBy = addBy;
            this.name = name;
            this.addDate = addDate;
            this._mode = mode;
            if (addBy != null)
                this.employeeInfo = clsEmployeeBuiness.findEmployeeByID(addBy ?? 0);
        }

        public static clsCategoryBuisness findCategory(int id)
        {
            int? addBy = null;
            string name = "";
            DateTime addDate = DateTime.Now;

            if (clsCategoryData.findCategory(id, ref addBy, ref name, ref addDate))
            {
                return new clsCategoryBuisness(enMode.update, id, addBy, name, addDate);
            }
            return null;
        }



        public static clsCategoryBuisness findCategory(string name)
        {
            int? addBy = null;
            int id = 0;
            DateTime addDate = DateTime.Now;

            if (clsCategoryData.findCategory(ref id, ref addBy, name, ref addDate))
            {
                return new clsCategoryBuisness(enMode.update, id, addBy, name, addDate);
            }
            return null;
        }

        private bool _addCategory()
        {
            this.id = clsCategoryData.createCategory(addBy, name);
            return (this.id != 0);
        }
        private bool _updateCategory()
        {
            return clsCategoryData.updateCategory(id, addBy, name);
        }

        public bool save()
        {
            switch (_mode)
            {
                case enMode.add:
                    {
                        if (_addCategory())
                        {
                            _mode = enMode.add;
                            return true;
                        }

                        return false;
                    }
                case enMode.update:
                    {
                        if (_updateCategory())
                        {
                            return true;
                        }
                        return false;
                    }
            }

            return false;
        }


        public static DataTable getCategories()
        {
            return clsCategoryData.getCategories();
        }


        public static bool deleteCateogry(int id)
        {
            return clsCategoryData.deleteCategory(id);
        }

        public static bool isCategoriExistByName(string name)
        {
            return clsCategoryData.isCategoryExistByName(name);
        }

    }
}
