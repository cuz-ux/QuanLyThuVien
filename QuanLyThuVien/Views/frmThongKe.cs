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
    public partial class frmThongKe : Form
    {
        ThongKeControllers db = new ThongKeControllers();
        DataTable dt = new DataTable();
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            HienThiPHIEUMUONTRA();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();

            dt2 = db.SLDS();
            dt3 = db.SLC();
            dt4 = db.SLM();
            dt5 = db.SLCL();
            dt6 = db.SLTGT();
            dt7 = db.SLDG();
            if(dt2 != null)
            {
                txtSLDS.Text = dt2.Rows[0][0].ToString();
            }
            if (dt3 != null)
            {
                txtSLC.Text = dt3.Rows[0][0].ToString();
            }
            if (dt4 != null)
            {
                txtSLM.Text = dt4.Rows[0][0].ToString();
            }
            if (dt5 != null)
            {
                txtSLCL.Text = dt5.Rows[0][0].ToString();
            }
            if (dt6 != null)
            {
                txtSLTGT.Text = dt6.Rows[0][0].ToString();
            }
            if (dt7 != null)
            {
                txtSLDG.Text = dt7.Rows[0][0].ToString();
            }
        }
        private void HienThiPHIEUMUONTRA()
        {
            dt = db.HienThiPHIEUMUONQUAHAN();
            dtGVPM.DataSource = dt;
            dtGVPM.Columns[0].HeaderText = "Số phiếu";
            dtGVPM.Columns[1].HeaderText = "Ngày lập";
            dtGVPM.Columns[2].HeaderText = "Mã độc giả";
            dtGVPM.Columns[3].HeaderText = "Tên độc giả";
            dtGVPM.Columns[4].HeaderText = "Mã nhân viên";
            dtGVPM.Columns[5].HeaderText = "Tên nhân viên";
            dtGVPM.Columns[6].HeaderText = "Ngày hẹn trả";
            dtGVPM.Columns[7].HeaderText = "Tình trạng kết thúc";
            dtGVPM.Columns[8].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVPM);
        }
    }
}
