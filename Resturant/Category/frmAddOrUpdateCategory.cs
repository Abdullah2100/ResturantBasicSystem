using Resturant.Globle;
using ResturantBuisness;
using System;
using System.Windows.Forms;

namespace Resturant.Category
{
    public partial class frmAddOrUpdateCategory : Form
    {
        enum enMode { add, update };
        private enMode _mode { get; set; }

        private int _categoryID = 0;

        private clsCategoryBuisness _category;
        public frmAddOrUpdateCategory()
        {
            InitializeComponent();
            _mode = enMode.add;
        }

        public frmAddOrUpdateCategory(int categoryID)
        {
            InitializeComponent();
            _mode = enMode.update;
            _categoryID = categoryID;
        }

        private void _reseateData()
        {
            if (_mode == enMode.add)
            {
                lbHeader.Text = "اضافة صنف جديد";
                btnSave.Text = "حفظ";
                _category = new clsCategoryBuisness();
            }
            else
            {
                lbHeader.Text = "تعديل الصنف";
                btnSave.Text = "تعديل";
            }

            txtName.Text = "";
        }

        private void _loadData()
        {
            _category = clsCategoryBuisness.findCategory(_categoryID);

            if (_category == null)
            {
                MessageBox.Show("هذا الصنف غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = _category.name;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك بعض البيانات المطلوبة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _category.name = txtName.Text;
            _category.addBy = clsEmployee.employee != null ? clsEmployee.employee.id : null;

            if (_category.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);
                btnSave.Text = "تعديل";
            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void frmAddOrUpdateCategory_Load(object sender, EventArgs e)
        {
            _reseateData();
            if (_mode == enMode.update)
                _loadData();
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "هذا الحقل مطلوب");
                return;
            }

            if (txtName.Text.Length < 2)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "هذا الحقل  لابد ا ن يحتوي على الاقل  على حرفين");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
