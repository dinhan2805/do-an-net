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
    public partial class FormHeThong : MetroFramework.Forms.MetroForm
    {
        public FormHeThong()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();


        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuSanPham_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmSanPham frm1 = new frmSanPham();
            
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frm1 = new frmKho();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void FormHeThong_Load(object sender, EventArgs e)
        {
            if (Program.PhanQuyen == "nhanvien")
            {
                MenuNguoiDung.Enabled = false;
                MenuNhanVien.Enabled = false;
                
            }

        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon frm1 = new HoaDon();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void quảnLíToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NhanVien frm1 = new NhanVien();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void quảnLíToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NguoiDung frm1 = new NguoiDung();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe frm1 = new ThongKe();
            frm1.MdiParent = this;
            frm1.Show();
        }
    }
}
