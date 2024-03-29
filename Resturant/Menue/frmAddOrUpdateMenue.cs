using Resturant.Globle;
using Resturant.Properties;
using ResturantBuisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resturant.Menue
{
    public partial class frmAddOrUpdateMenue : Form
    {
        enum enMode { add, update }
        private enMode _mode { get; set; }

        private clsMenueBuisness _menu;

        private int _menuID = 0;
        public frmAddOrUpdateMenue()
        {
            InitializeComponent();
            _mode = enMode.add;
        }

        public frmAddOrUpdateMenue(int menuID)
        {
            InitializeComponent();
            _menuID = menuID;
            _mode = enMode.update;
        }


        private void _loadCategoryies()
        {

            DataTable dtCategories = new DataTable();
            dtCategories = clsCategoryBuisness.getCategories();
            if (dtCategories.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCategories.Rows)
                {

                    cbbCategory.Items.Add(dr["name"]);

                }

            }

        }

        private bool _saveImage()
        {
            bool isSaved = true;

            if (pbImage.ImageLocation != null && _menu.image != pbImage.ImageLocation)
            {
                try
                {

                    clsUtile.deleteImage(_menu.image);
                }
                catch (Exception ex)
                {
                    clsEventHandlerBuisness.createEventError(ex.Message);
                }
                string image = pbImage.ImageLocation.ToString();

                if (clsUtile.savePeopleImage(ref image, 1))
                {
                    _menu.image = image;
                }
                else
                {
                    return false;
                }

            }




            return isSaved;
        }

        private void _reseateData()
        {
            _loadCategoryies();

            if (_mode == enMode.add)
            {
                lbHeader.Text = "اضافة وجبة جديدة";
                btnSave.Text = "حفظ";
                _menu = new clsMenueBuisness();
            }
            else
            {
                lbHeader.Text = "تعديل بيانات الوجبة";
                btnSave.Text = "تعديل";
            }

            txtName.Text = "";
            txtPrice.Text = "";
            pbImage.Image = Resources.menu_holder_image;

        }

        private void _loadData()
        {
            _menu = clsMenueBuisness.findMenu(_menuID);

            if (_menu == null)
            {
                MessageBox.Show("هذه الوحبة غير موجودة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!string.IsNullOrEmpty(_menu.image))
                pbImage.Load(_menu.image);

            cbbCategory.SelectedIndex = cbbCategory.FindString(clsCategoryBuisness.findCategory(_menu.categoryID).name);
            txtName.Text = _menu.name;
            txtPrice.Text = _menu.price.ToString();


        }


        private void frmAddOrUpdateMenue_Load(object sender, EventArgs e)
        {
            _reseateData();
            if (_mode == enMode.update)
                _loadData();

        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "هذا الحقل مطلوب ");
            }

            if (txtName.Text.Length < 2)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "هذا الحقل لا بد ان يحتوي على الاقل حرفين ");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("هناك بعض البيانات المطلوبة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(cbbCategory.Text))
            {
                errorProvider1.SetError(cbbCategory, "لا بد من اختيار صنف للوجبة");
                return;
            }

            if (!_saveImage())
            {
                MessageBox.Show("هناك خظء في تحميل الصورة", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _menu.categoryID = clsCategoryBuisness.findCategory(cbbCategory.Text).id;

            _menu.price = Convert.ToDouble(txtPrice.Text);
            _menu.name = txtName.Text;
            _menu.addBy = clsEmployee.employee == null ? null : clsEmployee.employee.id;

            if (_menu.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
