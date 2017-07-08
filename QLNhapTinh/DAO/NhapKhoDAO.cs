using QLNhapTinh.VO;
using System.Data;
using System.Data.SqlClient;

namespace QLNhapTinh.DAO
{
    class NhapKhoDAO
    {
        ConnectionOffLine db = null;
        public NhapKhoDAO()
        {
            db = new ConnectionOffLine();
        }
        public DataTable DSNhapKho()
        {
            return db.ExcuteQuery("Select  * From NHAPKHO",
                CommandType.Text, null);

        }
        public DataTable DSCapNhatNhapKho()
        {
            return db.ExcuteQuery("Select  * From NHAPKHO WHERE TINHTRANG=0",
                CommandType.Text, null);

        }
        public DataTable DSNhaMay()
        {
            return db.ExcuteQuery("Select  * From NHAMAY",
                CommandType.Text, null);
        }
        public bool ThemNhapKho(ref string err, NhapKhoVO nk)
        {
            return db.MyExecuteNonQuery("SpThemNhapKho",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@NHAMAY", nk.NHAMAY),
                new SqlParameter("@NGAYNHAP", nk.NGAYNHAP));
        }
        public bool SuaNhapKho(ref string err, NhapKhoVO nk)
        {
            return db.MyExecuteNonQuery("SpSuaNhapKho",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID", nk.ID),
                new SqlParameter("@NHAMAY", nk.NHAMAY),
                new SqlParameter("@NGAYNHAP", nk.NGAYNHAP),
                new SqlParameter("@TINHTRANG", nk.Tinhtrang));
        }
        public DataTable getNhapKho(string nhaMay)
        {
            return db.ExcuteQuery("Select  * From dbo.getNhapKho(N'"+nhaMay+"')",
                CommandType.Text, null);
        }
        public DataTable getToiNgay(string nhaMay,string ngayNhap)
        {
            return db.ExcuteQuery("Select  * From getToiNgay(N'"+nhaMay+"','"+ ngayNhap+ "')",
                CommandType.Text, null);
        }
        public DataTable getNguyenLieu(string tenNguyenLieu)
        {
            return db.ExcuteQuery("Select  * From NGUYENLIEU WHERE NGUYENLIEU='"+tenNguyenLieu+"'",
                CommandType.Text, null);
        }
        public bool XoaNhapKho(ref string err, NhapKhoVO nk)
        {
            return db.MyExecuteNonQuery("SpXoaThanhPham",
                CommandType.StoredProcedure, ref err,
                   new SqlParameter("@ID", nk.ID));
        }
    }
}
