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
    public partial class frmMuonSach : Form
    {
        MuonSachControllers db = new MuonSachControllers();
        DataTable dt;
        DataTable dt2;
        public static Boolean save;
        public static string SOPHIEU;
        public static DateTime NGAYLAP;
        public static string MADOCGIA;
        public static string MANHANVIEN;
        public static DateTime NGAYHENTRA;
        public static string GHICHU;
        public frmMuonSach()
        {
            InitializeComponent();
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            HienThiPHIEUMUONTRA();
            if(dtGVPHIEUMUONTRA.Rows.Count > 0)
            {
                var row = this.dtGVPHIEUMUONTRA.Rows[0];
                HienThiCHITIETPHIEU(row.Cells["SOPHIEU"].Value.ToString());
            }
            else
            {
                HienThiCHITIETPHIEU("");
            }

        }
        private void HienThiPHIEUMUONTRA()
        {
            dt = db.HienThiPHIEUMUONTRA(dtNGAYLAP.Value.ToString("yyyyMMdd"),"0");
            dtGVPHIEUMUONTRA.DataSource = dt;
            dtGVPHIEUMUONTRA.Columns[0].HeaderText = "Số phiếu";
            dtGVPHIEUMUONTRA.Columns[1].HeaderText = "Ngày lập";
            dtGVPHIEUMUONTRA.Columns[2].HeaderText = "Mã độc giả";
            dtGVPHIEUMUONTRA.Columns[3].HeaderText = "Tên độc giả";
            dtGVPHIEUMUONTRA.Columns[4].HeaderText = "Mã nhân viên";
            dtGVPHIEUMUONTRA.Columns[5].HeaderText = "Tên nhân viên";
            dtGVPHIEUMUONTRA.Columns[6].HeaderText = "Ngày hẹn trả";
            dtGVPHIEUMUONTRA.Columns[7].HeaderText = "Tình trạng kết thúc";
            dtGVPHIEUMUONTRA.Columns[8].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVPHIEUMUONTRA);
        }
        private void HienThiCHITIETPHIEU(string value)
        {
            dt2 = db.HienThiCHITIETPHIEU(value);
            dtGVCHITIETPHIEU.DataSource = dt2;
            dtGVCHITIETPHIEU.Columns[0].HeaderText = "Số phiếu";
            dtGVCHITIETPHIEU.Columns[1].HeaderText = "Mã sách";
            dtGVCHITIETPHIEU.Columns[2].HeaderText = "Tên sách";
            dtGVCHITIETPHIEU.Columns[3].HeaderText = "Số lượng";
            dtGVCHITIETPHIEU.Columns[4].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVCHITIETPHIEU);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmThongTinMuonSach frm = new frmThongTinMuonSach();
            frm.Text = "Thêm mới phiếu mượn";
            frm.ShowDialog();
            HienThiPHIEUMUONTRA();
            if (dtGVPHIEUMUONTRA.Rows.Count > 0)
            {
                var row = this.dtGVPHIEUMUONTRA.Rows[0];
                HienThiCHITIETPHIEU(row.Cells["SOPHIEU"].Value.ToString());
            }
            else
            {
                HienThiCHITIETPHIEU("");
            }
        }

        private void dtGVPHIEUMUONTRA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtGVPHIEUMUONTRA.Rows[e.RowIndex];
                HienThiCHITIETPHIEU(row.Cells[0].Value.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtGVPHIEUMUONTRA.Rows.Count == 0)
            {
                return;
            }
            
            DataGridViewRow row = this.dtGVPHIEUMUONTRA.Rows[dtGVPHIEUMUONTRA.CurrentCell.RowIndex];
            save = false;
            frmThongTinMuonSach frm = new frmThongTinMuonSach();
            SOPHIEU = row.Cells[0].Value.ToString();
            NGAYLAP = DateTime.Parse(row.Cells[1].Value.ToString());
            MADOCGIA = row.Cells[2].Value.ToString();
            MANHANVIEN = row.Cells[4].Value.ToString();
            NGAYHENTRA = DateTime.Parse(row.Cells[6].Value.ToString());
            GHICHU = row.Cells[8].Value.ToString();
            frm.Text = "Sửa phiếu mượn";
            if (db.KiemTraDuLieuTonTai(SOPHIEU) == 0)
            {
                MessageBox.Show("Không thể sửa phiếu, Phiếu này đã được trả.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frm.ShowDialog();
            HienThiPHIEUMUONTRA();
            if (dtGVPHIEUMUONTRA.Rows.Count > 0)
            {
                var row2 = this.dtGVPHIEUMUONTRA.Rows[0];
                HienThiCHITIETPHIEU(row2.Cells["SOPHIEU"].Value.ToString());
            }
            else
            {
                HienThiCHITIETPHIEU("");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVPHIEUMUONTRA.Rows.Count == 0)
            {
                return;
            }
            if (db.KiemTraDuLieuTonTai(dtGVPHIEUMUONTRA.Rows[dtGVPHIEUMUONTRA.CurrentCell.RowIndex].Cells[0].Value.ToString()) == 0)
            {
                MessageBox.Show("Không thể xóa phiếu, Phiếu này đã được trả.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(dtGVPHIEUMUONTRA.Rows[dtGVPHIEUMUONTRA.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiPHIEUMUONTRA();
                if (dtGVPHIEUMUONTRA.Rows.Count > 0)
                {
                    var row2 = this.dtGVPHIEUMUONTRA.Rows[0];
                    HienThiCHITIETPHIEU(row2.Cells["SOPHIEU"].Value.ToString());
                }
                else
                {
                    HienThiCHITIETPHIEU("");
                }    
            }
            else
                return;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiPHIEUMUONTRA();
            if (dtGVPHIEUMUONTRA.Rows.Count > 0)
            {
                var row2 = this.dtGVPHIEUMUONTRA.Rows[0];
                HienThiCHITIETPHIEU(row2.Cells["SOPHIEU"].Value.ToString());
            }
            else
            {
                HienThiCHITIETPHIEU("");
            }
        }
    }
}
