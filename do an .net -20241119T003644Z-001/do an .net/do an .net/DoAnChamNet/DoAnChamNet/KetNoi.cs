using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnChamNet
{
    class KetNoi
    {
        string Constr = @"Data Source=TIENCHUNGLOVEU\TIENCHUNG;Initial Catalog=WebBanGao;Integrated Security=True";
        SqlConnection conn;
        public KetNoi()
        {
            conn = new SqlConnection(Constr);
        }
        
        public DataSet LayDuLieu(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool ThucThi(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
