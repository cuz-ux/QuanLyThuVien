using System;
using QuanLyThuVien.Controllers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Views
{
    public partial class frmDangKy : Form
    {
        TaiKhoanNhanVienControllers db = new TaiKhoanNhanVienControllers();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            if (txtMADANGNHAP.Text == "")
            {

                txtMADANGNHAP.Focus();
                return;
            }

            if (txtretype.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtretype.Focus();
                return;
            }
            if (txtretype.Text.Trim() != txtMATKHAU.Text.Trim())
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMATKHAU.Focus();
                return;
            }
            if (db.KiemTraDuLieuTonTai(txtMADANGNHAP.Text) == 0)
            {
                MessageBox.Show("Thêm thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.DangKyTaiKhoan(txtMADANGNHAP.Text.Trim(), txtretype.Text.Trim(), cbomodd.Text.ToString());
            MessageBox.Show("Đăng ký tài khoản thành công, hãy dăng nhập vào phần mềm. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
