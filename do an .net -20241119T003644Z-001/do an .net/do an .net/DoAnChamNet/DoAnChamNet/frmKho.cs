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
    public partial class frmKho : MetroFramework.Forms.MetroForm
    {
        public frmKho()
        {
            InitializeComponent();
            
        }
        
        KetNoi kn =new KetNoi();
        public void Clear()
        {
            txtViTriKho.Enabled = true;
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtViTriKho.Text = "";
            txtMaSP.Text = "";
            txtTonKho.Text = "";
            txtNCC.Text = "";
            txtGiaNhap.Text = "";
        }
        public void getData()
        {
            string query = "select * from Kho";
            DataSet ds = kn.LayDuLieu(query);
            dgvKho.DataSource = ds.Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from Kho where ViTri = '{0}' and MaSP ='{1}'",
                txtViTriKho.Text,
                txtMaSP.Text
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

        private void frmKho_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtViTriKho.Text = dgvKho.Rows[r].Cells["ViTri"].Value.ToString();
                txtMaSP.Text = dgvKho.Rows[r].Cells["MaSP"].Value.ToString();
                txtTonKho.Text = dgvKho.Rows[r].Cells["TonKho"].Value.ToString();
                txtNCC.Text = dgvKho.Rows[r].Cells["NhaCC"].Value.ToString();
                txtGiaNhap.Text = dgvKho.Rows[r].Cells["GiaNhap"].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into Kho values(N'{0}', N'{1} ', N'{2}', N'{3}', N'{4}')",
                txtViTriKho.Text,
                txtMaSP.Text,
                txtTonKho.Text,
                txtNCC.Text,
                txtGiaNhap.Text

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from Kho where MaSP like N'%{0}%'",
               txtTimKiem.Text
               );
            DataSet ds = kn.LayDuLieu(query);
            dgvKho.DataSource = ds.Tables[0];
        }

        private void txtTonKho_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTonKho.Text, out int result))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.");

            }
        }

        private void txtGiaNhap_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGiaNhap.Text, out int result))
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ.");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update Kho set ViTri= N'{0}',TonKho=N'{2}',NhaCC=N'{3}',GiaNhap=N'{4}' where MaSP = '{1}'",
                txtViTriKho.Text,
                txtMaSP.Text,
                txtTonKho.Text,
                txtNCC.Text,
                txtGiaNhap.Text
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
