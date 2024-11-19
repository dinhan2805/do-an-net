using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnChamNet
{
    public partial class ThongKe : MetroFramework.Forms.MetroForm
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        void Getdata()
        {
            string query = String.Format("select *from HoaDon where NgayLap between '{0} ' and '{1} '",
                FromDate.Value.ToString("yyyy/MM/dd"),
                ToDate.Value.ToString("yyyy/MM/dd")
                );
            DataSet ds = kn.LayDuLieu(query);
            dgvThongKe.DataSource = ds.Tables[0];
        }
        void TongThu()
        {
            string query = String.Format("select sum(SanPham.GiaBan * HoaDon.SoLuong) from SanPham, HoaDon where SanPham.MaSP = HoaDon.MaSP and HoaDon.NgayLap between  '{0} ' and '{1} '",
                FromDate.Value.ToString("yyyy/MM/dd"),
                ToDate.Value.ToString("yyyy/MM/dd")
                );
            DataSet ds = kn.LayDuLieu(query);
            dgvTongThu.DataSource = ds.Tables[0];
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            Getdata();
            TongThu();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
