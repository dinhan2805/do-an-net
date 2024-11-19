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
    public partial class HoaDon : MetroFramework.Forms.MetroForm
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        public void getData()
        {
            string query = "select * from HoaDon";
            DataSet ds = kn.LayDuLieu(query);
            dgvHoaDon.DataSource = ds.Tables[0];
        }
        public void Clear()
        {
            txtMaHD.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.Text = "";
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtMaNV.Text = "";
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            btnLamMoi.PerformClick();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
            getData();
        }
        public void SoLuongGiam()
        {
            string query = string.Format(
                "update Kho set TonKho = TonKho - '{1} ' where MaSP = '{0} ' ",
                
                txtMaSP.Text,
                txtSoLuong.Text
                

                );
            bool kt = kn.ThucThi(query);
        }
        public void SoLuongTang()
        {
            string query = string.Format(
                "update Kho set TonKho = TonKho + '{1} ' where MaSP = '{0} ' ",

                txtMaSP.Text,
                txtSoLuong.Text


                );
            bool kt = kn.ThucThi(query);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text != "" && txtMaSP.Text != "" && txtSoLuong.Text != "" && txtMaNV.Text != "") 
            {
                string query = string.Format(
                "insert into HoaDon values(N'{0}', N'{1} ', N'{2}', N'{3} ', N'{4}')",
                txtMaHD.Text,
                NgayLap.Value.ToString("yyyy/MM/dd"),
                txtMaSP.Text,
                txtSoLuong.Text,
                txtMaNV.Text

                );
                bool kt = kn.ThucThi(query);
                if (kt == true)
                {
                    SoLuongGiam();
                    MessageBox.Show("BẠN VỪA TẠO THÀNH CÔNG HÓA ĐƠN \n" +
                          " MÃ HÓA ĐƠN      :  "+txtMaHD.Text+
                        "\n NGÀY LẬP        : "+NgayLap.Text+
                        "\n MÃ SẢN PHẨM     : "+txtMaSP.Text+
                        "\n SỐ LƯỢNG        : " + txtSoLuong.Text +
                        "\n MÃ NHÂN VIÊN    : " + txtMaNV.Text 





                        );
                    btnLamMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Thêm Mới Thất Bại ! ");
                }
            }
            else
            {
                MessageBox.Show("Hãy Nhập Liệu Đầy Đủ ! ");
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update HoaDon set NgayLap= N'{1}',MaSP=N'{2}',SoLuong=N'{3}',MaNV=N'{4}' where MaHD = '{0}'",
               txtMaHD.Text,
                NgayLap.Value.ToString("yyyy/MM/dd"),
                txtMaSP.Text,
                txtSoLuong.Text,
                txtMaNV.Text
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from HoaDon where MaHD = '{0}'",
                txtMaHD.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                SoLuongTang();
                MessageBox.Show("Xóa Thành Công ! ");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại ! ");
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaHD.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHD.Text = dgvHoaDon.Rows[r].Cells["MaHD"].Value.ToString();
                NgayLap.Text = dgvHoaDon.Rows[r].Cells["NgayLap"].Value.ToString();
                txtMaSP.Text = dgvHoaDon.Rows[r].Cells["MaSP"].Value.ToString();
                txtSoLuong.Text = dgvHoaDon.Rows[r].Cells["SoLuong"].Value.ToString();
                txtMaNV.Text = dgvHoaDon.Rows[r].Cells["MaNV"].Value.ToString();



            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out int result))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.");

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from HoaDon where MaHD=  '{0}'",
                txtTimKiem.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            dgvHoaDon.DataSource = ds.Tables[0];
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void NgayLap_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
