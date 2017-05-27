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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        SqlDataReader dr;
        DataTable dt = new DataTable();
        ConnectDatabase cd = new ConnectDatabase();
        string sql = "";
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            txtBrcode.Text = txtCustomerID.Text;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            cd.ConnectStockMarket();
            ShowCustomer();
            SqlDataAdapter daP = new SqlDataAdapter("Select * from Province", cd.conn);
            DataSet dsP = new DataSet();
            daP.Fill(dsP, "Province");
            cbProvince.DataSource = dsP.Tables[0];
            cbProvince.DisplayMember = "ProvinceName";
            cbProvince.ValueMember = "ProvinceID";
            
        }
        private void ShowCustomer()
        {
            dt.Clear();
            cd.cmd = new SqlCommand("SELECT dbo.Customer.CustomerID, dbo.Customer.CustomerName, dbo.Customer.Surname, dbo.Customer.Phone, dbo.Village.VillageName, dbo.District.DistrictName, dbo.Province.ProvinceName FROM dbo.Province INNER JOIN  dbo.District ON dbo.Province.ProvinceID = dbo.District.ProvinceID INNER JOIN  dbo.Village ON dbo.District.DistrictID = dbo.Village.DistrictID INNER JOIN dbo.Customer ON dbo.Village.VillageID = dbo.Customer.VillageID", cd.conn);
            dr = cd.cmd.ExecuteReader();
            dt.Load(dr);
            DGV.DataSource = dt;
            DGV.Refresh();
         

        }

        private void cbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter daD = new SqlDataAdapter("Select * from District where ProvinceID=" + cbProvince.SelectedValue + "", cd.conn);
                DataSet dsD = new DataSet();
                daD.Fill(dsD, "District");
                cbDistrict.DataSource = dsD.Tables[0];
                cbDistrict.DisplayMember = "DistrictName";
                cbDistrict.ValueMember = "DistrictID";
            }
            catch (Exception ex)
            {

            }
        }

        private void cbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter daV = new SqlDataAdapter("Select * from Village where DistrictID=" + cbDistrict.SelectedValue + "", cd.conn);
                DataSet dsV = new DataSet();
                daV.Fill(dsV, "V");
                cbVillage.DataSource = dsV.Tables[0];
                cbVillage.DisplayMember = "VillageName";
                cbVillage.ValueMember = "VillageID";
            }
            catch (Exception ex)
            {

            }
        }
        private void Statement(string sql)
        { 
           
            cd.cmd.CommandType = CommandType.Text;
            cd.cmd.CommandText = sql;
            cd.cmd.Connection = cd.conn;
            cd.cmd.ExecuteNonQuery();
            ShowCustomer();
        
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            sql = "up_InsertVillage " + txtCustomerID.Text + "," + txtCustomerName.Text + "," + txtSurname.Text + "," + txtPhone.Text + "," + cbVillage.SelectedValue;
            Statement(sql);          

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            sql = "up_UpdateVillage " + txtCustomerID.Text + "," + txtCustomerName.Text + "," + txtSurname.Text + "," + txtPhone.Text + "," + cbVillage.SelectedValue;
            Statement(sql);  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sql = "up_DeleteVillage " + txtCustomerID.Text ;
            Statement(sql);  
        }
    }
}
