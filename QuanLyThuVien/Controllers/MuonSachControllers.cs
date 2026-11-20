using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    public class MuonSachControllers
    {
        public DataTable HienThiPHIEUMUONTRA(string NGAYLAP,string status)
        {
            string Query = "select SOPHIEU,NGAYLAP,a.MADOCGIA,c.HOTEN,a.MANHANVIEN,b.HOTEN,NGAYHENTRA,TINHTRANGKETTHUC,a.GHICHU ";
            Query += " from PHIEUMUONTRA a INNER JOIN TAIKHOAN_NHANVIEN b ON a.MANHANVIEN = b.MANHANVIEN";
            Query += " INNER JOIN DOCGIA c ON a.MADOCGIA = c.MADOCGIA WHERE CONVERT(varchar,NGAYLAP,112) = '" + NGAYLAP + "'";
            if(status == "1")
            {
                Query += " AND TINHTRANGKETTHUC = '0'";
            }    
            return DB_Connect.Load(Query);
        }
    
        public DataTable HienThiCHITIETPHIEU(string SOPHIEU)
            {
                string Query = "select SOPHIEU,a.MASACH,TENSACH,a.SOLUONG,b.GHICHU from CHITIETPHIEU a INNER JOIN SACH b ON a.MASACH = b.MASACH WHERE SOPHIEU = '" + SOPHIEU + "'";
                return DB_Connect.Load(Query);
            }
        public void ThemPHIEUMUONTRA(string SOPHIEU, string NGAYLAP, string MADOCGIA, string MANHANVIEN, string NGAYHENTRA, string TINHTRANGKETTHUC, string GHICHU)
        {
            string Query = "INSERT INTO PHIEUMUONTRA(SOPHIEU,NGAYLAP,MADOCGIA,MANHANVIEN,NGAYHENTRA,TINHTRANGKETTHUC,GHICHU)  VALUES ( '" + SOPHIEU + "','" + NGAYLAP + "','" + MADOCGIA + "','" + MANHANVIEN + "','" + NGAYHENTRA + "','0',N'" + GHICHU + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void TraSach(string SOPHIEU)
        {
            string Query = "UPDATE PHIEUMUONTRA SET TINHTRANGKETTHUC = '1' WHERE SOPHIEU = '"+ SOPHIEU + "'";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void ThemCHITIETPHIEU(string SOPHIEU, string MASACH, decimal SOLUONG, string GHICHU)
        {
            string Query = "DELETE CHITIETPHIEU WHERE SOPHIEU = '"+ SOPHIEU + "'";
            Query += " INSERT INTO CHITIETPHIEU(SOPHIEU,MASACH,SOLUONG,GHICHU)  VALUES ( '" + SOPHIEU + "','" + MASACH + "'," + SOLUONG + ",N'" + GHICHU + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void SuaPHIEUMUONTRA(string SOPHIEU, string NGAYLAP, string MADOCGIA, string MANHANVIEN, string NGAYHENTRA, string TINHTRANGKETTHUC, string GHICHU)
        {
            string Query = "UPDATE PHIEUMUONTRA SET NGAYLAP='" + NGAYLAP + "',MADOCGIA = '" + MADOCGIA + "',MANHANVIEN='" + MANHANVIEN + "',NGAYHENTRA ='" + NGAYHENTRA + "',GHICHU =N'" + GHICHU + "' WHERE SOPHIEU = '" + SOPHIEU + "'";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Xoa(string SOPHIEU)
        {
            string Query = string.Format(@"DELETE CHITIETPHIEU WHERE SOPHIEU = '" + SOPHIEU + "'");
            Query += string.Format(@"DELETE PHIEUMUONTRA WHERE SOPHIEU = '" + SOPHIEU + "'");
            DB_Connect.ExecuteNonQuery(Query);
        }
        public int KiemTraDuLieuTonTai(string SOPHIEU)
        {
            int i = 0;
            string Querys = "SELECT * FROM PHIEUMUONTRA WHERE TINHTRANGKETTHUC = '1' AND SOPHIEU = '" + SOPHIEU + "'";
            DataTable dt = DB_Connect.Load(Querys);
            if (dt == null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
        public int KiemTraSachTonKho(string MASACH)
        {
            int i = 0;
            string Querys = " DECLARE @r INT,@r1 INT, @r2 INT";
            Querys += " SET @r1 = (SELECT SOLUONG FROM SACH WHERE MASACH = '"+ MASACH + "')";
            Querys += " SET @r2 = (SELECT SUM(SOLUONG) FROM CHITIETPHIEU a INNER JOIN PHIEUMUONTRA b ON a.SOPHIEU = b.SOPHIEU";
            Querys += " WHERE MASACH = '"+ MASACH + "' AND TINHTRANGKETTHUC = '0')";
            Querys += " IF @r1 IS NULL SET @r1 = 0";
            Querys += " IF @r2 IS NULL SET @r2 = 0";
            Querys += " SET @r = @r1 - @r2";
            Querys += " SELECT @r";  
            DataTable dt = DB_Connect.Load(Querys);
            if (dt.Rows.Count > 0)
            {
                i = int.Parse(dt.Rows[0][0].ToString());
            }
            return i;
        }
    }
}
