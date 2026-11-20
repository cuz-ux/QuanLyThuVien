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
    public partial class frmQuanLySach : Form
    {
        SachControllers db = new SachControllers();
        DataTable dt;
        public static Boolean save;
        public static string MASACH;
        public static string TENSACH;
        public static string TENTACGIA;
        public static string NHAXB;
        public static string CHUDE;
        public static int SOLUONG;
        public static int DONGIA;
        public static int NAMXB;
        public static string GHICHU;
        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            HienThiSach();
        }
        private void HienThiSach()
        {
            dt = db.HienThi(txtTen.Text);
            dtGVSach.DataSource = dt;
            dtGVSach.Columns[0].HeaderText = "Mã sách";
            dtGVSach.Columns[1].HeaderText = "Tên sách";
            dtGVSach.Columns[2].HeaderText = "Tên tác giả";
            dtGVSach.Columns[3].HeaderText = "Nhà xuất bản";
            dtGVSach.Columns[4].HeaderText = "Chủ đề";
            dtGVSach.Columns[5].HeaderText = "Số lượng";
            dtGVSach.Columns[6].HeaderText = "Đơn giá";
            dtGVSach.Columns[7].HeaderText = "Năm xuất bản";
            dtGVSach.Columns[8].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVSach);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmThongTinSach frm = new frmThongTinSach();
            frm.Text = "Thêm mới sách";
            frm.ShowDialog();
            HienThiSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtGVSach.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtGVSach.Rows[dtGVSach.CurrentCell.RowIndex];
           

            save = false;
            frmThongTinSach frm = new frmThongTinSach();
            MASACH = row.Cells[0].Value.ToString();
            TENSACH = row.Cells[1].Value.ToString();
            TENTACGIA = row.Cells[2].Value.ToString();
            NHAXB = row.Cells[3].Value.ToString();
            CHUDE = row.Cells[4].Value.ToString();
            SOLUONG = int.Parse(row.Cells[5].Value.ToString());
            DONGIA = int.Parse(row.Cells[6].Value.ToString());
            NAMXB = int.Parse(row.Cells[7].Value.ToString());
            GHICHU = row.Cells[8].Value.ToString();
            frm.Text = "Sửa thông tin sách";
            frm.ShowDialog();
            HienThiSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVSach.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(dtGVSach.Rows[dtGVSach.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiSach();
            }
            else
                return;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiSach();
        }
    }
}
