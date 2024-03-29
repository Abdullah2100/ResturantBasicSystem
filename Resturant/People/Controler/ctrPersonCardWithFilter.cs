using ResturantBuisness;
using System;
using System.Windows.Forms;

namespace Resturant.People.Controler
{
    public partial class ctrPersonCardWithFilter : UserControl
    {
        public event Action<int> onPersonSearchFound;

        public event Action<int> onAddComplate;

        protected void selectPersonResult(int personID)
        {
            Action<int> onPersonFound = onPersonSearchFound;
            if (onPersonFound != null)
                onPersonFound(personID);
        }

        public bool filterState = false;
        private bool _filterState
        {
            set { gbFilter.Enabled = filterState; }
            get { return filterState; }
        }

        protected void complateAdd(int personID)
        {
            Action<int> onComplateAdding = onAddComplate;
            if (onComplateAdding != null)
                onComplateAdding(personID);
        }

        private void addcomplateFunction(object sender, int personID)
        {
            txtSearch.Text = personID.ToString();
            cbbFilter.SelectedIndex = 0;
            onAddComplate(personID);
        }

        public clsPersonBuesniss person
        {
            get { return ctrPersonCard1.person; }
        }


        public int personID
        {
            get { return ctrPersonCard1.personID; }
        }
        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }


        public void textSearchFocuse()
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        public void loadData(int personID)
        {

            txtSearch.Text = personID.ToString();
            ctrPersonCard1.loadData(personID);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ctrPersonCard1.loadData(Convert.ToInt32(txtSearch.Text)))
            {
                onPersonSearchFound(personID);
                txtSearch.Text = personID.ToString();
            }

            else
            {
                MessageBox.Show("لا يوجد شخص بهذه البيانات", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSearchFocuse();
                return;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePeople form = new frmAddOrUpdatePeople();
            form.onAddComplateEvent += addcomplateFunction;
            form.ShowDialog();

        }

        private void ctrPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            textSearchFocuse();
            cbbFilter.SelectedIndex = 0;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
