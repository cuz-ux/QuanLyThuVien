using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    public class DocgiaControllers
    {
        public DataTable HienThi(string hoten)
        {
            string Query = "select * from DOCGIA WHERE HOTEN like N'%"+ hoten + "%'";
            return DB_Connect.Load(Query);
        }
        public DataTable TimKiem(string HOTEN)
        {
            string sqlString = "select * from DOCGIA WHERE HOTEN  LIKE N'%" + HOTEN + "%'";
            return DB_Connect.Load(sqlString);
        }
        public void Them(string MADOCGIA, string HOTEN, string GIOITINH, string DIACHI, string DOITUONGDOCGIA, string GHICHU)
        {
            string Query = "INSERT INTO DOCGIA(MADOCGIA,HOTEN,GIOITINH,DIACHI,DOITUONGDOCGIA,GHICHU)  VALUES ( '" + MADOCGIA + "',N'" + HOTEN + "',N'" + GIOITINH + "',N'" + DIACHI + "',N'" + DOITUONGDOCGIA + "',N'" + GHICHU + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Sua(string MADOCGIA,string MADOCGIA2, string HOTEN, string GIOITINH, string DIACHI, string DOITUONGDOCGIA, string GHICHU)
        {
            string Query = "UPDATE DOCGIA SET MADOCGIA = '" + MADOCGIA + "',HOTEN=N'" + HOTEN + "',GIOITINH = N'" + GIOITINH + "',DIACHI=N'" + DIACHI + "',DOITUONGDOCGIA =N'" + DOITUONGDOCGIA + "',GHICHU =N'" + GHICHU + "' WHERE MADOCGIA = '" + MADOCGIA2 + "'";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Xoa(string MADOCGIA)
        {
            string Query = string.Format(@"DELETE DOCGIA WHERE MADOCGIA = '" + MADOCGIA + "'");
            DB_Connect.ExecuteNonQuery(Query);
        }
        public int KiemTraDuLieuTonTai(string MADOCGIA)
        {
            int i = 0;
            string Querys = "SELECT * FROM DOCGIA WHERE MADOCGIA = '" + MADOCGIA + "'";
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
    }
}
