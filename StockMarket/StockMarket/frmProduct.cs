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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        SqlDataReader drP;
        SqlDataReader drU;
        SqlDataReader drC;
        DataTable dtP = new DataTable();
        DataTable dtU = new DataTable();
        DataTable dtC = new DataTable();
        ConnectDatabase cd = new ConnectDatabase();
        string sql = "";
        private void frmProduct_Load(object sender, EventArgs e)
        {
            cd.ConnectStockMarket();
           
            cd.cmd=new SqlCommand("up_SelectUnit",cd.conn);          
            drU = cd.cmd.ExecuteReader();
            if (drU.HasRows)
            {
                dtU.Load(drU);
                cbUnit.DataSource = dtU;
                cbUnit.DisplayMember = "UnitName";
                cbUnit.ValueMember = "UnitID";
            }

            cd.cmd = new SqlCommand("up_SelectCategory", cd.conn);
            drC = cd.cmd.ExecuteReader();
            if (drC.HasRows)
            {
                dtC.Load(drC);
                cbCategory.DataSource = dtC;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
            }
            ShowProduct();
        }
        private void ShowProduct()
        {
            dtP.Clear();
            cd.cmd = new SqlCommand("up_SelectProduct", cd.conn);
            drP = cd.cmd.ExecuteReader();
            if (drP.HasRows)
            {
                dtP.Load(drP);
                DGV.DataSource = dtP;
                DGV.Refresh();                
            }
            drC.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sql="up_InsertProduct "+txtProductID.Text+","+txtProducctName.Text+","+txtPrice.Text+","+txtQty.Text+","+cbUnit.SelectedValue.ToString()+","+cbCategory.SelectedValue.ToString()+","+txtCondition.Text;
            cd.cmd = new SqlCommand(sql, cd.conn);
            cd.cmd.ExecuteNonQuery();
            ShowProduct();
        }
    }
}
