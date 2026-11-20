using QuanLyThuVien.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Views
{
    public partial class frmThongTinMuonSach : Form
    {
        MuonSachControllers db = new MuonSachControllers();
        DocgiaControllers dbdg = new DocgiaControllers();
        TaiKhoanNhanVienControllers dbtknv = new TaiKhoanNhanVienControllers();
        SachControllers dbs= new SachControllers();
        DataTable dtct = new DataTable();
        public Boolean ischeck = true;
        public frmThongTinMuonSach()
        {
            InitializeComponent();
        }
        private void HienThiCHITIETPHIEU()
        {
            dtct = db.HienThiCHITIETPHIEU(txtSOPHIEU.Text.Trim());
            dtGVCHITIETPHIEU.DataSource = dtct;
            dtGVCHITIETPHIEU.Columns[0].HeaderText = "Số phiếu";
            dtGVCHITIETPHIEU.Columns[1].HeaderText = "Mã sách";
            dtGVCHITIETPHIEU.Columns[2].HeaderText = "Tên sách";
            dtGVCHITIETPHIEU.Columns[3].HeaderText = "Số lượng";
            dtGVCHITIETPHIEU.Columns[4].HeaderText = "Ghi chú";
            frmQuanLyTaiKhoanNhanVien.CustomDataGridView(dtGVCHITIETPHIEU);
        }
        private void frmThongTinMuonSach_Load(object sender, EventArgs e)
        {
            if(frmMuonSach.save == true)
            {
                HienThiDocGia();
                txtMANHANVIEN.Text = frmDangNhap.username;
                txtMANHANVIEN.ReadOnly = true;
                HienThiSach();
                HienThiCHITIETPHIEU();
                txtSOPHIEU.ReadOnly = true;
                GenCode();
            }
            else
            {
                txtSOPHIEU.Text = frmMuonSach.SOPHIEU;
                txtMANHANVIEN.ReadOnly = true;
                HienThiDocGia();
                HienThiSach();
                HienThiCHITIETPHIEU();
                txtSOPHIEU.Text = frmMuonSach.SOPHIEU;
                dtNGAYLAP.Value = frmMuonSach.NGAYLAP;
                cboMADOCGIA.SelectedValue = frmMuonSach.MADOCGIA;
                txtMANHANVIEN.Text = frmMuonSach.MANHANVIEN;
                dtNGAYHENTRA.Value = frmMuonSach.NGAYHENTRA;
                txtGHICHU.Text = frmMuonSach.GHICHU;
            }    
        }
        private void GenCode()
        {
            string sTemp = DateTime.Now.ToString("yyMMddhhmmss");
            string sBarcode = sTemp;
            int iSum = 0;
            int iDigit = 0;
            for (int i = sTemp.Length; i >= 1; i += -1)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                    iSum += iDigit * 3;
                else
                    iSum += iDigit * 1;
            }
            int iCheckSum = (10 - (iSum % 10)) % 10;
            sBarcode = "PMT_" + sBarcode + iCheckSum.ToString();
            txtSOPHIEU.Text = sBarcode;
        }
        private void HienThiDocGia()
        {
            DataTable dt = dbdg.HienThi("");
            cboMADOCGIA.DataSource = dt;
            cboMADOCGIA.DisplayMember = "HOTEN";
            cboMADOCGIA.ValueMember = "MADOCGIA";
        }
        
        private void HienThiSach()
        {
            DataTable dt = dbs.HienThi("");
            cboMASACH.DataSource = dt;
            cboMASACH.DisplayMember = "TENSACH";
            cboMASACH.ValueMember = "MASACH";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(cboMASACH.Text == "")
            {
                MessageBox.Show("Mã sách không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMASACH.Focus();
                return;
            }
            if (nmSoLuong.Value == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMASACH.Focus();
                return;
            }
            ischeck = true;
            if (dtGVCHITIETPHIEU.Rows.Count > 0)
            {
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    try
                    {
                        if (dtct.Rows[i]["MASACH"].ToString() == cboMASACH.SelectedValue.ToString())
                        {
                            dtct.Rows[i]["SOLUONG"] = int.Parse(dtct.Rows[i]["SOLUONG"].ToString()) + nmSoLuong.Value;
                            ischeck = false;
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            
            if(ischeck == true)
            {
                DataTable TENSACH = new DataTable();
                TENSACH = dbs.TimKiem2(cboMASACH.SelectedValue.ToString());
                DataRow toInsert = dtct.NewRow();
                dtct.Rows.Add(new Object[]{
                txtSOPHIEU.Text.Trim(),
                cboMASACH.SelectedValue.ToString(),
                TENSACH.Rows[0][0].ToString(),
                nmSoLuong.Value,
                txtGHICHU2.Text.Trim()
           });
            }
            dtct.AcceptChanges();
            dtGVCHITIETPHIEU.DataSource = dtct;
            dtct.AcceptChanges();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtGVCHITIETPHIEU.Rows.Count == 0)
            {
                MessageBox.Show("Chưa nhập sách cần mượn", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int c;
            for (int i = 0; i < dtGVCHITIETPHIEU.RowCount; i++)
            {
                c = db.KiemTraSachTonKho(dtGVCHITIETPHIEU.Rows[0].Cells[1].Value.ToString());
                if (c < int.Parse(dtGVCHITIETPHIEU.Rows[0].Cells[3].Value.ToString()))
                {
                    MessageBox.Show("Thêm thất bại, số lượng tồn của sách '"+ dtGVCHITIETPHIEU.Rows[0].Cells[1].Value.ToString() + "' còn lại là '"+c+"'", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (frmMuonSach.save == true)
            {
                db.ThemPHIEUMUONTRA(txtSOPHIEU.Text.Trim(), dtNGAYLAP.Value.ToString("yyyy/MM/dd"), cboMADOCGIA.SelectedValue.ToString(),txtMANHANVIEN.Text.Trim(), dtNGAYHENTRA.Value.ToString("yyyy/MM/dd"),"0",txtGHICHU.Text.Trim());
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    db.ThemCHITIETPHIEU(txtSOPHIEU.Text.Trim(), dtct.Rows[i]["MASACH"].ToString(), decimal.Parse(dtct.Rows[i]["SOLUONG"].ToString()), dtct.Rows[i]["GHICHU"].ToString());
                }

                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmMuonSach.save == false)
            {
                db.SuaPHIEUMUONTRA(txtSOPHIEU.Text.Trim(), dtNGAYLAP.Value.ToString("yyyy/MM/dd"), cboMADOCGIA.SelectedValue.ToString(), txtMANHANVIEN.Text.Trim(), dtNGAYHENTRA.Value.ToString("yyyy/MM/dd"), "0", txtGHICHU.Text.Trim());
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    db.ThemCHITIETPHIEU(txtSOPHIEU.Text.Trim(), dtct.Rows[i]["MASACH"].ToString(), decimal.Parse(dtct.Rows[i]["SOLUONG"].ToString()), dtct.Rows[i]["GHICHU"].ToString());
                }
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            dtGVCHITIETPHIEU.Rows.RemoveAt(dtGVCHITIETPHIEU.CurrentCell.RowIndex);

            dtGVCHITIETPHIEU.DataSource = dtct;
            dtct.AcceptChanges();
        }

        private void frmThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
