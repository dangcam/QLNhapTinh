using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using QLNhapTinh.BUS;
using QLNhapTinh.DAO;
using QLNhapTinh.VO;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Globalization;
using System.Threading;

namespace QLNhapTinh
{
    public partial class FrmNhapKhoChiTiet : RibbonForm
    {
        public static string NHAMAY { get; set; }
        NhapKhoBUS nhapKhoBus = null;
        NhapKhoChiTietBUS nhapKhoChiTietBus = null;
        NhapKhoVO nhapkho = null;
        NhapKhoDAO nk = null;
        
        NhapKhoChiTietDAO nl = null;
        NhapKhoChiTietVO nhapkhochitiet = null;
        DataTable dt = null;
        DataRow dr = null;
        bool them = false;
        int stt = 0;
        int tongBanh = 0;
        int tongTrongLuong = 0;
        int tongAmLo = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
        public FrmNhapKhoChiTiet()
        {
            InitializeComponent();
            nhapKhoBus = new NhapKhoBUS();
            nk = new NhapKhoDAO();
            
            nl = new NhapKhoChiTietDAO();
            nhapKhoChiTietBus = new NhapKhoChiTietBUS();
            nhapkhochitiet = new NhapKhoChiTietVO();
        }
        void LoadData()
        {
            them = false;
            gridControlNhapLieu.DataSource = dt;
            gridViewNhapLieu_RowClick(null, null);
        }
        void getData(DateTime date)
        {
            nhapkho = nhapKhoBus.getToiNgay(NHAMAY, date);
            dateNgayNhap.Text = date.ToShortDateString();
            txtID.Text = nhapkho.ID.ToString();
            if (0 == nhapkho.ID)
            {
                XtraMessageBox.Show("Chưa có dữ liệu hãy thêm ngày!");
                dt = null;
                btnThemNgay.Focus();
                LoadData();
            }
            if (0 != nhapkho.ID)
            {
                dt = nl.DSNhapLieu(nhapkho.ID);
                LoadData();
            }
        }
        private void FrmNhapLieu_Load(object sender, EventArgs e)
        {
            cbNguon.DataSource = nl.DSNguon();
            cbNguon.ValueMember = "NGUON";
            cbNguon.DisplayMember = "NGUON";
            //
            cbLoaiMu.DataSource = nl.DSThanhPham();
            cbLoaiMu.ValueMember = "LOAIMU";
            cbLoaiMu.DisplayMember = "LOAIMU";
            //
            cbBanh.DataSource = nl.DSBanh();
            cbBanh.ValueMember = "BANH";
            cbBanh.DisplayMember = "BANH";
            //
            cbNguyenLieu.DataSource = nl.DSNguyenLieu();
            cbNguyenLieu.ValueMember = "NGUYENLIEU";
            cbNguyenLieu.DisplayMember = "NGUYENLIEU";
            //
            cbTrangThai.DataSource = nl.DSTrangThai();
            cbTrangThai.ValueMember = "TRANGTHAI";
            cbTrangThai.DisplayMember = "TRANGTHAI";
            //
            cbPE.DataSource = nl.DSBaoPE();
            cbPE.ValueMember = "BAOPE";
            cbPE.DisplayMember = "BAOPE";
            //
            cbBaoBi.DataSource = nl.DSBaoBi();
            cbBaoBi.ValueMember = "BAOBI";
            cbBaoBi.DisplayMember = "BAOBI";
            //
            cbCaSX.DataSource = nl.DSCaSX();
            cbCaSX.ValueMember = "CASX";
            cbCaSX.DisplayMember = "CASX";
            //
            cbCaTruong.DataSource = nl.DSCaTruong();
            cbCaTruong.ValueMember = "CATRUONG";
            cbCaTruong.DisplayMember = "CATRUONG";

            //
            lblNhaMay.Text = "NHÀ MÁY CHẾ BIẾN " + NHAMAY;
            txtNhaMay.Text = NHAMAY;
            nhapkho = nhapKhoBus.getNhapKho(NHAMAY);
            txtID.Text = nhapkho.ID.ToString();
            dateNgayNhap.Text = nhapkho.NGAYNHAP.ToShortDateString();
            //
            if (0 != nhapkho.ID)
            {
                dt = nl.DSNhapLieu(nhapkho.ID);
            }
            LoadData();
            btnHomNay.Focus();
        }

        private void btnToiNgay_Click(object sender, EventArgs e)
        {
            try
            {
                getData(DateTime.Parse(dateNgayNhap.Text));
            }
            catch { }
        }

        private void btnThemNgay_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";

                nhapkho.NHAMAY = NHAMAY;
                nhapkho.NGAYNHAP = DateTime.Parse(DateTime.Parse(dateNgayNhap.Text).ToShortDateString());
                if (nk.ThemNhapKho(ref err, nhapkho))
                {
                    XtraMessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getData(DateTime.Parse(dateNgayNhap.Text));
                }
                else
                {
                    XtraMessageBox.Show("Không thêm được! " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            getData(DateTime.Now);
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(dateNgayNhap.Text);
                getData(date.AddDays(-1));
            }
            catch { }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(dateNgayNhap.Text);
                getData(date.AddDays(1));
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;

            txtTT.Enabled = true;
            txtLoSo.Enabled = true;
            cbNguon.Enabled = true;
            cbLoaiMu.Enabled = true;
            cbBanh.Enabled = true;

            if (null == dt || 0 == dt.Rows.Count)
            {
                txtTT.Text = "1";
                txtLoSo.Text = "2";
                txtTuB.Text = "1";
                txtDenB.Text = "72";
                txtSoB.Text = "72";
                cbMau.SelectedIndex = 0;
                txtTLuong.ResetText();
            }
            else
            {
                try
                {
                    dr = dt.Rows[dt.Rows.Count - 1];
                    txtTT.Text = (int.Parse(dr["TT"].ToString()) + 1).ToString();
                    txtLoSo.Text = (int.Parse(dr["LOSO"].ToString()) + 2).ToString();
                    cbNguon.SelectedValue = dr["NGUON"].ToString();
                    cbLoaiMu.SelectedValue = dr["LOAIMU"].ToString();
                    cbBanh.SelectedValue = dr["BANH"].ToString();
                    txtSoPh.Text = dr["SOPNHAP"].ToString();
                    cbNguyenLieu.SelectedValue = dr["NGUYENLIEU"].ToString();
                    cbMau.SelectedIndex = int.Parse(dr["SOMAUCAT"].ToString()) - 1;
                    cbTrangThai.SelectedValue = dr["TRANGTHAI"].ToString();
                    cbPE.SelectedValue = dr["BAOPE"].ToString();
                    cbBaoBi.SelectedValue = dr["BAOBI"].ToString();
                    cbCaSX.SelectedValue = dr["CASX"].ToString();
                    cbCaTruong.SelectedValue = dr["CATRUONG"].ToString();
                    cbGhiChu.SelectedValue = dr["GHICHU"].ToString();
                    //txtTLuong.ResetText();
                }
                catch { }
            }
            txtLoSo.Focus();
            btnThem.Enabled = false;
        }

        private void gridViewNhapLieu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            btnThem.Enabled = true;
            them = false;

            txtTT.Enabled = false;
            txtLoSo.Enabled = false;
            cbNguon.Enabled = false;
            cbLoaiMu.Enabled = false;
            cbBanh.Enabled = false;

            try
            {
                dr = gridViewNhapLieu.GetFocusedDataRow();
                txtTT.Text = dr["TT"].ToString();
                txtLoSo.Text = dr["LOSO"].ToString();
                cbNguon.SelectedValue = dr["NGUON"].ToString();
                cbLoaiMu.SelectedValue = dr["LOAIMU"].ToString();
                //cbBanh.SelectedValue = dr["BANH"].ToString();
                txtThung.Text = dr["THUNG"].ToString();
                txtTuB.Text = dr["TUBANH"].ToString();
                txtDenB.Text = dr["DENBANH"].ToString();
                txtSoB.Text = dr["SOBANH"].ToString();
                cbBanh.SelectedValue = dr["BANH"].ToString();
                //txtTLuong.Text = dr["TLNHAP"].ToString();
                txtSoPh.Text = dr["SOPNHAP"].ToString();
                cbNguyenLieu.SelectedValue = dr["NGUYENLIEU"].ToString();
                cbMau.SelectedIndex = int.Parse(dr["SOMAUCAT"].ToString()) - 1;
                cbTrangThai.SelectedValue = dr["TRANGTHAI"].ToString();
                cbPE.SelectedValue = dr["BAOPE"].ToString();
                cbBaoBi.SelectedValue = dr["BAOBI"].ToString();
                cbCaSX.SelectedValue = dr["CASX"].ToString();
                cbCaTruong.SelectedValue = dr["CATRUONG"].ToString();
                txtCongNhan.Text = dr["CONGNHAN"].ToString();
                cbGhiChu.SelectedValue = dr["GHICHU"].ToString();
                txtTLuong.Text = dr["TLNHAP"].ToString();
            }
            catch { }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                if (them)
                {

                    nhapkhochitiet.Id = nhapkho.ID;
                    nhapkhochitiet.Tt = int.Parse(txtTT.Text);
                    nhapkhochitiet.Loso = int.Parse(txtLoSo.Text);
                    nhapkhochitiet.Nguon = cbNguon.SelectedValue.ToString();
                    nhapkhochitiet.Loaimu = cbLoaiMu.SelectedValue.ToString();
                    nhapkhochitiet.Banh = cbBanh.SelectedValue.ToString();
                    nhapkhochitiet.Thung = txtThung.Text;
                    nhapkhochitiet.Tubanh = int.Parse(txtTuB.Text);
                    nhapkhochitiet.Denbanh = int.Parse(txtDenB.Text);
                    nhapkhochitiet.Sobanh = int.Parse(txtSoB.Text);
                    nhapkhochitiet.Tlnhap = int.Parse(txtTLuong.Text);
                    nhapkhochitiet.Sopnhap = int.Parse(txtSoPh.Text);
                    nhapkhochitiet.Nguyenlieu = cbNguyenLieu.SelectedValue.ToString();
                    nhapkhochitiet.Somaucat = cbMau.SelectedIndex + 1;
                    nhapkhochitiet.Trangthai = cbTrangThai.SelectedValue.ToString();
                    nhapkhochitiet.Baope = cbPE.SelectedValue.ToString();
                    nhapkhochitiet.Baobi = cbBaoBi.SelectedValue.ToString();
                    nhapkhochitiet.Casx = cbCaSX.SelectedValue.ToString();
                    nhapkhochitiet.Catruong = cbCaTruong.SelectedValue.ToString();
                    nhapkhochitiet.Congnhan = txtCongNhan.Text;
                    nhapkhochitiet.Ghichu = "";
                    if (null != cbGhiChu.SelectedItem)
                        nhapkhochitiet.Ghichu = cbGhiChu.SelectedItem.ToString();
                    //
                    dr = dt.NewRow();
                    dr["ID"] = nhapkho.ID;
                    dr["TT"] = nhapkhochitiet.Tt;
                    dr["LOSO"] = nhapkhochitiet.Loso;
                    dr["NGUON"] = nhapkhochitiet.Nguon;
                    dr["LOAIMU"] = nhapkhochitiet.Loaimu;
                    dr["BANH"] = nhapkhochitiet.Banh;
                    dr["THUNG"] = nhapkhochitiet.Thung;
                    dr["TUBANH"] = nhapkhochitiet.Tubanh;
                    dr["DENBANH"] = nhapkhochitiet.Denbanh;
                    dr["SOBANH"] = nhapkhochitiet.Sobanh;
                    dr["TLNHAP"] = nhapkhochitiet.Tlnhap;
                    dr["SOPNHAP"] = nhapkhochitiet.Sopnhap;
                    dr["NGUYENLIEU"] = nhapkhochitiet.Nguyenlieu;
                    dr["SOMAUCAT"] = nhapkhochitiet.Somaucat;
                    dr["TRANGTHAI"] = nhapkhochitiet.Trangthai;
                    dr["BAOPE"] = nhapkhochitiet.Baope;
                    dr["BAOBI"] = nhapkhochitiet.Baobi;
                    dr["CASX"] = nhapkhochitiet.Casx;
                    dr["CATRUONG"] = nhapkhochitiet.Catruong;
                    dr["CONGNHAN"] = nhapkhochitiet.Congnhan;
                    dr["GHICHU"] = nhapkhochitiet.Ghichu;
                    if (nl.ThemNhapKhoChiTiet(ref err, nhapkhochitiet))
                    {
                        dt.Rows.Add(dr);
                        LoadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không thêm được! " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch { }
            btnThem_Click(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            string err = "";
            // Hiện hộp thoại hỏi đáp 
           
            traloi = XtraMessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (traloi == DialogResult.Yes)
                {
                    DataRow drRow = gridViewNhapLieu.GetFocusedDataRow();
                    nhapkhochitiet.Id = int.Parse(drRow["ID"].ToString());
                    nhapkhochitiet.Tt = int.Parse(drRow["TT"].ToString());
                    NhapKho_NetWorkDAO nk_n = new NhapKho_NetWorkDAO();
                    if (nk_n.XoaNhapKhoChiTiet(ref err, nhapkhochitiet))
                    {
                        nl.XoaNhapKhoChiTiet(ref err, nhapkhochitiet);
                        XtraMessageBox.Show("Xóa thành công!");
                        int index = dt.Rows.IndexOf(drRow);
                        dt.Rows[index].Delete();
                        LoadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không thể xóa mẫu tin này! "+ err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch { }
        }
        void kiemTraBanh()
        {
            try
            {
                int a = int.Parse(txtTuB.Text);
                int b = int.Parse(txtDenB.Text);
                int n = 72;
                if ("20 kg".Equals(cbBanh.SelectedValue.ToString()))
                {
                    n = 120;
                }
                if (a > n || a < 1)
                {
                    XtraMessageBox.Show("0 < Từ Bành < " + n);

                    txtTuB.Focus();

                    return;
                }
                else
                if (b > n || b < 1)
                {
                    XtraMessageBox.Show("0 < Đến Bành < " + n);
                    txtDenB.Focus();
                    return;
                }
                else
                if (b < a)
                {
                    XtraMessageBox.Show("Từ Bành < Đến Bành");
                    txtTuB.Focus();
                    return;
                }
                else
                {
                    txtSoB.Text = (b - a + 1).ToString();
                    tinhBanh(true, a, b);
                }
            }
            catch { }
        }
        /* private void txtTuB_EditValueChanged(object sender, EventArgs e)
         {
             kiemTraBanh();
         }
         */
        /* private void txtDenB_EditValueChanged(object sender, EventArgs e)
         {
             kiemTraBanh();
         }*/
        void tinhTLuong()
        {
            try
            {
                int sobanh = int.Parse(txtSoB.Text);
                int banh = int.Parse(cbBanh.SelectedValue.ToString().Substring(0, 2));
                if (33 == banh)
                {
                    // Me.TLNHAP = ((Me.SOBANH \ 3) *100) +((Me.SOBANH Mod 3) *100 / 3);
                    txtTLuong.Text = (((sobanh / 3) * 100) + ((sobanh % 3) * 100 / 3)).ToString();
                }
                else
                {
                    txtTLuong.Text = (banh * sobanh).ToString();
                }
            }
            catch
            {
                txtTLuong.Text = "0";
            }
        }
        private void txtSoB_EditValueChanged(object sender, EventArgs e)
        {
            tinhTLuong();
        }

        private void cbBanh_SelectedIndexChanged(object sender, EventArgs e)
        {

            tinhTLuong();
            tinhBanh(false, 0, 0);
        }
        bool checkList(bool[] list, int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (!list[i])
                    return false;
            }
            return true;
        }
        void tinhBanh(bool t, int a, int b)
        {
            if (them)
            {
                NhapKhoChiTietVO nhakhoCT = new NhapKhoChiTietVO();
                try
                {
                    nhakhoCT.Loso = int.Parse(txtLoSo.Text);
                    nhakhoCT.Nguon = cbNguon.SelectedValue.ToString();
                    nhakhoCT.Loaimu = cbLoaiMu.SelectedValue.ToString();
                    nhakhoCT.Banh = cbBanh.SelectedValue.ToString();
                    nhakhoCT.Id = nhapkho.ID;
                    bool[] list = nhapKhoChiTietBus.listBanh(nhakhoCT);
                    if (null != list)
                    {
                        int n = 73;
                        if ("20".Equals(nhakhoCT.Banh.Substring(0, 2)))
                        {
                            n = 121;
                        }
                        bool fag = checkList(list, n);

                        if (fag == true)
                        {
                            XtraMessageBox.Show("Bành này đã đầy 1->" + (n - 1));
                            txtLoSo.ResetText();
                            txtLoSo.Focus();
                            return;
                        }
                        else
                        {
                            if (t)
                            {
                                for (int i = a; i < b + 1; i++)
                                {
                                    if (list[i] == true)
                                    {
                                        XtraMessageBox.Show("Kiểm tra lại TUBANH -> DENBANH");
                                        txtTuB.Focus();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                int i = 1;
                                for (i = 1; i < n; i++)
                                {
                                    if (list[i] == false)
                                    {
                                        txtTuB.Text = (i).ToString();
                                        break;
                                    }
                                }
                                //list[72] = true;
                                for (int j = i; j < n; j++)
                                {
                                    if (list[j] == true)
                                    {
                                        txtDenB.Text = (j - 1).ToString();
                                        break;
                                    }
                                    txtDenB.Text = (n - 1).ToString();
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }

                catch { }
            }

        }
        /* private void txtLoSo_EditValueChanged(object sender, EventArgs e)
         {
             tinhBanh(false,0,0);
         }
         */
        private void cbNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhBanh(false, 0, 0);
        }

        private void cbLoaiMu_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhBanh(false, 0, 0);
        }

        private void txtTuB_Leave(object sender, EventArgs e)
        {
            kiemTraBanh();
        }

        private void txtDenB_Leave(object sender, EventArgs e)
        {
            kiemTraBanh();
        }

        private void txtLoSo_Leave(object sender, EventArgs e)
        {
            tinhBanh(false, 0, 0);
        }
        private void FrmNhapKhoChiTiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 

            traloi = XtraMessageBox.Show("Cập nhật dữ liệu trước khi đóng?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (traloi == DialogResult.Yes)
                {
                    e.Cancel = true;
                    var thread = new Thread(CapNhat);
                    thread.Start();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch { }
        }
        void CapNhat()
        {
            Form frm = new FrmCapNhat();

            frm.ShowDialog();
        }

        private void btnKSCTY_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportKS("NGUON = 'CÔNG TY' AND LOAIMU <>'S_Skim Block'","CÔNG TY");
        }
        private void creatReportKS(string sql, string nguon)
        {
            rptPhieuKS rpt = new rptPhieuKS();
            rpt.DataSource = null;
            rpt.xrlblNhaMay.Text = "NMCB " + AppConfig.Nhamay + " - Dây chuyền Mủ TINH";
            rpt.xrlblSo.Text = "SỐ: " + nhapkho.ID % 1000000;
            rpt.xrlblNgayNhap.Text = "(Ngày " + nhapkho.NGAYNHAP.Day + " tháng " + nhapkho.NGAYNHAP.Month + " năm " + nhapkho.NGAYNHAP.Year + ")";
            rpt.xrlblGhiChu.Text = "Ghi chú: Mủ " + nguon;
            DataRow[] dr = null;
            DataTable dtct = null;
            try
            {
                dr = dt.Select(sql);
                dtct = dr.CopyToDataTable();


                //
                DataRow[] drCaSX = null;
                drCaSX = dtct.Select("CASX = 'a_3'");
                if (drCaSX.Length > 0)
                {
                    caSanXuat(drCaSX.CopyToDataTable(), rpt, 3);
                }
                drCaSX = dtct.Select("CASX = 'b_1'");
                if (drCaSX.Length > 0)
                {
                    caSanXuat(drCaSX.CopyToDataTable(), rpt, 1);
                }
                drCaSX = dtct.Select("CASX = 'c_2'");
                if (drCaSX.Length > 0)
                {
                    caSanXuat(drCaSX.CopyToDataTable(), rpt, 2);
                }
            }
            catch
            { }
            //
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);

            cell.Text = "TỔNG CỘNG";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.Font = font;
            cell.WidthF = 290;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = tongBanh.ToString();
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = tongTrongLuong.ToString("0,0", elGR);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 225;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "ÂL: " + tongAmLo.ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 115;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
        private void caSanXuat(DataTable dt, rptPhieuKS rpt, int ca)
        {
            
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);
            string soBanh = dt.Compute("SUM(SOBANH)",null).ToString();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            string amLo = dt.Compute("SUM(TLNHAP)", "GHICHU = 'Âm lò'").ToString();
            if ("".Equals(amLo))
                amLo = "0";
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = " Ca SX: "+ca;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.Font = font;
            cell.WidthF = 290;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = soBanh+" ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR)+" ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "";
            cell.WidthF = 225;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "ÂL: "+ int.Parse(amLo).ToString("0,0", elGR) + " "; 
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 115;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            DataRow[] dr = null;
            for(int i=0;i<cbLoaiMu.Items.Count;i++)
            {
                string lm = cbLoaiMu.GetItemText(cbLoaiMu.Items[i]);
                dr = dt.Select("LOAIMU = '" +lm +"'");
                if(dr.Length>0)
                {
                    loaiMu(dr.CopyToDataTable(), rpt, lm);
                }
            }
            //
        }
        private void loaiMu(DataTable dt, rptPhieuKS rpt, string loaiMu)
        {
            
            
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);
            string soBanh = dt.Compute("SUM(SOBANH)", null).ToString();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            string amLo = dt.Compute("SUM(TLNHAP)", "GHICHU = 'Âm lò'").ToString();
            if ("".Equals(amLo))
                amLo = "0";
            tongAmLo = tongAmLo + int.Parse(amLo);
            tongBanh = tongBanh + int.Parse(soBanh);
            tongTrongLuong = tongTrongLuong + int.Parse(trongLuong);
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = loaiMu.Substring(2,loaiMu.Length-2);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 290;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = soBanh + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "";
            cell.WidthF = 225;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "ÂL: " + int.Parse(amLo).ToString("0,0", elGR) + " "; 
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 115;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            DataRow[] dr = null;
            for (int i = 0; i < cbBanh.Items.Count; i++)
            {
                string lb = cbBanh.GetItemText(cbBanh.Items[i]);
                dr = dt.Select("BANH = '" + lb + "'");
                if (dr.Length > 0)
                {
                    loaiBanh(dr.CopyToDataTable(), rpt,loaiMu, lb);
                }
            }
            //
        }
        private void loaiBanh(DataTable dt, rptPhieuKS rpt, string loaiMu, string loaiBanh)
        {
            stt++;
            string soBanh = dt.Compute("SUM(SOBANH)", null).ToString();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            string amLo = dt.Compute("SUM(TLNHAP)", "GHICHU = 'Âm lò'").ToString();
            if ("".Equals(amLo))
                amLo = "0";
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = stt.ToString();
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = loaiMu.Substring(2, loaiMu.Length - 2);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 130;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = loaiBanh;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 60;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = null;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 60;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = soBanh + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = null;
            cell.WidthF = 225;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "ÂL: " + int.Parse(amLo).ToString("0,0", elGR) + " "; 
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 115;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            System.Drawing.Font font2 = new System.Drawing.Font("Times New Roman", 10);
            for (int i = 0;i<dt.Rows.Count;i++)
            {
                row = new XRTableRow();

                cell = new XRTableCell();
                cell.Text = stt+"."+(i+1);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 40;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][2].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 50;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = loaiMu.Substring(2, loaiMu.Length - 2);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 80;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = loaiBanh;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 60;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][6].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 60;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][9].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.Font = font2;
                cell.WidthF = 40;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = int.Parse(dt.Rows[i][10].ToString()).ToString("0,0", elGR);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 80;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][13].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 40;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][14].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 80;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][15].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 40;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][16].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 65;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.WidthF = 115;
                row.Cells.Add(cell);

                rpt.xrTable.Rows.Add(row);
            }
        }

        private void btnKSTN_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportKS("NGUON = 'TƯ NHÂN' AND LOAIMU <>'S_Skim Block'","TƯ NHÂN");
        }

        private void btnNKCTY_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportNK("NGUON = 'CÔNG TY' AND LOAIMU <>'S_Skim Block'","CÔNG TY");
        }
        private void creatReportNK(string sql,string nguon)
        {
            rptPhieuNK rpt = new rptPhieuNK();
            rpt.DataSource = null;
            stt = 0;
         
            rpt.xrlblNhaMay.Text = "NMCB " + AppConfig.Nhamay + " - Dây chuyền Mủ TINH";
            rpt.xrlblSo.Text = "SỐ: " + nhapkho.ID % 1000000;
            rpt.xrlblNgayNhap.Text = "(Ngày " + nhapkho.NGAYNHAP.Day + " tháng " + nhapkho.NGAYNHAP.Month + " năm " + nhapkho.NGAYNHAP.Year + ")";
            rpt.xrlblNguoiGiaoHang.Text = "Họ tên người giao hàng: " + cbNguoiGiaoHang.SelectedItem;
            rpt.xrlblGhiChu.Text = "Ghi chú: Mủ " + nguon+".";
            try
            {
                DataTable dtct;
                DataRow[] dr;
                dr = dt.Select(sql);
                dtct = dr.CopyToDataTable();

                //
                DataRow[] drows = null;
                for (int i = 0; i < cbLoaiMu.Items.Count; i++)
                {
                    string lm = cbLoaiMu.GetItemText(cbLoaiMu.Items[i]);
                    drows = dtct.Select("LOAIMU = '" + lm + "'");
                    if (drows.Length > 0)
                    {
                        loaiMuNK(drows.CopyToDataTable(), rpt, lm);
                    }
                }
                //
            }
            catch { }
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);

            cell.Text = "TỔNG CỘNG";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.Font = font;
            cell.WidthF = 270;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = tongBanh.ToString();
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = tongTrongLuong.ToString("0,0", elGR);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 120;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "Âm lò: " + tongAmLo.ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 181;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            rpt.CreateDocument();
            rpt.ShowPreviewDialog();
        }
        private void loaiMuNK(DataTable dt, rptPhieuNK rpt, string loaiMu)
        {
            //
            DataRow[] dr = null;
            for (int i = 0; i < cbBanh.Items.Count; i++)
            {
                string lb = cbBanh.GetItemText(cbBanh.Items[i]);
                dr = dt.Select("BANH = '" + lb + "'");
                if (dr.Length > 0)
                {
                    loaiBanhNK(dr.CopyToDataTable(), rpt, loaiMu, lb);
                }
            }
            //
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold);
            string soBanh = dt.Compute("SUM(SOBANH)", null).ToString();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            string amLo = dt.Compute("SUM(TLNHAP)", "GHICHU = 'Âm lò'").ToString();
            if ("".Equals(amLo))
                amLo = "0";
            tongAmLo = tongAmLo + int.Parse(amLo);
            tongBanh = tongBanh + int.Parse(soBanh);
            tongTrongLuong = tongTrongLuong + int.Parse(trongLuong);
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = "Cộng " + loaiMu.Substring(2, loaiMu.Length - 2);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            cell.Font = font;
            cell.WidthF = 270;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = soBanh + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 120;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "Âm lò: " + int.Parse(amLo).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 181;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
        }
        private void loaiBanhNK(DataTable dt, rptPhieuNK rpt, string loaiMu, string loaiBanh)
        {
            stt++;
            string soBanh = dt.Compute("SUM(SOBANH)", null).ToString();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            string amLo = dt.Compute("SUM(TLNHAP)", "GHICHU = 'Âm lò'").ToString();
            if ("".Equals(amLo))
                amLo = "0";
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = stt.ToString();
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 40;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = loaiMu.Substring(2, loaiMu.Length - 2);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = loaiBanh;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 60;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 70;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = soBanh + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 80;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 120;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = "Âm lò:  " + int.Parse(amLo).ToString("0,0", elGR) + " ";
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = new System.Drawing.Font("Times New Roman", 10);
            cell.WidthF = 181;
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            System.Drawing.Font font2 = new System.Drawing.Font("Times New Roman", 10);
            string nguyenlieu = "";
            DataTable dtNL = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = new XRTableRow();

                cell = new XRTableCell();
                cell.Text = stt + "." + (i + 1);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 40;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = loaiMu.Substring(2, loaiMu.Length - 2);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 100;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = loaiBanh;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 60;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][2].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 70;
                row.Cells.Add(cell);              

                cell = new XRTableCell();
                cell.Text = dt.Rows[i][9].ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.Font = font2;
                cell.WidthF = 80;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = int.Parse(dt.Rows[i][10].ToString()).ToString("0,0", elGR);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 100;
                row.Cells.Add(cell);
                // Tên Nguyên Liệu
                nguyenlieu = dt.Rows[i][12].ToString();
                dtNL = nk.getNguyenLieu(nguyenlieu);
                nguyenlieu = dtNL.Rows[0][1].ToString();
                cell = new XRTableCell();
                cell.Text = nguyenlieu;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font2;
                cell.WidthF = 120;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.WidthF = 181;
                row.Cells.Add(cell);

                rpt.xrTable.Rows.Add(row);
            }
        }

        private void btnNKTN_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportNK("NGUON = 'TƯ NHÂN' AND LOAIMU <>'S_Skim Block'","TƯ NHÂN");
        }

        private void btnKSSCTY_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportKS("NGUON = 'CÔNG TY' AND LOAIMU ='S_Skim Block'", "CÔNG TY");
        }

        private void btnKSSTN_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportKS("NGUON = 'TƯ NHÂN' AND LOAIMU ='S_Skim Block'", "TƯ NHÂN");
        }

        private void btnNKSCTY_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportNK("NGUON = 'CÔNG TY' AND LOAIMU ='S_Skim Block'", "CÔNG TY");
        }

        private void btnNKSTN_Click(object sender, EventArgs e)
        {
            tongAmLo = 0;
            tongBanh = 0;
            tongTrongLuong = 0;
            creatReportNK("NGUON = 'TƯ NHÂN' AND LOAIMU ='S_Skim Block'", "TƯ NHÂN");
        }
    }
}
