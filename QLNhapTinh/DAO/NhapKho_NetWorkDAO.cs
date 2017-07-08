using QLNhapTinh.VO;
using System.Data;
using System.Data.SqlClient;

namespace QLNhapTinh.DAO
{
    class NhapKho_NetWorkDAO
    {
        ConnectionNetWork db = null;
        public NhapKho_NetWorkDAO()
        {
            db = new ConnectionNetWork();
        }
        public bool CapNhatNhapKho(ref string err, NhapKhoVO nk)
        {
            return db.MyExecuteNonQuery("SpCapNhatNhapKho",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID",nk.ID),
                new SqlParameter("@NHAMAY", nk.NHAMAY),
                new SqlParameter("@NGAYNHAP", nk.NGAYNHAP));
        }
        public DataTable getNhapKhoChiTiet(NhapKhoChiTietVO nhapKhoChietTiet)
        {
            return db.ExcuteQuery("SELECT * FROM getNhapKhoChiTiet('" + nhapKhoChietTiet.Id + "','" + nhapKhoChietTiet.Loso + "','" + nhapKhoChietTiet.Nguon + "','" + nhapKhoChietTiet.Loaimu + "','" + nhapKhoChietTiet.Banh + "')",
                CommandType.Text, null);
        }
        public bool XoaNhapKhoChiTiet(ref string err, NhapKhoChiTietVO nk)
        {
            return db.MyExecuteNonQuery("SpXoaNhapKhoChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID", nk.Id),
                new SqlParameter("@TT", nk.Tt));
        }
        public bool ThemNhapKhoChiTiet(ref string err, NhapKhoChiTietVO nk)
        {
            return db.MyExecuteNonQuery("SpThemNhapKhoChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID", nk.Id),
                new SqlParameter("@TT", nk.Tt),
                new SqlParameter("@LOSO", nk.Loso),
                new SqlParameter("@NGUON", nk.Nguon),
                new SqlParameter("@LOAIMU", nk.Loaimu),
                new SqlParameter("@BANH", nk.Banh),
                new SqlParameter("@THUNG", nk.Thung),
                new SqlParameter("@TUBANH", nk.Tubanh),
                new SqlParameter("@DENBANH", nk.Denbanh),
                new SqlParameter("@SOBANH", nk.Sobanh),
                new SqlParameter("@TLNHAP", nk.Tlnhap),
                new SqlParameter("@SOPNHAP", nk.Sopnhap),
                new SqlParameter("@NGUYENLIEU", nk.Nguyenlieu),
                new SqlParameter("@SOMAUCAT", nk.Somaucat),
                new SqlParameter("@TRANGTHAI", nk.Trangthai),
                new SqlParameter("@BAOPE", nk.Baope),
                new SqlParameter("@BAOBI", nk.Baobi),
                new SqlParameter("@CASX", nk.Casx),
                new SqlParameter("@CATRUONG", nk.Catruong),
                new SqlParameter("@CONGNHAN", nk.Congnhan),
                new SqlParameter("@GHICHU", nk.Ghichu));
        }

    }
}
