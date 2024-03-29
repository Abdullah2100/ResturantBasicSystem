using Resturant.Globle;
using Resturant.Properties;
using ResturantBuisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Resturant.People
{
    public partial class frmAddOrUpdatePeople : Form
    {
        enum endMode { add, update }
        endMode _mode = endMode.add;
        private clsPersonBuesniss _people;
        private int _peopleID = 0;

        public delegate void onAddComplate(object e, int personID);
        public event onAddComplate onAddComplateEvent;



        public frmAddOrUpdatePeople()
        {
            InitializeComponent();
            _mode = endMode.add;

        }

        public frmAddOrUpdatePeople(int peopleID)
        {
            InitializeComponent();
            _peopleID = peopleID;
            _mode = endMode.update;
        }

        private bool _saveImage()
        {
            bool isSaved = true;

            if (_people.image != pbImage.ImageLocation)
            {
                try
                {

                    clsUtile.deleteImage(_people.image);
                }
                catch (Exception ex)
                {
                    clsEventHandlerBuisness.createEventError(ex.Message);
                }
                string image = pbImage.ImageLocation.ToString();

                if (clsUtile.savePeopleImage(ref image))
                {
                    _people.image = image;
                }
                else
                {
                    return false;
                }

            }




            return isSaved;
        }


        private void _reseatData()
        {
            dateTimePicker1.MaxDate.AddYears(-18);
            dateTimePicker1.MaxDate.AddYears(-50);
            dateTimePicker1.Value = DateTime.Now.AddYears(-18);
            if (_mode == endMode.add)
            {
                btnSave.Text = "حفظ";
                lbFormTitle.Text = "اضافة شخص جديد";
                _people = new clsPersonBuesniss();
            }
            else
            {
                btnSave.Text = "تعديل";
                lbFormTitle.Text = "تعديل الشخص";
            }

            txtFristName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";

        }


        private void _loadData()
        {
            _people = clsPersonBuesniss.findPeopleByID(_peopleID);
            if (_people == null)
            {

                MessageBox.Show("هذا الشخص غير موجود", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtFristName.Text = _people.firstName;
            txtSecondName.Text = _people.secondName;
            txtThirdName.Text = _people.thirdName;
            txtLastName.Text = _people.lastName;
            txtPhone.Text = _people.phone;
            if (_people.image != "")
                pbImage.ImageLocation = _people.image;
            else
                pbImage.Image = Resources.Male_512;
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "requried Feild ");
            }
        }


        private void frmAddOrUpdatePeople_Load(object sender, System.EventArgs e)
        {
            _reseatData();
            if (_mode == endMode.update)
                _loadData();
        }


        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("لا بد من املاء جميع البايات بشكل صحيح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_saveImage())
            {
                MessageBox.Show("هناك خظء في تحميل الصورة", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _people.firstName = txtFristName.Text;
            _people.secondName = txtSecondName.Text;
            _people.thirdName = txtThirdName.Text;
            _people.lastName = txtLastName.Text;
            _people.phone = txtPhone.Text;
            _people.brithday = dateTimePicker1.Value;

            if (_people.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);
                onAddComplateEvent?.Invoke(this, _people.id);

            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_Leave(object sender, System.EventArgs e)
        {
            if (clsPersonBuesniss.isPeopleExistByPhon(txtPhone.Text))
            {
                MessageBox.Show("هذا الرقم تم استخدامه مسبقا", "خظء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Text = "";
            }



        }

        private void pbImage_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = "image Files |*.png;*.jpg;*.jpeg";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                pbImage.Load(imagePath);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
