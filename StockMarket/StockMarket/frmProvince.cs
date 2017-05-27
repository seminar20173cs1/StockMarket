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
    public partial class frmProvince : Form
    {
        public frmProvince()
        {
            InitializeComponent();
        }
        string strcon = "Data source=THONGSING-PC; Initial catalog=StockMarket; integrated security=True";
        //string strcon = "Data source=THONGSING-PC; Initial catalog=StockMarket; userName=sa;password=123";
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        private void frmProvince_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.ConnectionString = strcon;
            conn.Open();
            ShowProvince();
            DGV.Columns[0].HeaderText = "ລະຫັດແຂວງ";
            DGV.Columns[1].HeaderText = "ຊື່ແຂວງ";
            DGV.Columns[0].Width = 150;
            DGV.Columns[1].Width = 200;
            DGV.DefaultCellStyle.BackColor = Color.Beige;
            DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
        }
        private void ShowProvince()
        {
            da = new SqlDataAdapter("Select * from Province", conn);
            da.Fill(ds, "Province");
            ds.Tables[0].Clear();
            da.Fill(ds, "Province");
            DGV.DataSource = ds.Tables[0];
            DGV.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Insert into Province values(@ProID,@ProName)", conn);
            cmd.Parameters.AddWithValue("@ProID", txtProvinceID.Text);
            cmd.Parameters.AddWithValue("@ProName", txtProvinceName.Text);
            cmd.ExecuteNonQuery();
            ShowProvince();
            txtProvinceID.Clear();
            txtProvinceName.Clear();
            txtProvinceID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Update Province Set ProvinceName=@ProName where ProvinceID=@ProID", conn);
            cmd.Parameters.AddWithValue("@ProID", txtProvinceID.Text);
            cmd.Parameters.AddWithValue("@ProName", txtProvinceName.Text);
            cmd.ExecuteNonQuery();
            ShowProvince();
            txtProvinceID.Clear();
            txtProvinceName.Clear();
            txtProvinceID.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Delete from Province where ProvinceID=@ProID", conn);
            cmd.Parameters.AddWithValue("@ProID", txtProvinceID.Text);
            cmd.ExecuteNonQuery();
            ShowProvince();
            txtProvinceID.Clear();
            txtProvinceName.Clear();
            txtProvinceID.Focus();
        }

        private void DGV_Click(object sender, EventArgs e)
        {
            txtProvinceID.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtProvinceName.Text=DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }
    }
}
