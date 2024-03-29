using Resturant.Globle;
using ResturantBuisness;
using System.Data;
using System.Windows.Forms;

namespace Resturant.People
{
    public partial class frmListPeople : Form
    {
        DataTable dtPeopl = new DataTable();
        public frmListPeople()
        {
            InitializeComponent();
        }

        private void _loadData()
        {
            dtPeopl = clsPersonBuesniss.getAllPeople();
            dgvPeople.DataSource = dtPeopl;
            if (dtPeopl.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "رقم الشخص";
                dgvPeople.Columns[0].Width = 120;

                dgvPeople.Columns[1].HeaderText = "اسم الشخص";
                dgvPeople.Columns[1].Width = 250;

                dgvPeople.Columns[2].HeaderText = "تاريخ الميلاد";
                dgvPeople.Columns[2].Width = 100;

                dgvPeople.Columns[3].HeaderText = "رقم الهاتف";
                dgvPeople.Columns[3].Width = 80;

                lbCounter.Text = dtPeopl.Rows.Count.ToString();
            }
            cbbFilter.SelectedIndex = 0;

        }
        private void frmListPeople_Load(object sender, System.EventArgs e)
        {

            _loadData();
        }

        private void dToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddOrUpdatePeople form = new frmAddOrUpdatePeople();
            form.ShowDialog();
            _loadData();
        }

        private void cmsPeople_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = dtPeopl.Rows.Count > 0;

            cmsPeople.Items[1].Enabled = hasData;
            cmsPeople.Items[2].Enabled = hasData;
            cmsPeople.Items[3].Enabled = hasData;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            frmAddOrUpdatePeople form = new frmAddOrUpdatePeople();
            form.ShowDialog();
            _loadData();
        }

        private void تعديلالشخصToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int currentUserID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmAddOrUpdatePeople form = new frmAddOrUpdatePeople(currentUserID);
            form.ShowDialog();
            _loadData();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbbFilter.SelectedIndex == 0)
            {
                txtFilterValue.Enabled = false;
            }
            else
            {
                txtFilterValue.Enabled = true;
            }
        }

        private void txtFilterValue_TextChanged(object sender, System.EventArgs e)
        {
            string columName = "";
            switch (cbbFilter.SelectedIndex)
            {
                case 1:
                    {
                        columName = "personID";
                    }
                    break;
                case 2:
                    {
                        columName = "fullName";
                    }
                    break;
                case 3:
                    {

                        columName = "brithday";
                    }
                    break;
                case 4:
                    {

                        columName = "phone";
                    }
                    break;
                default:
                    {

                        columName = " ";
                    }
                    break;
            }
            if (string.IsNullOrEmpty(columName) || txtFilterValue.Text == "")
            {
                dtPeopl.DefaultView.RowFilter = "";
                return;
            }
            if (columName == "personID" || columName == "phone")
                dtPeopl.DefaultView.RowFilter = string.Format("[{0}] = {1}", columName, txtFilterValue.Text);
            else dtPeopl.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columName, txtFilterValue.Text);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilter.SelectedIndex == 1 || cbbFilter.SelectedIndex == 4)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void حذفالشخصToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            if (MessageBox.Show("هل تريد حذف هذا الشخص من النظام", "اختيار", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int personID = (int)dgvPeople.CurrentRow.Cells[0].Value;
                clsPersonBuesniss _person = clsPersonBuesniss.findPeopleByID(personID);
                if (clsPersonBuesniss.deletePeople(personID))
                {
                    if (string.IsNullOrEmpty(_person.image))
                        clsUtile.deleteImage(_person.image);
                    MessageBox.Show("تم حذف الشخص بنجاح", "عملية ناجحه", MessageBoxButtons.OK);
                    _loadData();

                }
                else MessageBox.Show("يوجد موظف مرتبط بهذا الشخص", "اختيار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void عرضمعلوماتالشخصToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int personID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            frmShowPersonInfo form = new frmShowPersonInfo(personID);
            form.ShowDialog();
        }
    }
}
