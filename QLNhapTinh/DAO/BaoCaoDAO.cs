using System.Data;

namespace QLNhapTinh.DAO
{
    class BaoCaoDAO
    {
        ConnectionOffLine db = null;
        public BaoCaoDAO()
        {
            db = new ConnectionOffLine();
        }
        public DataTable getBaoCao(string trungtam, string tungay,string denngay)
        {
            return db.ExcuteQuery("SELECT NGUON,LOAIMU,BANH,TLNHAP FROM NHAPKHOCHITIET WHERE ID IN (SELECT ID FROM NHAPKHO WHERE (NGAYNHAP BETWEEN '"+tungay+"' AND '"+denngay+"') AND NHAMAY = N'"+trungtam+"')",
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
    }
}
