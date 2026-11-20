using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    public class TaiKhoanNhanVienControllers
    {
        public DataTable DangNhapp(string MaTK_NV, string MatKhau, string mod)
        {
            string Query = "select * from TAIKHOAN_NHANVIEN where MANHANVIEN ='" + MaTK_NV + "' and MATKHAU='" + MatKhau + "' and mod = N'" + mod + "'";
            return DB_Connect.Load(Query);
        }
        public DataTable ThongTinCaNhan(string MaTK_NV)
        {
            string sqlString = "select * from TAIKHOAN_NHANVIEN where MANHANVIEN='" + MaTK_NV + "'";
            return DB_Connect.Load(sqlString);
        }
        public DataTable HienThi(string HOTEN)
        {
            string Query = "select MANHANVIEN,HOTEN,NAMSINH,GIOITINH,SDT,GHICHU from TAIKHOAN_NHANVIEN where HOTEN like N'%"+ HOTEN + "%'";
            return DB_Connect.Load(Query);
        }
        public DataTable TimKiem(string TenTK_NV)
        {
            string sqlString = "select MANHANVIEN,HOTEN,NAMSINH,GIOITINH,SDT,GHICHU from TAIKHOAN_NHANVIEN WHERE HOTEN  LIKE N'%" + TenTK_NV + "%'";
            return DB_Connect.Load(sqlString);
        }
        public void Them(string MANHANVIEN, string HOTEN, string MATKHAU, string NAMSINH, string GIOITINH, string SDT, string GHICHU, string mod, string state)
        {
            string Query = "INSERT INTO TAIKHOAN_NHANVIEN(MANHANVIEN,HOTEN,MATKHAU,NAMSINH,GIOITINH,SDT,GHICHU,mod,state)  VALUES ( '" + MANHANVIEN + "',N'" + HOTEN + "',N'" + MATKHAU + "','" + NAMSINH + "',N'" + GIOITINH + "','" + SDT + "',N'" + GHICHU + "',N'" + mod + "',N'" + state + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void DangKyTaiKhoan(string MANHANVIEN, string MATKHAU, string mod)
        {
            string Query = "INSERT INTO TAIKHOAN_NHANVIEN(MANHANVIEN,MATKHAU,mod)  VALUES ( '" + MANHANVIEN + "',N'" + MATKHAU + "',N'" + mod + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Sua(string MANHANVIEN, string MANHANVIEN2, string HOTEN, string MATKHAU, string NAMSINH, string GIOITINH, string SDT, string GHICHU, string mod, string state)
        {
            string Query = "UPDATE TAIKHOAN_NHANVIEN SET MANHANVIEN = '" + MANHANVIEN + "',HOTEN=N'" + HOTEN + "',MATKHAU = N'" + MATKHAU + "',NAMSINH='" + NAMSINH + "',GIOITINH =N'" + GIOITINH + "',SDT =N'" + SDT + "',GHICHU =N'" + GHICHU + "',mod = N'" + mod + "',state = N'" + state + "' WHERE MANHANVIEN = '" + MANHANVIEN2 + "'";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaTK_NV)
        {
            string Query = string.Format(@"DELETE TAIKHOAN_NHANVIEN WHERE MANHANVIEN = '" + MaTK_NV + "'");
            DB_Connect.ExecuteNonQuery(Query);
        }
        public int KiemTraDuLieuTonTai(string MaTK_NV)
        {
            int i = 0;
            string Querys = "SELECT * FROM TAIKHOAN_NHANVIEN WHERE MANHANVIEN = '" + MaTK_NV + "'";
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
        public void DoiMatKhau(string MaTK_NV, string MatKhau)
        {
            string Querys = string.Format(@"UPDATE TAIKHOAN_NHANVIEN set MATKHAU = '" + MatKhau + "' where MANHANVIEN = '" + MaTK_NV + "'");
            DB_Connect.ExecuteNonQuery(Querys);
        }
        public DataTable MatKhau(string MaTK_NV)
        {
            string Query = "select MatKhau from TAIKHOAN_NHANVIEN WHERE MANHANVIEN = '" + MaTK_NV + "'";
            return DB_Connect.Load(Query);
        }
    }
}
