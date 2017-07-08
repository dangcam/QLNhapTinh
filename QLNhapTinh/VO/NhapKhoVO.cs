using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhapTinh.VO
{
    class NhapKhoVO
    {
        private int _id;
        private string _nhamay;
        private DateTime _ngaynhap;
        private bool _tinhtrang;
        public NhapKhoVO()
        {
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string NHAMAY
        {
            get
            {
                return _nhamay;
            }
            set
            {
                _nhamay = value;
            }
        }
        public DateTime NGAYNHAP
        {
            get
            {
                return _ngaynhap;
            }
            set
            {
                _ngaynhap = value;
            }
        }

        public bool Tinhtrang
        {
            get
            {
                return _tinhtrang;
            }

            set
            {
                _tinhtrang = value;
            }
        }
    }
}
