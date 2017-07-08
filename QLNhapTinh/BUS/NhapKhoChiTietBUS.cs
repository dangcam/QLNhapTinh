using QLNhapTinh.DAO;
using QLNhapTinh.VO;
using System.Data;

namespace QLNhapTinh.BUS
{
    class NhapKhoChiTietBUS
    {
        NhapKhoChiTietDAO _nhapKhoChietTiet = null;
        public NhapKhoChiTietBUS()
        {
            _nhapKhoChietTiet = new NhapKhoChiTietDAO();
        }
        public bool[] listBanh(NhapKhoChiTietVO nhapKhoCT)
        {
            DataTable data = new DataTable();
            bool[] list = new bool[121];
            data = _nhapKhoChietTiet.getNhapKhoChiTiet(nhapKhoCT);
            if( data.Rows.Count != 0)
            {
                foreach(DataRow dr in data.Rows)
                {
                    for(int i = int.Parse(dr["TUBANH"].ToString()); i<=int.Parse(dr["DENBANH"].ToString()); i++)
                    {
                        list[i] = true;
                    }
                }
                return list;
            }
            return null;
        }
    }
}
