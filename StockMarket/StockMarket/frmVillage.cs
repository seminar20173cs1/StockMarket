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
    public partial class frmVillage : Form
    {
        public frmVillage()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectDatabase cd = new ConnectDatabase();
        private void frmVillage_Load(object sender, EventArgs e)
        {
            cd.ConnectStockMarket();
            SqlDataAdapter daP = new SqlDataAdapter("Select * from Province", cd.conn);
            DataSet dsP = new DataSet();
            daP.Fill(dsP, "Province");
            cbProvince.DataSource = dsP.Tables[0];
            cbProvince.DisplayMember = "ProvinceName";
            cbProvince.ValueMember = "ProvinceID";
            ShowVillage();
            txtVillageID.Enabled = false;
      
        }
        private void ShowVillage()
        { 
              da = new SqlDataAdapter("SELECT  V.VillageID, V.VillageName, D.DistrictName, P.ProvinceName FROM  dbo.District D INNER JOIN dbo.Province P ON D.ProvinceID = P.ProvinceID INNER JOIN  dbo.Village V ON D.DistrictID = V.DistrictID", cd.conn);
              da.Fill(ds, "V");
              ds.Tables[0].Clear();
              da.Fill(ds, "V");
              DGV.DataSource = ds.Tables[0];
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            cd.cmd = new SqlCommand("Insert into Village values(@VillageName,@DistrictID)", cd.conn);
            cd.cmd.Parameters.AddWithValue("@VillageName", txtVillagetName.Text);
            cd.cmd.Parameters.AddWithValue("@DistrictID", cbDistrict.SelectedValue);
            cd.cmd.ExecuteNonQuery();
            ShowVillage();

        }
    }
}
