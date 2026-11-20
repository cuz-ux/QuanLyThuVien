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
    public partial class frmThongTinSach : Form
    {
        SachControllers db = new SachControllers();
        public frmThongTinSach()
        {
            InitializeComponent();
        }

        private void frmThongTinSach_Load(object sender, EventArgs e)
        {
            if (frmQuanLySach.save == false)
            {
                txtMASACH.Text = frmQuanLySach.MASACH;
                txtTENSACH.Text = frmQuanLySach.TENSACH;
                txtTENTACGIA.Text = frmQuanLySach.TENTACGIA;
                txtNHAXB.Text = frmQuanLySach.NHAXB;
                txtCHUDE.Text = frmQuanLySach.CHUDE;
                nmSOLUONG.Value = frmQuanLySach.SOLUONG;
                nmDONGIA.Value = frmQuanLySach.DONGIA;
                nmNAMXB.Value = frmQuanLySach.NAMXB;
                txtGHICHU.Text = frmQuanLySach.GHICHU;

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMASACH.Text == "")
            {
                MessageBox.Show("Mã sách không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMASACH.Focus();
                return;
            }
            if (txtTENSACH.Text == "")
            {
                MessageBox.Show("Tên sách không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTENSACH.Focus();
                return;
            }
            if (nmSOLUONG.Value == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmSOLUONG.Focus();
                return;
            }
            
            if (frmQuanLySach.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMASACH.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Sách này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMASACH.Text.Trim(), txtTENSACH.Text.Trim(), txtTENTACGIA.Text.Trim(), txtNHAXB.Text.Trim(), txtCHUDE.Text.Trim(), nmSOLUONG.Value,nmDONGIA.Value,nmNAMXB.Value, txtGHICHU.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLySach.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMASACH.Text) == 0 && txtMASACH.Text != frmQuanLySach.MASACH)
                {
                    MessageBox.Show("Sửa thất bại, Sách này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMASACH.Text.Trim(),frmQuanLySach.MASACH, txtTENSACH.Text.Trim(), txtTENTACGIA.Text.Trim(), txtNHAXB.Text.Trim(), txtCHUDE.Text.Trim(), nmSOLUONG.Value, nmDONGIA.Value, nmNAMXB.Value, txtGHICHU.Text.Trim());
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
