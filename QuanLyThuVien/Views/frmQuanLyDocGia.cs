using QuanLyThuVien.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLyThuVien.Views
{
    public partial class frmQuanLyDocGia : Form
    {
        DocgiaControllers db = new DocgiaControllers();
        DataTable dt;
        public static Boolean save;
        public static string MADOCGIA;
        public static string HOTEN;
        public static string GIOITINH;
        public static string DIACHI;
        public static string DOITUONGDOCGIA;
        public static string GHICHU;
        public frmQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void frmQuanLyDocGia_Load(object sender, EventArgs e)
        {
            HienThiDocGia();
        }
        private void HienThiDocGia()
        {
            dt = db.HienThi(txtTen.Text);
            dtGVDocGia.DataSource = dt;
            dtGVDocGia.Columns[0].HeaderText = "Mã độc giả";
            dtGVDocGia.Columns[1].HeaderText = "Tên độc giả";
            dtGVDocGia.Columns[2].HeaderText = "Giới tính";
            dtGVDocGia.Columns[3].HeaderText = "Địa chỉ";
            dtGVDocGia.Columns[4].HeaderText = "Đối tượng độc giả";
            dtGVDocGia.Columns[5].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVDocGia);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmThongTinDocGia frm = new frmThongTinDocGia();
            frm.Text = "Thêm mới độc giả";
            frm.ShowDialog();
            HienThiDocGia();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtGVDocGia.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtGVDocGia.Rows[dtGVDocGia.CurrentCell.RowIndex];


            save = false;
            frmThongTinDocGia frm = new frmThongTinDocGia();
            MADOCGIA = row.Cells[0].Value.ToString();
            HOTEN = row.Cells[1].Value.ToString();
            GIOITINH = row.Cells[2].Value.ToString();
            DIACHI = row.Cells[3].Value.ToString();
            DOITUONGDOCGIA = row.Cells[4].Value.ToString();
            GHICHU = row.Cells[5].Value.ToString();
            frm.Text = "Sửa thông tin độc giả";
            frm.ShowDialog();
            HienThiDocGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVDocGia.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(dtGVDocGia.Rows[dtGVDocGia.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiDocGia();
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDocGia();
        }
    }
}
