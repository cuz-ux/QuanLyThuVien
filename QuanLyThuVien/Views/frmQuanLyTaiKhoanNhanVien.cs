using QuanLyThuVien.Controllers;
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
    public partial class frmQuanLyTaiKhoanNhanVien : Form
    {
        TaiKhoanNhanVienControllers db = new TaiKhoanNhanVienControllers();
        DataTable dt;
        public static Boolean save;
        public static string MANHANVIEN;
        public static string HOTEN;
        public static DateTime NAMSINH;
        public static string GIOITINH;
        public static string SDT;
        public static string GHICHU;
        public static string MATKHAU;
        public frmQuanLyTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            HienThiTaiKhoan();
        }
        private void HienThiTaiKhoan()
        {
            dt = db.HienThi(txtTenTK_NV.Text);
            dtGVTK.DataSource = dt;
            dtGVTK.Columns[0].HeaderText = "Mã nhân viên";
            dtGVTK.Columns[1].HeaderText = "Họ tên";
            dtGVTK.Columns[2].HeaderText = "Năm sinh";
            dtGVTK.Columns[3].HeaderText = "Giới tính";
            dtGVTK.Columns[4].HeaderText = "SĐT";
            dtGVTK.Columns[5].HeaderText = "Ghi chú";
            CustomDataGridView(dtGVTK);
        }
        public static void CustomDataGridView(DataGridView dgvMain)
        {
            dgvMain.AllowUserToAddRows = false;
            dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMain.ColumnHeadersHeight = 30;
            dgvMain.ReadOnly = true;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmThongTinTaiKhoanNhanVien frm = new frmThongTinTaiKhoanNhanVien();
            frm.Text = "Thêm mới tài khoản - nhân viên";
            frm.ShowDialog();
            HienThiTaiKhoan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtGVTK.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtGVTK.Rows[dtGVTK.CurrentCell.RowIndex];
            if (dtGVTK.Rows[dtGVTK.CurrentCell.RowIndex].Cells[0].Value.ToString() == "AD")
            {
                MessageBox.Show("Không được phép sửa dữ liệu ADMIN", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            save = false;
            frmThongTinTaiKhoanNhanVien frm = new frmThongTinTaiKhoanNhanVien();
            MANHANVIEN = row.Cells[0].Value.ToString();
            DataTable dt2 = db.MatKhau(row.Cells[0].Value.ToString());
            MATKHAU = dt2.Rows[0]["MatKhau"].ToString();
            HOTEN = row.Cells[1].Value.ToString();
            NAMSINH = DateTime.Parse(row.Cells[2].Value.ToString());
            GIOITINH = row.Cells[3].Value.ToString();
            SDT = row.Cells[4].Value.ToString();
            GHICHU = row.Cells[5].Value.ToString();
            frm.Text = "Sửa thông tin tài khoản - nhân viên";
            frm.ShowDialog();
            HienThiTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVTK.Rows.Count == 0)
            {
                return;
            }
            if (dtGVTK.Rows[dtGVTK.CurrentCell.RowIndex].Cells[0].Value.ToString() == "AD")
            {
                MessageBox.Show("Không được phép xóa dữ liệu ADMIN", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(dtGVTK.Rows[dtGVTK.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiTaiKhoan();
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiTaiKhoan();
        }
    }
}
