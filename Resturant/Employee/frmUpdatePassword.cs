using Resturant.Globle;
using ResturantBuisness;
using System;
using System.Windows.Forms;

namespace Resturant.Employee
{
    public partial class frmUpdatePassword : Form
    {
        private clsEmployeeBuiness _employee { get; set; }
        private int _employeeID { get; set; }
        public frmUpdatePassword(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID;
        }

        private void ctrPersonCard1_Load(object sender, EventArgs e)
        {
            _employee = clsEmployeeBuiness.findEmployeeByID(_employeeID);
            if (_employee == null)
            {

                MessageBox.Show("الموظف غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrPersonCard1.loadData(_employee.personID);

        }

        private void txtCurrentPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "هذا الخانة ضرورية");
                return;
            }

            if (temp.Text.Length < 2)
            {
                errorProvider1.SetError(temp, "لا بد ان تحتوي هذه الخانة على حرفين على الاقل");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك بعض البيانات المطلوبة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "رمز التاكيد لا يطابق كلمة المرور");
            }

            _employee.password = clsUtile.hashPassword(txtNewPassword.Text);

            if (_employee.save())
            {
                MessageBox.Show("تغير كلمة المرور", "ناحح", MessageBoxButtons.OK);
                btnSave.Text = "تعديل";
            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
