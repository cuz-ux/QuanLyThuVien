using QuanLyThuVien.Controllers;
using System;
using QuanLyThuVien.Views;
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
    public partial class frmDangNhap : Form
    {
        TaiKhoanNhanVienControllers db = new TaiKhoanNhanVienControllers();
        public static string username;
        public static string password;
        public static string mod;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (txtMADANGNHAP.Text == "")
            {
                MessageBox.Show("Mã đăng nhập không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMADANGNHAP.Focus();
                return;
            }
            if (txtMATKHAU.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMATKHAU.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = db.DangNhapp(txtMADANGNHAP.Text.Trim(), txtMATKHAU.Text.Trim(), cbomodd.Text.ToString());
            if (dt == null || dt.Rows.Count > 0)
            {
                this.Hide();
                frmMain frm = new frmMain();
                username = txtMADANGNHAP.Text.Trim();
                password = txtMATKHAU.Text.Trim();
                mod = cbomodd.Text.ToString();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không đúng tên người dùng hoặc mật khẩu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMADANGNHAP.Focus();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMADANGNHAP.Focus();
            LoadQuyen();
        }
        private void LoadQuyen()
        {
            DataTable dataTable = new DataTable();
            cbomodd.Items.Clear();
            dataTable.Columns.Add("ma", typeof(string));
            dataTable.Columns.Add("ten", typeof(string));
            dataTable.Rows.Add("QUANLY", "Quản trị viên");
            dataTable.Rows.Add("NGUOIDUNG", "Người dùng");
            cbomodd.DataSource = dataTable;
            cbomodd.DisplayMember = "ten";
            cbomodd.ValueMember = "ma";
        }
        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lkdangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          frmDangKy dk = new frmDangKy();
            dk.ShowDialog();
        }
    }
}
