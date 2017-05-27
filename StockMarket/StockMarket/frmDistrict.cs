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
    public partial class frmDistrict : Form
    {
        public frmDistrict()
        {
            InitializeComponent();
        }
        ConnectDatabase cd = new ConnectDatabase();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void frmDistrict_Load(object sender, EventArgs e)
        {
            cd.ConnectStockMarket();
            SqlDataAdapter daP = new SqlDataAdapter("Select * from Province",cd.conn);
            DataSet dsP = new DataSet();
            daP.Fill(dsP, "Province");
            cbProvince.DataSource = dsP.Tables[0];
            cbProvince.DisplayMember = "ProvinceName";
            cbProvince.ValueMember = "ProvinceID";

            ShowDistrict();

        }
        void ShowDistrict()
        {
            da = new SqlDataAdapter("SELECT   D.DistrictID, D.DistrictName, P.ProvinceName FROM dbo.Province P INNER JOIN  dbo.District D ON P.ProvinceID = D.ProvinceID", cd.conn);
            da.Fill(ds, "District");
            ds.Tables[0].Clear();
            da.Fill(ds, "District");
            DGV.DataSource = ds.Tables[0];
            DGV.Refresh();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            cd.cmd = new SqlCommand("Insert into District Values(@DistrictID,@DistrictName,@ProvinceID)", cd.conn);
            cd.cmd.Parameters.AddWithValue("@DistrictID", txtDistrictID.Text);
            cd.cmd.Parameters.AddWithValue("@DistrictName", txtDistricctName.Text);
            cd.cmd.Parameters.AddWithValue("@ProvinceID", cbProvince.SelectedValue);
            cd.cmd.ExecuteNonQuery();
            ShowDistrict();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cd.cmd = new SqlCommand("Update District Set DistrictName=@DistrictName,ProvinceID=@ProvinceID where DistrictID=@DistrictID", cd.conn);
            cd.cmd.Parameters.AddWithValue("@DistrictID", txtDistrictID.Text);
            cd.cmd.Parameters.AddWithValue("@DistrictName", txtDistricctName.Text);
            cd.cmd.Parameters.AddWithValue("@ProvinceID", cbProvince.SelectedValue);
            cd.cmd.ExecuteNonQuery();
            ShowDistrict();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cd.cmd = new SqlCommand("Delete from District where DistrictID=@DistrictID", cd.conn);
            cd.cmd.Parameters.AddWithValue("@DistrictID", txtDistrictID.Text);
            cd.cmd.ExecuteNonQuery();
            ShowDistrict();
        }

        private void DGV_Click(object sender, EventArgs e)
        {
            txtDistrictID.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtDistricctName.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
            cbProvince.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[2].Value.ToString();
        }
    }
}
