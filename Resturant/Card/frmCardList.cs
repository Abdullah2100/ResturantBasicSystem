using ResturantBuisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resturant.Card
{
    public partial class frmCardList : Form
    {

        DataTable dtCardList = new DataTable();
        private clsOrderBuisness _order;
        private readonly object _employee;

        public frmCardList()
        {
            InitializeComponent();
        }


        private void _loadData()
        {
            dtCardList = clsOrderBuisness.getOrders();
            dgvCardList.DataSource = dtCardList;
            if (dtCardList.Rows.Count > 0)
            {

                dgvCardList.Columns[0].HeaderText = "رقم الطلب";

                dgvCardList.Columns[1].HeaderText = "حالة الطلب";

                dgvCardList.Columns[2].HeaderText = "اجمالي السعر";

                dgvCardList.Columns[3].HeaderText = "هل الطلب محلي";
                dgvCardList.Columns[3].Width = 60;


                dgvCardList.Columns[4].HeaderText = "تمت الضافة من قبل";
                dgvCardList.Columns[4].Width = 150;

                dgvCardList.Columns[5].HeaderText = "تاريخ الاضافة";


            }
        }
        private void frmCardList_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";

            if (cbbFilter.SelectedIndex == 0)
            {
                cbbOrderPlace.Visible = false;
                cbbState.Visible = false;
                txtFilterValue.Enabled = false;
            }

            else
            {
                txtFilterValue.Visible = (cbbFilter.SelectedIndex != 2 && cbbFilter.SelectedIndex != 3);
                txtFilterValue.Enabled = (cbbFilter.SelectedIndex != 2 && cbbFilter.SelectedIndex != 3);
                cbbOrderPlace.Visible = (cbbFilter.SelectedIndex == 3);
                cbbState.Visible = (cbbFilter.SelectedIndex == 2);
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                dtCardList.DefaultView.RowFilter = "";
                return;
            }
            dtCardList.DefaultView.RowFilter = string.Format("[{0}] = {1}", "orderID", txtFilterValue.Text);
        }

        private void cbbOrderPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            switch (cbbOrderPlace.SelectedIndex)
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
            }
            if (string.IsNullOrEmpty(value))
            {
                dtCardList.DefaultView.RowFilter = "";
                return;
            }


            dtCardList.DefaultView.RowFilter = string.Format("[{0}] = {1}", "inRestorant", value);
        }

        private void cbbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            switch (cbbState.SelectedIndex)
            {

                case 0:
                    {
                        value = "طلبية ناحجة";
                    }
                    break;
                case 1:
                    {
                        value = "الطلب معلقة";
                    }
                    break;
                case 2:
                    {
                        value = "تم الغاء الطلب";
                    }
                    break;

            }
            if (string.IsNullOrEmpty(value))
            {
                dtCardList.DefaultView.RowFilter = "";
                return;
            }


            dtCardList.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "state", value);
        }

        private void بياناتالطلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderID = (int)dgvCardList.CurrentRow.Cells[0].Value;

            frmShowOrderItem form = new frmShowOrderItem(orderID);
            form.ShowDialog();
        }

        private void اغاءالطلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderID = (int)dgvCardList.CurrentRow.Cells[0].Value;
            _order = clsOrderBuisness.findOrderByID(orderID);

            _order.mode = clsOrderBuisness.enMode.update;
            _order.state = 3;
            if (_order.save())
            {
                MessageBox.Show("تم تغير حالة الطلب بنحاح", "ناحح", MessageBoxButtons.OK);
                _loadData();
            }

            else

            {

                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void حذفالطلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderID = (int)dgvCardList.CurrentRow.Cells[0].Value;
            _order = clsOrderBuisness.findOrderByID(orderID);

            _order.mode = clsOrderBuisness.enMode.update;
            _order.state = 2;

            if (_order.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);
                _loadData();

            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsCart_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = dtCardList.Rows.Count > 0;
            int orderID = (int)dgvCardList.CurrentRow.Cells[0].Value;

            _order = !hasData ? null : clsOrderBuisness.findOrderByID(orderID);

            bool notCencle = hasData && (_order != null && _order.state == 1);
            bool isPause = hasData && (_order != null && _order.state == 2);
            cmsCart.Items[0].Enabled = hasData;
            cmsCart.Items[1].Enabled = (hasData && notCencle);
            cmsCart.Items[2].Enabled = (hasData && notCencle);
            cmsCart.Items[3].Enabled = (hasData && isPause);
        }

        private void اكمالالطلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderID = (int)dgvCardList.CurrentRow.Cells[0].Value;
            _order = clsOrderBuisness.findOrderByID(orderID);

            _order.mode = clsOrderBuisness.enMode.update;
            _order.state = 1;

            if (_order.save())
            {
                MessageBox.Show("تم حفظ العملية بنجاح", "ناحح", MessageBoxButtons.OK);
                _loadData();

            }
            else
            {
                MessageBox.Show("لم تتم العملية بنجاح", "خطء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
