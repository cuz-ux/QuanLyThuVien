using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    public class ThongKeControllers
    {
        public DataTable SLDS()
        {
            string Query = "SELECT COUNT(*) AS SL FROM SACH ";
            return DB_Connect.Load(Query);
        }
        public DataTable SLC()
        {
            string Query = "SELECT SUM(SOLUONG) AS SL FROM SACH  ";
            return DB_Connect.Load(Query);
        }
        public DataTable SLM()
        {
            string Query = "SELECT SUM(b.SOLUONG) AS SL FROM CHITIETPHIEU b INNER JOIN PHIEUMUONTRA c ON b.SOPHIEU = c.SOPHIEU WHERE TINHTRANGKETTHUC = '0'";
            return DB_Connect.Load(Query);
        }
        public DataTable SLCL()
        {
            string Query = "select (SELECT SUM(SOLUONG) AS SL FROM SACH) - (SELECT SUM(b.SOLUONG) AS SL FROM CHITIETPHIEU b INNER JOIN PHIEUMUONTRA c ON b.SOPHIEU = c.SOPHIEU WHERE TINHTRANGKETTHUC = '0') ";
            return DB_Connect.Load(Query);
        }
        public DataTable SLTGT()
        {
            string Query = "SELECT SUM(DONGIA) AS SL FROM SACH ";
            return DB_Connect.Load(Query);
        }
        public DataTable SLDG()
        {
            string Query = "SELECT COUNT(*) AS SL FROM DOCGIA ";
            return DB_Connect.Load(Query);
        }
        public DataTable HienThiPHIEUMUONQUAHAN()
        {
            string Query = "select SOPHIEU,NGAYLAP,a.MADOCGIA,c.HOTEN,a.MANHANVIEN,b.HOTEN,NGAYHENTRA,TINHTRANGKETTHUC,a.GHICHU ";
            Query += " from PHIEUMUONTRA a INNER JOIN TAIKHOAN_NHANVIEN b ON a.MANHANVIEN = b.MANHANVIEN";
            Query += " INNER JOIN DOCGIA c ON a.MADOCGIA = c.MADOCGIA WHERE CONVERT(varchar,NGAYHENTRA,112) < '" + DateTime.Now.ToString("yyyyMMdd") + "'";
            Query += " AND TINHTRANGKETTHUC = '0'";
            return DB_Connect.Load(Query);
        }
    }
}
