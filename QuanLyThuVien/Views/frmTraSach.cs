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
    public partial class frmTraSach : Form
    {
        MuonSachControllers db = new MuonSachControllers();
        DataTable dt;
        DataTable dt2;
        public frmTraSach()
        {
            InitializeComponent();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
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
        private void HienThiPHIEUMUONTRA()
        {
            dt = db.HienThiPHIEUMUONTRA(dtNGAYLAP.Value.ToString("yyyyMMdd"), "1");
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

        private void dtGVPHIEUMUONTRA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtGVPHIEUMUONTRA.Rows[e.RowIndex];
                HienThiCHITIETPHIEU(row.Cells[0].Value.ToString());
            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtGVPHIEUMUONTRA.RowCount == 0)
            {
                MessageBox.Show("Không có thông tin mượn sách.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn trả sách không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DataGridViewRow row = this.dtGVPHIEUMUONTRA.Rows[dtGVPHIEUMUONTRA.CurrentCell.RowIndex];
                db.TraSach(row.Cells[0].Value.ToString());
                MessageBox.Show("Trả sách thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
                return;
            
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
