using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinParser.Data;

namespace WinParser
{
    public partial class Frm_CreateOrderList : Form
    {
        private List<Order> _orderList;
        private List<Order> _selectedOrders;
        public List<Order> SelectedOrders 
        {
            get => _selectedOrders;
        }
        public Frm_CreateOrderList(List<Order> orderList)
        {
            InitializeComponent();
            _orderList = orderList;
            bs_Orders.DataSource = _orderList;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_CreateOrderList_Load(object sender, EventArgs e)
        {
            dgv_Orders.DataSource = bs_Orders;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            _selectedOrders = new List<Order>();
            foreach (DataGridViewRow row in dgv_Orders.Rows)
            {
                if (row.Cells[dgvc_Checked.Name].Value != null && (bool)row.Cells[dgvc_Checked.Name].Value == true) 
                    _selectedOrders.Add(row.DataBoundItem as Order);
                
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbx_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_Orders == null || dgv_Orders.Rows.Count == 0)
                return;

            for (int i = 0; i < dgv_Orders.Rows.Count; i++) 
            {
                DataGridViewRow row = dgv_Orders.Rows[i];
                row.Cells[dgvc_Checked.Name].Value = cbx_SelectAll.Checked;
            }
        }
    }
}
