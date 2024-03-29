using Resturant.Card;
using Resturant.Category;
using Resturant.Employee;
using Resturant.Globle;
using Resturant.Menue;
using Resturant.People;
using ResturantBuisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resturant
{
    public partial class frmMain : Form
    {
        private frmLogin _loginHolder;
        public frmMain(frmLogin loginHolder)
        {
            InitializeComponent();
            this._loginHolder = loginHolder;
        }

        double sum = 0;
        private DataTable _dtCategory = new DataTable();
        private DataTable _dtItems = new DataTable();

        private DataTable _dtCart = new DataTable();




        private void _loadCategories()
        {
            _dtCategory = clsCategoryBuisness.getCategories();
            dgvCategory.DataSource = _dtCategory;

            dgvCategory.Columns[0].HeaderText = "رقم الصنف";
            dgvCategory.Columns[1].HeaderText = "اسم الصنف";
            dgvCategory.Columns[2].HeaderText = "تاريخ الاضافة";
            dgvCategory.Columns[3].HeaderText = "تمت الاضافة بواسطة";
            dgvCategory.Columns[3].Width = 150;
        }


        private void _loadItems()
        {
            _dtItems = clsMenueBuisness.getMenu();
            dgvItem.DataSource = _dtItems;
            if (_dtItems.Rows.Count > 0)
            {

                dgvItem.Columns[0].HeaderText = "رقم الوجبة";
                dgvItem.Columns[1].HeaderText = "اسم الوجبة";
                dgvItem.Columns[2].HeaderText = "سعر الوجبة";
            }

        }


        private void _loadCart()
        {
            dgvCart.DataSource = _dtCart;

            if (_dtCart.Rows.Count > 0)
            {
                dgvCart.Columns[0].HeaderText = "المنتج";
                dgvCart.Columns[1].HeaderText = "الكمية";
                dgvCart.Columns[2].HeaderText = "سعر الوحدة";

            }

        }


        private void _addColumnToCart()
        {
            DataColumn dcColumn1 = new DataColumn();
            dcColumn1.DataType = typeof(string);
            dcColumn1.ColumnName = "item";
            _dtCart.Columns.Add(dcColumn1);

            DataColumn dcColumn2 = new DataColumn();
            dcColumn2.DataType = typeof(int);
            dcColumn2.DefaultValue = 1;
            dcColumn2.ColumnName = "count";
            _dtCart.Columns.Add(dcColumn2);

            DataColumn dcColumn3 = new DataColumn();
            dcColumn3.DataType = typeof(double);
            dcColumn3.ColumnName = "price";
            _dtCart.Columns.Add(dcColumn3);
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople form = new frmListPeople();
            form.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEmployees form = new frmListEmployees();
            form.ShowDialog();
        }

        private void المعلوماتالشخصيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowEmplyeeInfo form = new frmShowEmplyeeInfo(clsEmployee.employee.id ?? 0);
            form.ShowDialog();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsEmployee.employee == null)
            {
                المعلوماتالشخصيةToolStripMenuItem.Enabled = false;
                تغيركلمةالمرورToolStripMenuItem.Enabled = false;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _loadCategories();
            _loadItems();
            _addColumnToCart();
        }

        private void cmsCategory_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = _dtCategory.Rows.Count > 0;
            cmsCategory.Items[1].Enabled = hasData;
            cmsCategory.Items[2].Enabled = hasData;
        }

        private void cmsItems_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = _dtItems.Rows.Count > 0;
            cmsItems.Items[1].Enabled = hasData;
            cmsItems.Items[2].Enabled = hasData;
        }

        private void cmsCart_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasData = _dtCart.Rows.Count > 0;
            cmsCart.Items[0].Enabled = hasData;
            cmsCart.Items[1].Enabled = hasData;
        }

        private void dToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateCategory form = new frmAddOrUpdateCategory();
            form.ShowDialog();
            _loadCategories();
        }

        private void dToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            int categoryID = (int)dgvCategory.CurrentRow.Cells[0].Value;
            frmAddOrUpdateCategory form = new frmAddOrUpdateCategory(categoryID);
            form.ShowDialog();
            _loadCategories();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateMenue form = new frmAddOrUpdateMenue();
            form.ShowDialog();
            _loadItems();
        }

        private void تعديلبياناتالطبقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int menuID = (int)dgvItem.CurrentRow.Cells[0].Value;

            frmAddOrUpdateMenue form = new frmAddOrUpdateMenue(menuID);
            form.ShowDialog();
            _loadItems();
        }

        private void _addToCArdFunctionlity()
        {
            int menuID = (int)dgvItem.CurrentRow.Cells[0].Value;
            clsMenueBuisness _menu = clsMenueBuisness.findMenu(menuID);

            DataRow[] selected = _dtCart.Select($" item = '{_menu.name}'");

            if (selected.Length > 0)
            {
                foreach (DataRow dr in selected)
                {
                    dr["count"] = ((int)dr["count"]) + 1;
                }
            }
            else
            {

                _dtCart.Rows.Add(_menu.name, 1, _menu.price);
            }
            sum += (double)dgvItem.CurrentRow.Cells[2].Value;
        }

        private void _removeFromCArdFunctionlity()
        {
            string menuName = (string)dgvItem.CurrentRow.Cells[1].Value;

            DataRow[] selected = _dtCart.Select($" item = '{menuName}'");

            if (selected.Length != 0)
            {
                foreach (DataRow dr in selected)
                {
                    if ((int)dr["count"] > 1)
                    {
                        dr["count"] = ((int)dr["count"]) - 1;
                    }
                    else
                    {
                        dr.Delete();
                    }
                }
                sum -= (double)dgvItem.CurrentRow.Cells[2].Value;
            }

        }
        private void _clearCart()
        {
            _dtCart.Clear();
        }
        private void اضافةللسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _addToCArdFunctionlity();
            _loadCart();
        }

        private void حذفالعنصرمنالسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeFromCArdFunctionlity();
            _loadCart();

        }


        private void افراغالسلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clearCart();
        }

        private void شراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int orderID = 0;
            try
            {
                clsOrderBuisness _order = new clsOrderBuisness();
                _order.inResturant = true;
                _order.addBy = clsEmployee.employee == null ? null : clsEmployee.employee.id;
                _order.totalPrice = 0;
                _order.state = 2;
                double totalPrice = 0;
                if (_order.save())
                {
                    orderID = _order.id;

                    foreach (DataRow itmes in _dtCart.Rows)
                    {

                        clsMenueBuisness _menue = clsMenueBuisness.findMenu((string)itmes["item"]);
                        int count = 0;
                        double unitPrice = 0;
                        count = (int)itmes["count"];
                        unitPrice = _menue.price;

                        if (count != 0)
                        {
                            clsOrderItemBuisness _orderItem = new clsOrderItemBuisness();
                            _orderItem.menuID = _menue.id;
                            _orderItem.orderID = orderID;
                            _orderItem.quantity = count;
                            totalPrice += (count * unitPrice);

                            if (!_orderItem.save())
                            {
                                clsOrderItemBuisness.deleteOrderItem(orderID);
                                clsOrderBuisness.deleteOrder(orderID);
                                MessageBox.Show("فشلة العملية", "فاشلة", MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                    _order.mode = clsOrderBuisness.enMode.update;
                    _order.totalPrice = totalPrice;
                    if (!_order.save())
                    {
                        clsOrderItemBuisness.deleteOrderItem(orderID);
                        clsOrderBuisness.deleteOrder(orderID);
                        MessageBox.Show("فشلة العملية", "فاشلة", MessageBoxButtons.OK);
                        return;
                    };

                    frmShowOrderItem form = new frmShowOrderItem(_order.id, true);
                    form.ShowDialog();
                    _clearCart();

                }


            }
            catch (Exception ex)
            {
                clsEventHandlerBuisness.createEventError(ex.Message);
                clsOrderBuisness.deleteOrder(orderID);
                MessageBox.Show("فشلة العملية", "فاشلة", MessageBoxButtons.OK);

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void الفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCardList form = new frmCardList();
            form.ShowDialog();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            _dtItems.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "name", txtSearch.Text);

                        }
                        else
                        {
                            _dtItems.DefaultView.RowFilter = "";
                        }
                    }
                    break;
                case 1:
                    {
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            _dtCategory.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "name", txtSearch.Text);

                        }
                        else
                        {
                            _dtCategory.DefaultView.RowFilter = "";

                        }

                    }
                    break;
            }
        }

        private void تغيركلمةالمرورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword form = new frmUpdatePassword(clsEmployee.employee.id ?? 0);
            form.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginHolder.Show();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._loginHolder.Show();
            this.Close();
        }

    }
}
