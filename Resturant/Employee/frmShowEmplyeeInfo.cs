using ResturantBuisness;
using System.Windows.Forms;

namespace Resturant.Employee
{
    public partial class frmShowEmplyeeInfo : Form
    {
        public frmShowEmplyeeInfo(int employeeID)
        {
            InitializeComponent();
            _loadData(employeeID);
        }


        private void _loadData(int employeeID)
        {
            clsEmployeeBuiness _employee = clsEmployeeBuiness.findEmployeeByID(employeeID);
            if (_employee == null)
            {
                MessageBox.Show("الموظف غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrPersonCard1.loadData(_employee.personID);
            lbIsActivate.Text = _employee.isActive ? "نعم" : "لا";
            lbFullName.Text = _employee.userName;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
