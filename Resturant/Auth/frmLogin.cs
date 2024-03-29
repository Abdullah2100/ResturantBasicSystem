using Resturant.Globle;
using ResturantBuisness;
using System;
using System.Windows.Forms;

namespace Resturant
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";
            if (clsEmployee.isUserInRegistory(ref userName, ref password))
            {
                txtPassword.Text = password;
                txtUserName.Text = userName;
                cheIsSaveUser.Checked = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك بعض البيانات المطلوبة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsEmployee.employee = clsEmployeeBuiness.findEmployeeByUserNameAndPassword(txtUserName.Text, clsUtile.hashPassword(txtPassword.Text));

            if (clsEmployee.employee != null)
            {

                if (clsEmployee.employee.isActive)
                {
                    if (cheIsSaveUser.Checked)
                        clsEmployee.saveEmployeeToRegistory(txtUserName.Text, txtPassword.Text);

                    frmMain form = new frmMain(this);

                    this.Hide();
                    form.ShowDialog();


                }
                else MessageBox.Show("المستخدم غير مفعل تواصل مع المدير لتفعيل الحساب", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else MessageBox.Show("لا يوجد مستخدم بهذه البيانات", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text))
            {
                errorProvider1.SetError(temp, "هذه الخانة مطلوبة");
                e.Cancel = true;
            }
        }


    }
}
