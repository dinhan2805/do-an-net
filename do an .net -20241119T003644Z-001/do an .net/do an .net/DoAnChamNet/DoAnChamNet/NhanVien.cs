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
        public partial class NhanVien : MetroFramework.Forms.MetroForm
        {
            public NhanVien()
            {
                InitializeComponent();
            }
            KetNoi kn = new KetNoi();
            public void getData()
            {
                string query = "select * from NhanVien";
                DataSet ds = kn.LayDuLieu(query);
                dgvNhanVien.DataSource = ds.Tables[0];
            }
            public void Clear()
            {
                txtMaNV.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                txtMaNV.Text = "";
                txtTenNV.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtTKhoan.Text = "";
                txtLuong.Text = "";

            }
            private void button4_Click(object sender, EventArgs e)
            {
                string query = string.Format(
                    "delete from NhanVien where MaNV = '{0}'",
                    txtMaNV.Text
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

            private void NhanVien_Load(object sender, EventArgs e)
            {
                btnLamMoi.PerformClick();
            }

            private void btnLamMoi_Click(object sender, EventArgs e)
            {
                Clear();
                getData();
            }

            private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int r = e.RowIndex;
                if (r >= 0)
                {
                    txtMaNV.Enabled = false;
                    btnThem.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    txtMaNV.Text = dgvNhanVien.Rows[r].Cells["MaNV"].Value.ToString();
                    txtTenNV.Text = dgvNhanVien.Rows[r].Cells["TenNV"].Value.ToString();
                    txtDiaChi.Text = dgvNhanVien.Rows[r].Cells["DiaChi"].Value.ToString();
                    txtSDT.Text = dgvNhanVien.Rows[r].Cells["SDT"].Value.ToString();
                    txtTKhoan.Text = dgvNhanVien.Rows[r].Cells["TaiKhoan"].Value.ToString();
                    txtLuong.Text = dgvNhanVien.Rows[r].Cells["Luong"].Value.ToString();



                }
            }

            private void btnThem_Click(object sender, EventArgs e)
            {
                string query = string.Format(
                    "insert into NhanVien values(N'{0}', N'{1} ', N'{2}',N'{3}', N'{4} ', N'{5}')",
                    txtMaNV.Text,
                    txtTenNV.Text,
                    txtDiaChi.Text,
                    txtSDT.Text,
                    txtTKhoan.Text,
                    txtLuong.Text

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

            private void btnSua_Click(object sender, EventArgs e)
            {
                string query = string.Format(
                    "update NhanVien set TenNV =  N'{1} ',DiaChi= N'{2}',SDT = N'{3}',TaiKhoan= N'{4} ',Luong= N'{5}' where MaNV = '{0}'",

                   txtMaNV.Text,
                    txtTenNV.Text,
                    txtDiaChi.Text,
                    txtSDT.Text,
                    txtTKhoan.Text,
                    txtLuong.Text
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

            private void btnTimKiem_Click(object sender, EventArgs e)
            {
                string query = String.Format("select * from NhanVien where TenNV like N'%{0}%'",
                    txtTimKiem.Text
                    );
                DataSet ds = kn.LayDuLieu(query);
                dgvNhanVien.DataSource = ds.Tables[0];
            }

            private void txtTimKiem_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtLuong_TextChanged(object sender, EventArgs e)
            {
           
                    if (!int.TryParse(txtLuong.Text, out int result))
                    {
                        MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.");
                        txtLuong.Focus();
                    }
            
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void groupBox2_Enter(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }
        }
    }
