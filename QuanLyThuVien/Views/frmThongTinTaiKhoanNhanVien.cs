using QuanLyThuVien.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThuVien.Views
{
    public partial class frmThongTinTaiKhoanNhanVien : Form
    {
        TaiKhoanNhanVienControllers db = new TaiKhoanNhanVienControllers();
        public frmThongTinTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        private void frmThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMANHANVIEN.Text == "")
            {
                MessageBox.Show("Mã tài khoản - nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMANHANVIEN.Focus();
                return;
            }
            if (txtHOTEN.Text == "")
            {
                MessageBox.Show("Họ tên tài khoản - nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHOTEN.Focus();
                return;
            }
            if (txtMATKHAU.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMATKHAU.Focus();
                return;
            }
            if ((txtMATKHAU.Text != txtNLMatKhau.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNLMatKhau.Focus();
                return;
            }
            if (frmQuanLyTaiKhoanNhanVien.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMANHANVIEN.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMANHANVIEN.Text.Trim(), txtHOTEN.Text.Trim(), txtMATKHAU.Text.Trim(), dtNAMSINH.Value.ToString("yyyy/MM/dd"), cboGIOITINH.SelectedValue.ToString(), txtSDT.Text.Trim(), txtGHICHU.Text.Trim(), cbomod.Text.Trim(), cbostate.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            
        }
            if (frmQuanLyTaiKhoanNhanVien.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMANHANVIEN.Text) == 0 && txtMANHANVIEN.Text != frmQuanLyTaiKhoanNhanVien.MANHANVIEN)
                {
                    MessageBox.Show("Sửa thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMANHANVIEN.Text.Trim(), frmQuanLyTaiKhoanNhanVien.MANHANVIEN, txtHOTEN.Text.Trim(), txtMATKHAU.Text.Trim(), dtNAMSINH.Value.ToString("yyyy/MM/dd"), cboGIOITINH.SelectedValue.ToString(), txtSDT.Text.Trim(), txtGHICHU.Text.Trim(), cbomod.Text.Trim(), cbostate.Text.Trim());
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void frmThongTinTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            if(frmQuanLyTaiKhoanNhanVien.save == true)
            {
                HienThiGioiTinh();
            }
            else
            {
                HienThiGioiTinh();
                txtMANHANVIEN.Text = frmQuanLyTaiKhoanNhanVien.MANHANVIEN;
                txtHOTEN.Text = frmQuanLyTaiKhoanNhanVien.HOTEN;
                txtMATKHAU.Text = frmQuanLyTaiKhoanNhanVien.MATKHAU;
                txtNLMatKhau.Text = txtMATKHAU.Text;
                dtNAMSINH.Value = frmQuanLyTaiKhoanNhanVien.NAMSINH;
                cboGIOITINH.Text = frmQuanLyTaiKhoanNhanVien.GIOITINH;
                txtSDT.Text = frmQuanLyTaiKhoanNhanVien.SDT;
                txtGHICHU.Text = frmQuanLyTaiKhoanNhanVien.GHICHU;
                
            }    
        }
        private void HienThiGioiTinh()
        {
            cboGIOITINH.DisplayMember = "Text";
            cboGIOITINH.ValueMember = "Value";
            var items = new[] 
            {
                new { Text = "Nam", Value = "Nam" },
                new { Text = "Nữ", Value = "Nữ" },
            };
            cboGIOITINH.DataSource = items;
        }
    }
}
