using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockMarket
{
    public partial class frmReportOrderBill : Form
    {
        public frmReportOrderBill(string orderBill)
        {
            InitializeComponent();
            crystalReportViewer1.SelectionFormula="{OrderProduct.OrderBillNO}='"+ orderBill+"'";
            crystalReportViewer1.RefreshReport();
        }

        private void frmReportOrderBill_Load(object sender, EventArgs e)
        {

        }
    }
}
