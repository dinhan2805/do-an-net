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
    public partial class NguoiDung : MetroFramework.Forms.MetroForm
    {
        public NguoiDung()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from NguoiDung";
            DataSet ds = kn.LayDuLieu(query);
            dgvNguoiDung.DataSource = ds.Tables[0];
        }
        public void Clear()
        {
            txtTaiKhoan.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            
        }
        public void getLoaiNV()
        {
            string query = "select * from LoaiNguoiDung ";
            DataSet ds = kn.LayDuLieu(query);
            cmbMaNguoidung.DataSource = ds.Tables[0];
            cmbMaNguoidung.DisplayMember = "TenLoaiND";
            cmbMaNguoidung.ValueMember = "MaLoaiND";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from NguoiDung where TaiKhoan = '{0}'",
                txtTaiKhoan.Text
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

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update NguoiDung set MatKhau= N'{1}',MaLoaiND=N'{2}' where TaiKhoan = '{0}'",
                txtTaiKhoan.Text,
                txtMatKhau.Text,
                cmbMaNguoidung.SelectedValue
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

        private void NguoiDung_Load(object sender, EventArgs e)
        {
            getData();
            getLoaiNV();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
            getData();
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtTaiKhoan.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTaiKhoan.Text = dgvNguoiDung.Rows[r].Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung.Rows[r].Cells["MatKhau"].Value.ToString();
                cmbMaNguoidung.Text = dgvNguoiDung.Rows[r].Cells["MaLoaiND"].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into NguoiDung values(N'{0}', N'{1} ', N'{2}')",
                txtTaiKhoan.Text,
                txtMatKhau.Text,
                cmbMaNguoidung.SelectedValue

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from NguoiDung where TaiKhoan like N'%{0}%'",
                txtTimKiem.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            dgvNguoiDung.DataSource = ds.Tables[0];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
