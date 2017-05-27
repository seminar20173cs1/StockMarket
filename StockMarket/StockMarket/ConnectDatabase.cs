using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace StockMarket
{
    class ConnectDatabase
    {
        public string strcon = "Data source=THONGSING-PC; initial catalog=StockMarket; integrated security=True";
        public SqlConnection conn = new SqlConnection();
        public  SqlCommand cmd = new SqlCommand();

        public void ConnectStockMarket()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();                
            }
            conn.ConnectionString = strcon;
            conn.Open();
        }

    }
}
