using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DoAnChamNet
{
    public partial class frmSanPham : MetroFramework.Forms.MetroForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from SanPham";
            DataSet ds = kn.LayDuLieu(query);
            dgvSanPham.DataSource = ds.Tables[0];
        }
        public void Clear()
        {
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update SanPham set TenSP= N'{1}',GiaBan=N'{2}' where MaSP = '{0}'",
                txtMaSP.Text,
                txtTenSP.Text,
                txtGiaBan.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành Công ! ");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại ! ");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into SanPham values(N'{0}', N'{1} ', N'{2}')",
                txtMaSP.Text,
                txtTenSP.Text,
                txtGiaBan.Text
                
                );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Mới Thành Công ! ");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm Mới Thất Bại ! ");
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaSP.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaSP.Text = dgvSanPham.Rows[r].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgvSanPham.Rows[r].Cells["TenSP"].Value.ToString();
                txtGiaBan.Text = dgvSanPham.Rows[r].Cells["GiaBan"].Value.ToString();
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from SanPham where MaSP = '{0}'",
                txtMaSP.Text,
                txtTenSP.Text,
                txtGiaBan.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành Công ! ");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại ! ");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from SanPham where TenSP like N'%{0}%'",
                txtTimKiem.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            dgvSanPham.DataSource = ds.Tables[0];
            /*
               string query = String.Format("select Nhanvien.* from NhanVien inner join LoaiNhanVien on NhanVien.MaLoaiNV = LoaiNhanVien.MaLoaiNV where LoaiNhanVien.TenLoaiNV like N'%{0}%'",
                txtTimKiem.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            dataGridView1.DataSource = ds.Tables[0];
             */
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGiaBan.Text, out int result))
            {
                MessageBox.Show("Vui lòng nhập một giá hợp lệ.");

            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
           // System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
           // decimal value = decimal.Parse(txtGiaBan.Text, System.Globalization.NumberStyles.AllowThousands);
            //txtGiaBan.Text = String.Format(culture, "{0:N0}", value);
            //txtGiaBan.Select(txtGiaBan.Text.Length, 0);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
