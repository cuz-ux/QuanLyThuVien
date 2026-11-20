using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Controllers
{
    public class SachControllers
    {
        public DataTable HienThi(string tensach)
        {
            string Query = "select * from SACH where TENSACH like N'%"+ tensach + "%'";
            return DB_Connect.Load(Query);
        }
        public DataTable TimKiem(string TENSACH)
        {
            string sqlString = "select * from SACH WHERE TENSACH  LIKE N'%" + TENSACH + "%'";
            return DB_Connect.Load(sqlString);
        }
        public DataTable TimKiem2(string MASACH)
        {
            string sqlString = "select TENSACH from SACH WHERE MASACH  = N'" + MASACH + "'";
            return DB_Connect.Load(sqlString);
        }
        public void Them(string MASACH, string TENSACH, string TENTACGIA, string NHAXB, string CHUDE, decimal SOLUONG, decimal DONGIA, decimal NAMXB,string GHICHU)
        {
            string Query = "INSERT INTO SACH(MASACH,TENSACH,TENTACGIA,NHAXB,CHUDE,SOLUONG,DONGIA,NAMXB,GHICHU)  VALUES ( '" + MASACH + "',N'" + TENSACH + "',N'" + TENTACGIA + "',N'" + NHAXB + "',N'" + CHUDE + "',"+ SOLUONG + ","+ DONGIA + "," + NAMXB + ",N'" + GHICHU + "')";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Sua(string MASACH, string MASACH2, string TENSACH, string TENTACGIA, string NHAXB, string CHUDE, decimal SOLUONG, decimal DONGIA, decimal NAMXB, string GHICHU)
        {
            string Query = "UPDATE SACH SET MASACH = '" + MASACH + "',TENSACH=N'" + TENSACH + "',TENTACGIA = N'" + TENTACGIA + "',NHAXB=N'" + NHAXB + "',CHUDE =N'" + CHUDE + "',SOLUONG =" + SOLUONG + ",DONGIA="+ DONGIA + ",NAMXB="+ NAMXB + ",GHICHU =N'" + GHICHU + "' WHERE MASACH = '" + MASACH2 + "'";
            DB_Connect.ExecuteNonQuery(Query);
        }
        public void Xoa(string MASACH)
        {
            string Query = string.Format(@"DELETE SACH WHERE MASACH = '" + MASACH + "'");
            DB_Connect.ExecuteNonQuery(Query);
        }
        public int KiemTraDuLieuTonTai(string MASACH)
        {
            int i = 0;
            string Querys = "SELECT * FROM SACH WHERE MASACH = '" + MASACH + "'";
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
