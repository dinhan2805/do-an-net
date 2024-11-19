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
    
    public partial class FormLogin : MetroFramework.Forms.MetroForm
    {
        KetNoi kn = new KetNoi();
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private string Quyen = "";
        
        public void GetQuyen(string tk,string mk)
        {
            string query = string.Format(
                "select MaLoaiND from NguoiDung where TaiKhoan = '{0}' and MatKhau= '{1}' and MaLoaiND ='admin'  ",
                txtTaiKhoan.Text, txtMatKhau.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                Quyen = "Người Quản Lí";
                Program.PhanQuyen = "admin";

            }
            else
            {
                Quyen = "Nhân Viên";
                Program.PhanQuyen = "nhanvien";
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string query = string.Format(
                "select * from NguoiDung where TaiKhoan = '{0}' and MatKhau= '{1}'",
                txtTaiKhoan.Text, txtMatKhau.Text
                );
            DataSet ds = kn.LayDuLieu(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                GetQuyen(txtTaiKhoan.Text, txtMatKhau.Text);
                MessageBox.Show("Tài Khoản Đăng Nhập Thành Công ! \n Bạn Đang Truy Cập Với Tư Cách : "+Quyen);
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
               
                FormHeThong ht = new FormHeThong();
                this.Hide();
                ht.ShowDialog();
                this.Show();
                

            }
            else
            {
                MessageBox.Show("Đăng Nhập Thất Bại !");
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

