using Resturant.Globle;
using ResturantBuisness;
using System.ComponentModel;
using System.Windows.Forms;

namespace Resturant.Employee
{
    public partial class frmAddOrUpdateEmployee : Form
    {

        enum enMode { add, update };
        private enMode _mode { get; set; }

        private clsEmployeeBuiness _employee { get; set; }
        private int _employeeID { get; set; }
        public frmAddOrUpdateEmployee()
        {
            InitializeComponent();
            _mode = enMode.add;
        }

        public frmAddOrUpdateEmployee(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID;
            _mode = enMode.update;
        }

        private void _reseateData()
        {

            if (_mode == enMode.add)
            {
                _employee = new clsEmployeeBuiness();

                btnSave.Text = "حفظ";
                lbFormTitle.Text = "اضافة موظف جديد";
            }
            else
            {
                btnSave.Text = "تعديل";
                lbFormTitle.Text = "تعديل بيانات الموظف";
            }


            txtUserName.Text = "";
            txtPassword.Text = "";
            chcIsActive.Checked = true;
            ctrPersonCardWithFilter2.textSearchFocuse();


        }

        private void _loadData()
        {
            _employee = clsEmployeeBuiness.findEmployeeByID(_employeeID);
            if (_employee == null)
            {

                MessageBox.Show("الموظف غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtPassword.Enabled = false;
            txtUserName.Text = _employee.userName;
            chcIsActive.Checked = _employee.isActive;
            ctrPersonCardWithFilter2.filterState = false;
            ctrPersonCardWithFilter2.loadData(_employee.personID);
            btnSave.Enabled = true;

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "هذه الخانة مطلوبة");
                return;
            }

            if (temp.Text.Length < 2)
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "هذه الخانة لا بد ان يكون فيها على الاقل حرفين");

            }
        }


        private void frmAddOrUpdateEmployee_Load(object sender, System.EventArgs e)
        {
            _reseateData();
            if (_mode == enMode.update)
                _loadData();

        }

        private void txtUserName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void ctrPersonCardWithFilter2_onAddComplate(int obj)
        {
            ctrPersonCardWithFilter2.filterState = false;
            ctrPersonCardWithFilter2.loadData(obj);
            btnSave.Enabled = false;


        }

        private void ctrPersonCardWithFilter2_onPersonSearchFound(int obj)
        {

            ctrPersonCardWithFilter2.loadData(obj);

            if (clsEmployeeBuiness.isEmployeeExistByPersonID(obj))
            {
                MessageBox.Show("لقد تم ربط هذا الشخص مع موظف", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (_mode == enMode.add && !this.ValidateChildren())
            {
                MessageBox.Show("هناك بعض البيانات المطلوبة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _employee.personID = ctrPersonCardWithFilter2.personID;
            _employee.userName = txtUserName.Text;
            _employee.password = clsUtile.hashPassword(txtPassword.Text);
            _employee.isActive = chcIsActive.Checked ? true : false;

            if (_employee.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);
                btnSave.Text = "تعديل";
            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_Leave(object sender, System.EventArgs e)
        {
            if (clsEmployeeBuiness.isEmployeeExistByUserName(txtUserName.Text))
            {
                MessageBox.Show("لقد تم استخدام هذا الاسم ", "فشل", MessageBoxButtons.OK);
                txtUserName.Text = "";

            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
