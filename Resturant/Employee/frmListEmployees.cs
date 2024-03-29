using ResturantBuisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resturant.Employee
{
    public partial class frmListEmployees : Form
    {
        DataTable dtEmployee = new DataTable();
        public frmListEmployees()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _loadData()
        {
            dtEmployee = clsEmployeeBuiness.getallEmployee();
            dgvEmployee.DataSource = dtEmployee;

            if (dtEmployee.Rows.Count > 0)
            {
                dgvEmployee.Columns[0].HeaderText = "رقم الموظف";
                dgvEmployee.Columns[0].Width = 120;

                dgvEmployee.Columns[1].HeaderText = "رقم الشخص";
                dgvEmployee.Columns[1].Width = 120;

                dgvEmployee.Columns[2].HeaderText = "اسم المستخدم";
                dgvEmployee.Columns[2].Width = 200;

                dgvEmployee.Columns[3].HeaderText = "تاريخ الانشاء";
                dgvEmployee.Columns[3].Width = 120;

                dgvEmployee.Columns[4].HeaderText = "الاسم الكامل";
                dgvEmployee.Columns[4].Width = 250;

                dgvEmployee.Columns[5].HeaderText = "رقم الهاتف";
                dgvEmployee.Columns[5].Width = 120;

                dgvEmployee.Columns[6].HeaderText = "هل هو فعال";
                dgvEmployee.Columns[6].Width = 90;


                lbCounter.Text = dtEmployee.Rows.Count.ToString();
            }
            cbbFilter.SelectedIndex = 0;

        }
        private void frmListEmployees_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void cmsEmployee_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = dtEmployee.Rows.Count > 0;
            int employeeID = !hasData ? 0 : (int)dgvEmployee.CurrentRow.Cells[0].Value;
            bool isActive = !hasData ? false : clsEmployeeBuiness.isEmployeeActive(employeeID);
            cmsEmployee.Items[1].Enabled = hasData;
            cmsEmployee.Items[2].Enabled = hasData;
            cmsEmployee.Items[3].Enabled = hasData;
            cmsEmployee.Items[4].Enabled = hasData;
            cmsEmployee.Items[5].Enabled = (hasData && !isActive);
            cmsEmployee.Items[6].Enabled = (hasData && isActive);
        }

        private void اضافةموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateEmployee form = new frmAddOrUpdateEmployee();
            form.ShowDialog();
            _loadData();

        }

        private void تعديلالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            frmAddOrUpdateEmployee form = new frmAddOrUpdateEmployee(employeeID);
            form.ShowDialog();
            _loadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateEmployee form = new frmAddOrUpdateEmployee();
            form.ShowDialog();
            _loadData();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = " ";
            if (cbbFilter.SelectedIndex == 0)
            {
                txtFilterValue.Enabled = false;
                cbbState.Visible = false;

            }
            else
            {
                txtFilterValue.Enabled = (cbbFilter.SelectedIndex != 7);
                txtFilterValue.Visible = cbbFilter.SelectedIndex != 7;
                cbbState.Visible = cbbFilter.SelectedIndex == 7;
                cbbFilter.Text = "";
            }
        }

        private void cbbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string columnName = "isActive", value = "";
            switch (cbbState.SelectedIndex)
            {
                case 0:
                    {
                        value = "1";
                    }
                    break;
                case 1:
                    {
                        value = "0";

                    }
                    break;
                default:
                    {
                        value = "";
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(value))
                dtEmployee.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, value);
            else dtEmployee.DefaultView.RowFilter = "";
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string columName = "";
            switch (cbbFilter.SelectedIndex)
            {
                case 1:
                    {
                        columName = "employeeID";
                    }
                    break;
                case 2:
                    {
                        columName = "personID";
                    }
                    break;
                case 3:
                    {

                        columName = "userName";
                    }
                    break;

                case 4:
                    {

                        columName = "createdDate";
                    }
                    break;
                case 5:
                    {

                        columName = "fullName";
                    }
                    break;
                case 6:
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
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                dtEmployee.DefaultView.RowFilter = "";
                return;
            }
            if (columName == "employeeID" || columName == "personID" || columName == "phone")
                dtEmployee.DefaultView.RowFilter = string.Format("[{0}] = {1}", columName, txtFilterValue.Text);
            else dtEmployee.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columName, txtFilterValue.Text);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilter.SelectedIndex == 1 || cbbFilter.SelectedIndex == 2 || cbbFilter.SelectedIndex == 6)
            {

                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void حذفالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف هذاالموظف من النظام", "اختيار", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
                if (clsEmployeeBuiness.deleteEmployee(employeeID))
                {
                    MessageBox.Show("تم حذف الموظف بنجاح", "عملية ناجحه", MessageBoxButtons.OK);
                    _loadData();

                }
                else MessageBox.Show("فشل في اكمال العملية", "اختيار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void اظهاربياناتالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            frmShowEmplyeeInfo form = new frmShowEmplyeeInfo(employeeID);
            form.ShowDialog();
            _loadData();
        }

        private void تغيركلمةالسرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            frmUpdatePassword form = new frmUpdatePassword(employeeID);
            form.ShowDialog();
        }

        private void تفعيلالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            if (clsEmployeeBuiness.activateEmployee(employeeID))
            {
                MessageBox.Show("تم تفعيل الموظف بنجاح", "عملية ناجحه", MessageBoxButtons.OK);
                _loadData();

            }
            else MessageBox.Show("فشل في اكمال العملية", "اختيار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ايقافتفعيلالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int employeeID = (int)dgvEmployee.CurrentRow.Cells[0].Value;
            if (clsEmployeeBuiness.deActivateEmployee(employeeID))
            {
                MessageBox.Show("تم الغاء تفعيل  الموظف بنجاح", "عملية ناجحه", MessageBoxButtons.OK);
                _loadData();

            }
            else MessageBox.Show("فشل في اكمال العملية", "اختيار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
