using QLNhapTinh.VO;
using System.Data;
using System.Data.SqlClient;

namespace QLNhapTinh.DAO
{
    class NhapKhoChiTietDAO
    {
        ConnectionOffLine db = null;
        public NhapKhoChiTietDAO()
        {
            db = new ConnectionOffLine();
        }
        public DataTable DSCaTruong()
        {
            return db.ExcuteQuery("Select  * From CATRUONG",
                CommandType.Text, null);
        }
        public DataTable DSCaSX()
        {
            return db.ExcuteQuery("Select  * From CASX",
                CommandType.Text, null);
        }
        public DataTable DSBaoBi()
        {
            return db.ExcuteQuery("Select  * From BAOBI",
                CommandType.Text, null);
        }
        public DataTable DSBaoPE()
        {
            return db.ExcuteQuery("Select  * From BAOPE",
                CommandType.Text, null);
        }
        public DataTable DSNguyenLieu()
        {
            return db.ExcuteQuery("Select  * From NGUYENLIEU",
                CommandType.Text, null);
        }
        public DataTable DSTrangThai()
        {
            return db.ExcuteQuery("Select  * From TRANGTHAI",
                CommandType.Text, null);
        }
        public DataTable DSBanh()
        {
            return db.ExcuteQuery("Select  * From BANH",
                CommandType.Text, null);
        }
        public DataTable DSThanhPham()
        {
            return db.ExcuteQuery("Select  * From THANHPHAM",
                CommandType.Text, null);
        }
        public DataTable DSNguon()
        {
            return db.ExcuteQuery("Select  * From NGUON",
                CommandType.Text, null);
        }
        public DataTable DSNhapLieu(int ID)
        {
            return db.ExcuteQuery("Select  * From NHAPKHOCHITIET Where ID='" + ID + "'",
                CommandType.Text, null);
        }
        public DataTable DSCapNhatNhapKhoChiTiet()
        {
            return db.ExcuteQuery("Select  * From NHAPKHOCHITIET Where CAPNHAT = 0",
                CommandType.Text, null);
        }
        public bool XoaNhapKhoChiTiet(ref string err, NhapKhoChiTietVO nk)
        {
            return db.MyExecuteNonQuery("SpXoaNhapKhoChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID", nk.Id),
                new SqlParameter("@TT", nk.Tt));
        }
        public DataTable getNhapKhoChiTiet(NhapKhoChiTietVO nhapKhoChietTiet)
        {
            return db.ExcuteQuery("SELECT * FROM getNhapKhoChiTiet('"+nhapKhoChietTiet.Id+"','"+nhapKhoChietTiet.Loso+"','"+nhapKhoChietTiet.Nguon+"','"+nhapKhoChietTiet.Loaimu+"','"+nhapKhoChietTiet.Banh+"')",
                CommandType.Text, null);
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
        
        public bool SuaNhapKhoChiTiet(ref string err, NhapKhoChiTietVO nk)
        {
            return db.MyExecuteNonQuery("SpSuaNhapKhoChiTiet",
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
                new SqlParameter("@GHICHU", nk.Ghichu),
                new SqlParameter("@CAPNHAT", nk.Capnhat));
        }
        /*
        public DataTable getNhapKho(string nhaMay)
        {
            return db.ExcuteQuery("Select  * From dbo.getNhapKho('" + nhaMay + "')",
                CommandType.Text, null);
        }
        public DataTable getToiNgay(string nhaMay, string ngayNhap)
        {
            return db.ExcuteQuery("Select  * From getToiNgay('" + nhaMay + "','" + ngayNhap + "')",
                CommandType.Text, null);
        }
        public bool XoaNhapKho(ref string err, NhapKhoVO nk)
        {
            return db.MyExecuteNonQuery("SpXoaThanhPham",
                CommandType.StoredProcedure, ref err,
                   new SqlParameter("@ID", nk.ID));
        }
        */
    }
}
