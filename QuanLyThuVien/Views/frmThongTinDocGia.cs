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

namespace QuanLyThuVien.Views
{
    public partial class frmThongTinDocGia : Form
    {
        DocgiaControllers db = new DocgiaControllers();
        public frmThongTinDocGia()
        {
            InitializeComponent();
        }

        private void frmThongTinDocGia_Load(object sender, EventArgs e)
        {
            if (frmQuanLyDocGia.save == false)
            {
                HienThiGioiTinh();
                txtMADOCGIA.Text = frmQuanLyDocGia.MADOCGIA;
                txtHOTEN.Text = frmQuanLyDocGia.HOTEN;
                cboGIOITINH.Text = frmQuanLyDocGia.GIOITINH;
                txtDIACHI.Text = frmQuanLyDocGia.DIACHI;
                txtDOITUONGDOCGIA.Text = frmQuanLyDocGia.DOITUONGDOCGIA;
                txtGHICHU.Text = frmQuanLyDocGia.GHICHU;
            }
            else
            {
                HienThiGioiTinh();
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMADOCGIA.Text == "")
            {
                MessageBox.Show("Mã độc giả không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMADOCGIA.Focus();
                return;
            }
            if (txtHOTEN.Text == "")
            {
                MessageBox.Show("Tên độc giả không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHOTEN.Focus();
                return;
            }

            if (frmQuanLyDocGia.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMADOCGIA.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Độc giả này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMADOCGIA.Text.Trim(), txtHOTEN.Text.Trim(),cboGIOITINH.SelectedValue.ToString(), txtDIACHI.Text.Trim(), txtDOITUONGDOCGIA.Text.Trim(), txtGHICHU.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyDocGia.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMADOCGIA.Text) == 0 && txtMADOCGIA.Text != frmQuanLyDocGia.MADOCGIA)
                {
                    MessageBox.Show("Sửa thất bại, Sách này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMADOCGIA.Text.Trim(),frmQuanLyDocGia.MADOCGIA, txtHOTEN.Text.Trim(), cboGIOITINH.SelectedValue.ToString(), txtDIACHI.Text.Trim(), txtDOITUONGDOCGIA.Text.Trim(), txtGHICHU.Text.Trim());
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void frmThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
