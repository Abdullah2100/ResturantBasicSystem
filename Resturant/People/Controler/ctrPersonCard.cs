using ResturantBuisness;
using System.Windows.Forms;

namespace Resturant.People.Controler
{
    public partial class ctrPersonCard : UserControl
    {
        private clsPersonBuesniss _person;
        private int _personID;

        public clsPersonBuesniss person
        {
            get { return _person; }
        }
        public int personID
        {
            get { return _personID; }
        }
        public ctrPersonCard()
        {
            InitializeComponent();
        }

        public bool loadData(int personID)
        {
            _person = clsPersonBuesniss.findPeopleByID(personID);
            if (person == null)
            {
                return false;
            }
            lbFullName.Text = _person.fullName;
            lbBrithDay.Text = _person.brithday.ToString();
            lbPhone.Text = _person.phone;
            _personID = _person.id;
            if (!string.IsNullOrEmpty(_person.image))
                pbPersonalImage.ImageLocation = _person.image;

            return true;
        }


    }
}
