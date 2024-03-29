using ResturantBuisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace Resturant.Card
{
    public partial class frmShowOrderItem : Form
    {
        private bool _isComplateOperation
        {
            set
            {

                btnComplate.Visible = value;
            }
            get { return _isComplateOperation; }
        }
        private DataTable _dtOrderItme = new DataTable();

        private clsOrderBuisness _order;
        private void _loadData(int orderID)
        {
            _order = clsOrderBuisness.findOrderByID(orderID);

            if (_order == null)
            {
                MessageBox.Show("هذه الفاتورة غير موجودة", "خظاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _dtOrderItme = clsOrderItemBuisness.getOrders(_order.id);
            dgvOrderItm.DataSource = _dtOrderItme;
            lbTotal.Text = _order.totalPrice.ToString();

        }
        public frmShowOrderItem(int orderID, bool isComplateOperation = false)
        {
            InitializeComponent();
            _loadData(orderID);
            _isComplateOperation = isComplateOperation;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this._isComplateOperation == true)
            {
                clsOrderItemBuisness.deleteOrderItem(_order.id);
                clsOrderBuisness.deleteOrder(_order.id);
            }
            this.Close();
        }

        private void btnComplate_Click(object sender, EventArgs e)
        {
            _order.state = 1;
            MessageBox.Show("تمت العملية بنجاح", "ناحجة", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
