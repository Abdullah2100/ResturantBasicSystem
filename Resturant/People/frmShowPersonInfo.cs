using ResturantBuisness;
using System;
using System.Windows.Forms;

namespace Resturant.People
{
    public partial class frmShowPersonInfo : Form
    {
        clsPersonBuesniss _person;

        public frmShowPersonInfo(int personId)
        {
            InitializeComponent();
            _loadData(personId);

        }

        private void _loadData(int personID)
        {
            _person = clsPersonBuesniss.findPeopleByID(personID);

            if (_person == null)
            {
                MessageBox.Show("هذا الشخص غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrUserInfo1.loadData(_person.id);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrUserInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
