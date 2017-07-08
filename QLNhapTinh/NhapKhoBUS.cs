using QLNhapTinh.DAO;
using QLNhapTinh.VO;
using System;
using System.Data;

namespace QLNhapTinh.BUS
{
    class NhapKhoBUS
    {
        NhapKhoDAO _nhapKhoDAO = null;
        public NhapKhoBUS()
        {
            _nhapKhoDAO = new NhapKhoDAO();
        }
        public NhapKhoVO getNhapKho(string nhaMay)
        {
            NhapKhoVO nhapKho = new NhapKhoVO();
            DataTable data = new DataTable();
            data = _nhapKhoDAO.getNhapKho(nhaMay);
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    nhapKho.ID = int.Parse(dr[0].ToString());
                    nhapKho.NHAMAY = dr[1].ToString();
                    nhapKho.NGAYNHAP = DateTime.Parse(DateTime.Parse(dr[2].ToString()).ToShortDateString());
                }

            }
            return nhapKho;
        }
        public NhapKhoVO getToiNgay(string nhaMay,DateTime ngayNhap)
        {
            NhapKhoVO nhapKho = new NhapKhoVO();
            DataTable data = new DataTable();
            data = _nhapKhoDAO.getToiNgay(nhaMay, String.Format("{0:yyyy-MM-dd}",ngayNhap));
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    nhapKho.ID = int.Parse(dr[0].ToString());
                    nhapKho.NHAMAY = dr[1].ToString();
                    nhapKho.NGAYNHAP = DateTime.Parse(DateTime.Parse(dr[2].ToString()).ToShortDateString());
                }

            }
            return nhapKho;
        }
    }
}
