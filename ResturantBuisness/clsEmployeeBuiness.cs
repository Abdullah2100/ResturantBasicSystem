using ResturantData;
using System;
using System.Data;

namespace ResturantBuisness
{
    public class clsEmployeeBuiness
    {
        enum enMode { add, update }
        enMode mode { get; set; }
        public int? id { get; set; }
        public int personID { get; set; }
        public int? addBy { get; set; }
        public DateTime createDate { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public clsPersonBuesniss personInfo { get; set; }

        public clsEmployeeBuiness()
        {
            id = null;
            personID = 0;
            addBy = null;
            createDate = DateTime.Now;
            userName = "";
            password = "";
            isActive = true;
            personInfo = null;
            mode = enMode.add;
        }

        private clsEmployeeBuiness(enMode mode, int? id, int personID, int? addBy, string userName, string password, DateTime createDate, bool isActive)
        {
            this.id = id;
            this.personID = personID;
            this.addBy = addBy;
            this.userName = userName;
            this.password = password;
            this.createDate = createDate;
            this.isActive = isActive;
            this.mode = mode;
            personInfo = clsPersonBuesniss.findPeopleByID(personID);

        }

        private bool _add()
        {

            this.id = clsEmployeeData.createEmployee(
                personID,
                addBy,
                userName,
                password,
                isActive
                );
            return (this.id != 0);
        }

        private bool _update()
        {

            return clsEmployeeData.updateEmployee(
                 id,
                 personID,
                 addBy,
                 userName,
                 password,
                 isActive
                 );
        }

        public bool save()
        {


            switch (mode)
            {
                case enMode.add:
                    {
                        if (_add())
                        {
                            mode = enMode.update;
                            return true;
                        }
                        return false;
                    }
                case enMode.update:
                    {
                        if (_update())
                            return true;
                        return false;
                    }
            }
            return false;
        }


        public static clsEmployeeBuiness findEmployeeByID(int id)
        {
            int personID = 0;
            int? addBy = null;
            DateTime createDate = DateTime.Now;
            string userName = "";
            string password = "";
            bool isActive = false;

            if (clsEmployeeData.findEmployeeByID(id, ref personID, ref addBy, ref userName, ref password, ref createDate, ref isActive))
            {
                return new clsEmployeeBuiness(enMode.update, id, personID, addBy, userName, password, createDate, isActive);
            }
            return null;

        }

        public static clsEmployeeBuiness findEmployeeByPersonID(int personID)
        {
            int id = 0;
            int? addBy = null;
            DateTime createDate = DateTime.Now;
            string userName = "";
            string password = "";
            bool isActive = false;

            if (clsEmployeeData.findEmpoyeeByUserPersonID(ref id, personID, ref addBy, ref userName, ref password, ref createDate, ref isActive))
            {
                return new clsEmployeeBuiness(enMode.update, id, personID, addBy, userName, password, createDate, isActive);
            }
            return null;

        }


        public static clsEmployeeBuiness findEmployeeByUserNameAndPassword(string userName, string password)
        {
            int id = 0;
            int? addBy = null;
            DateTime createDate = DateTime.Now;
            int personID = 0;
            bool isActive = false;

            if (clsEmployeeData.findEmpoyeeByUserNameAndPassword(ref id, ref personID, ref addBy, userName, password, ref createDate, ref isActive))
            {
                return new clsEmployeeBuiness(enMode.update, id, personID, addBy, userName, password, createDate, isActive);
            }
            return null;

        }


        public static bool deleteEmployee(int id)
        {
            return clsEmployeeData.deleteEmployee(id);
        }

        public static bool isEmployeeActive(int id)
        {
            return clsEmployeeData.isEmployeeActive(id);
        }



        public static bool activateEmployee(int id)
        {
            return clsEmployeeData.UpdateEmployeeState(id, true);
        }

        public static bool deActivateEmployee(int id)
        {
            return clsEmployeeData.UpdateEmployeeState(id, false);
        }

        public static bool isEmployeeExistByPersonID(int personID)
        {
            return clsEmployeeData.isEmployeeExistByPersonID(personID);
        }

        public static bool isEmployeeExistByID(int ID)
        {
            return clsEmployeeData.isEmployeeExistByID(ID);
        }

        public static bool isEmployeeExistByUserName(string userName)
        {
            return clsEmployeeData.isEmployeeExistByUserNameD(userName);
        }

        public static DataTable getallEmployee()
        {
            return clsEmployeeData.getAllEmployee();
        }

    }
}
