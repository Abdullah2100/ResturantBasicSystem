using ResturantData;
using System;
using System.Data;

namespace ResturantBuisness
{
    public class clsPersonBuesniss
    {
        public enum enMode { add, update };
        public enMode mode { get; set; }
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public DateTime brithday { get; set; }
        public string image { get; set; }
        public string phone { get; set; }
        public bool isLinked { get; set; }
        public string fullName
        {
            get { return this.firstName + " " + this.secondName + " " + this.thirdName + " " + this.lastName; }
        }

        public clsPersonBuesniss()
        {
            this.mode = enMode.add;
            this.id = 0;
            this.firstName = "";
            this.secondName = "";
            string thirdName = "";
            string lastName = "";
            DateTime brithday = DateTime.Now;
            string image = "";
            string phone = "";
            isLinked = false;
        }

        private clsPersonBuesniss(enMode mode, int id, string firstName, string secondName, string thirdName, string lastName, DateTime brithday, string image, string phone, bool isLinked)
        {
            this.mode = mode;
            this.id = id;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.brithday = brithday;
            this.image = image;
            this.phone = phone;
            this.isLinked = isLinked;
        }

        public static clsPersonBuesniss findPeopleByID(int id)
        {
            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string lastName = "";
            DateTime brithday = DateTime.Now;
            string image = "";
            string phone = " ";
            bool isLinked = false;
            if (clsPersonData.findPeoplesByID(id, ref firstName, ref secondName, ref thirdName, ref lastName, ref brithday, ref image, ref phone, ref isLinked))
            {

                return new clsPersonBuesniss(enMode.update, id, firstName, secondName, thirdName, lastName, brithday, image, phone, isLinked);
            }
            return null;
        }

        public static clsPersonBuesniss findPeopleByFullName(string fullName)
        {
            int id = 0;
            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string lastName = "";
            DateTime brithday = DateTime.Now;
            string image = "";
            string phone = " ";
            bool isLinked = false;

            if (clsPersonData.findPeoplesByFullName(fullName, ref id, ref firstName, ref secondName, ref thirdName, ref lastName, ref brithday, ref image, ref phone, ref isLinked))
            {

                return new clsPersonBuesniss(enMode.update, id, firstName, secondName, thirdName, lastName, brithday, image, phone, isLinked);
            }
            return null;
        }


        public static clsPersonBuesniss findPeopleByPhone(string phone)
        {
            string firstName = "";
            string secondName = "";
            string thirdName = "";
            string lastName = "";
            DateTime brithday = DateTime.Now;
            string image = "";
            int id = 0;
            bool isLinked = false;
            if (clsPersonData.findPeoplesByPhone(ref id, ref firstName, ref secondName, ref thirdName, ref lastName, ref brithday, ref image, phone, ref isLinked))
            {

                return new clsPersonBuesniss(enMode.update, id, firstName, secondName, thirdName, lastName, brithday, image, phone, isLinked);
            }
            return null;
        }
        private bool _add()
        {
            this.id = clsPersonData.createPeoples(
                this.id,
                this.firstName,
                this.secondName,
                this.thirdName,
                this.lastName,
                this.brithday,
                this.image,
                this.phone);
            return (this.id != 0);
        }

        private bool _update()
        {
            return clsPersonData.updatePeoples(
                           this.id,
                           this.firstName,
                           this.secondName,
                           this.thirdName,
                           this.lastName,
                           this.brithday,
                           this.image,
                           this.phone);
        }


        public virtual bool save()
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


        public static DataTable getAllPeople()
        {
            return clsPersonData.getAllPeoples();
        }

        public static bool deletePeople(int id)
        {
            return clsPersonData.deletePoeplByID(id);
        }


        public static bool isPeopleExistByPhon(string pheon)
        {
            return clsPersonData.isPersonExistByPhone(pheon);
        }
    }
}

