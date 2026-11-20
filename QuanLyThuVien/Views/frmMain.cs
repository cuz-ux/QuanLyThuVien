using QuanLyThuVien.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_QLTK_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoanNhanVien frm = new frmQuanLyTaiKhoanNhanVien();    
            frm.ShowDialog();   
        }

        private void btn_thuthu_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btn_quanlysach_Click(object sender, EventArgs e)
        {
            frmQuanLySach frm = new frmQuanLySach();
            frm.ShowDialog();
        }

        private void btn_quanlydocgia_Click(object sender, EventArgs e)
        {
            frmQuanLyDocGia frm = new frmQuanLyDocGia();
            frm.ShowDialog();
        }

        private void btn_quanlymuonsach_Click(object sender, EventArgs e)
        {
            frmMuonSach frm = new frmMuonSach();
            frm.ShowDialog();
        }

        private void btn_quanlytrasach_Click(object sender, EventArgs e)
        {
            frmTraSach frm = new frmTraSach();
            frm.ShowDialog();
        }

        private void btn_baocaothongke_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }
    }
}
