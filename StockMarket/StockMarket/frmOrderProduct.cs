using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockMarket
{
    public partial class frmOrderProduct : Form
    {
        public frmOrderProduct()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectDatabase cd = new ConnectDatabase();
        DataTable dt = new DataTable();
        string ProID, ProName, Price, Qty, Unit, Category;
        SqlDataAdapter daB= new SqlDataAdapter();
        DataSet dsB= new DataSet();
        string UserName = "ພອນ";

        private void frmOrderProduct_Load(object sender, EventArgs e)
        {
            cd.ConnectStockMarket();
            da = new SqlDataAdapter("SELECT  dbo.Product.ProductID, dbo.Product.ProductName, dbo.Product.Price, dbo.Product.Qty, dbo.Unit.UnitName, dbo.Category.CategoryName FROM dbo.Category INNER JOIN dbo.Product ON dbo.Category.CategoryID = dbo.Product.CategoryID INNER JOIN dbo.Unit ON dbo.Product.UnitID = dbo.Unit.UnitID WHERE(dbo.Product.Qty<0)", cd.conn);
            da.Fill(ds, "P");
            ds.Tables[0].Clear();
            da.Fill(ds, "P");
            DGV1.DataSource = ds.Tables[0];
            DGV1.Refresh();

            //ຕັ້ງຄ່າ DataGridViews(DGV2)
            dt.Columns.Add("ລະຫັດສິນຄ້າ",typeof(string));
            dt.Columns.Add("ຊື່ສິນຄ້າ", typeof(string));
            dt.Columns.Add("ຈຳນວນສິນຄ້າ", typeof(string));
            dt.Columns.Add("ຫົວໜ່ວຍສິນຄ້າ", typeof(string));
            dt.Columns.Add("ປະເພດສິນຄ້າ", typeof(string));
            DGV2.DataSource = dt;

            timer1.Start();

            AutoBill();
            txtOrderBillNo.Enabled = false;
            
        }
        private void AutoBill()
        {
            daB = new SqlDataAdapter("Select Max(OrderBillNo) from orderProduct", cd.conn);
            daB.Fill(dsB, "B");
            dsB.Tables[0].Clear();
            daB.Fill(dsB, "B");
            string OrderBillNo = dsB.Tables[0].Rows[0].ItemArray[0].ToString();        
            OrderBillNo =(int.Parse( OrderBillNo) + 1).ToString();          
            txtOrderBillNo.Text =int.Parse(OrderBillNo).ToString("00000");

        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT  dbo.Product.ProductID, dbo.Product.ProductName, dbo.Product.Price, dbo.Product.Qty, dbo.Unit.UnitName, dbo.Category.CategoryName FROM dbo.Category INNER JOIN dbo.Product ON dbo.Category.CategoryID = dbo.Product.CategoryID INNER JOIN dbo.Unit ON dbo.Product.UnitID = dbo.Unit.UnitID WHERE(dbo.Product.Qty <= dbo.Product.Condition)", cd.conn);
            da.Fill(ds, "P");
            ds.Tables[0].Clear();
            da.Fill(ds, "P");
            DGV1.DataSource = ds.Tables[0];
            DGV1.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(ProID, ProName,"" , Unit, Category);
            DGV2.DataSource = dt;
            DGV2.Refresh();
            DGV1.Rows.Remove(DGV1.CurrentRow);
            lbCount.Text = (DGV2.Rows.Count - 1).ToString();

        }

        private void DGV1_Click(object sender, EventArgs e)
        {
            try
            {
                ProID = DGV1.Rows[DGV1.CurrentRow.Index].Cells[0].Value.ToString();
                ProName = DGV1.Rows[DGV1.CurrentRow.Index].Cells[1].Value.ToString();
                Price = DGV1.Rows[DGV1.CurrentRow.Index].Cells[2].Value.ToString();
                Qty = DGV1.Rows[DGV1.CurrentRow.Index].Cells[3].Value.ToString();
                Unit = DGV1.Rows[DGV1.CurrentRow.Index].Cells[4].Value.ToString();
                Category = DGV1.Rows[DGV1.CurrentRow.Index].Cells[5].Value.ToString();

            }
            catch (Exception ex)
            { 
            
            }
        }

        private void DGV2_Click(object sender, EventArgs e)
        {
           
        }

        private void DGV2_DoubleClick(object sender, EventArgs e)
        {
            DGV2.Rows.Remove(DGV2.CurrentRow);
            lbCount.Text = (DGV2.Rows.Count - 1).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DGV2.Rows.Remove(DGV2.CurrentRow);
            lbCount.Text = (DGV2.Rows.Count - 1).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbOrderTime.Text =DateTime.Now.ToString("hh:mm:ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cd.cmd = new SqlCommand("Insert into orderProduct values(@OrderBillNo,@OrderDate,@OrderTime,@UserName)", cd.conn);
            cd.cmd.Parameters.AddWithValue("@OrderBillNo", txtOrderBillNo.Text);
            cd.cmd.Parameters.AddWithValue("@OrderDate",Convert.ToDateTime(dtpOrderDate.Text).ToString("yyyy-MM-dd"));
            cd.cmd.Parameters.AddWithValue("@OrderTime", lbOrderTime.Text);
            cd.cmd.Parameters.AddWithValue("@UserName", UserName);
            cd.cmd.ExecuteNonQuery();
            //ບັນທຶກລາຍລະອຽດການສັ່ງຊື້
            int i;
            for (i = 0; i < DGV2.Rows.Count-1; i++)
            {
                cd.cmd = new SqlCommand("Insert into OrderDetail values(@ProductID,@Qty,@OrderBillNo)", cd.conn);
                cd.cmd.Parameters.AddWithValue("@ProductID", DGV2.Rows[i].Cells[0].Value);
                cd.cmd.Parameters.AddWithValue("@Qty", DGV2.Rows[i].Cells[2].Value);
                cd.cmd.Parameters.AddWithValue("@OrderBillNO", txtOrderBillNo.Text);
                cd.cmd.ExecuteNonQuery();
            }
            MessageBox.Show("ບັນທຶກແລ້ວ");
            frmReportOrderBill frm = new frmReportOrderBill(txtOrderBillNo.Text);           
            frm.Show();
            AutoBill();
            dt.Clear();
            DGV2.DataSource = dt;
            ds.Tables[0].Clear();
            DGV1.DataSource=ds.Tables[0];
           

        }
    }
}
