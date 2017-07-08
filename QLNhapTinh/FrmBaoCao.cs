using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLNhapTinh.DAO;
using System;
using System.Data;
using System.Globalization;

namespace QLNhapTinh
{
    public partial class FrmBaoCao : RibbonForm
    {
        DataTable dt = null;
        BaoCaoDAO bc = null;
        int stt = 0;
        int sott = 0;
        int tongTrongLuong = 0;
        CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
        System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
        System.Drawing.Font font2 = new System.Drawing.Font("Times New Roman", 12);
        public FrmBaoCao()
        {
            InitializeComponent();
            bc = new BaoCaoDAO();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            lblNhaMay.Text = "NMCB " + AppConfig.Nhamay + " - DC MỦ TINH";
            dateTuNgay.Text = DateTime.Now.ToShortDateString();
            dateDenNgay.Text = DateTime.Now.ToShortDateString();
            stt = 0;
            tongTrongLuong = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            stt = 0;
            string tungay, denngay;
            try
            {
                tungay = DateTime.Parse(dateTuNgay.Text).ToString("yyyy-MM-dd");
                denngay = DateTime.Parse(dateDenNgay.Text).ToString("yyyy-MM-dd");
                dt = bc.getBaoCao(AppConfig.Nhamay, tungay, denngay);
                //
                rptBaoCao rpt = new rptBaoCao();
                rpt.DataSource = null;
                rpt.xrlblNhaMay.Text = "NHÀ MÁY CHẾ BIẾN "+AppConfig.Nhamay;
                rpt.xrlblTuNgayDenNgay.Text = "(Lũy kế từ ngày "+tungay+" đến ngày "+denngay+")";
                rpt.xrlblNgay.Text = "Ngày "+DateTime.Now.Day+" tháng "+DateTime.Now.Month+" năm "+DateTime.Now.Year;
                //
                DataRow[] dr = null;
                dr = dt.Select("NGUON = 'CÔNG TY'");
                if(dr.Length>0)
                {
                    rptNguon(dr.CopyToDataTable(), "CÔNG TY",rpt);
                }
                dr = null;
                dr = dt.Select("NGUON = 'TƯ NHÂN'");
                if(dr.Length>0)
                {
                    rptNguon(dr.CopyToDataTable(), "TƯ NHÂN",rpt);
                }
                //
                XRTableRow row = new XRTableRow();
                XRTableCell cell = new XRTableCell();
                cell.Text = "TỔNG CỘNG";
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Font = font;
                cell.WidthF = 350;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.Text = (tongTrongLuong).ToString("0,0", elGR);
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                cell.Font = font;
                cell.WidthF = 200;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top)
                | DevExpress.XtraPrinting.BorderSide.Bottom)));
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.WidthF = 100;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top) | (DevExpress.XtraPrinting.BorderSide.Right)
                | DevExpress.XtraPrinting.BorderSide.Bottom)));
                row.Cells.Add(cell);

                rpt.xrTable.Rows.Add(row);
                //
                rpt.CreateDocument();
                rpt.ShowPreviewDialog();
                //
            }
            catch { }
        }
        private void rptNguon(DataTable dt, string nguon, rptBaoCao rpt)
        {
           
            stt++;
            DataTable dtTP = bc.DSThanhPham();
            string trongLuong = dt.Compute("SUM(TLNHAP)", null).ToString();
            tongTrongLuong = tongTrongLuong + int.Parse(trongLuong);
            //
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = stt.ToString();
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 100;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = nguon;
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            cell.Font = font;
            cell.WidthF = 250;
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.Text = int.Parse(trongLuong).ToString("0,0", elGR);
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            cell.Font = font;
            cell.WidthF = 200;
            cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            row.Cells.Add(cell);

            cell = new XRTableCell();
            cell.WidthF = 100;
            cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top) | (DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            row.Cells.Add(cell);

            rpt.xrTable.Rows.Add(row);
            //
            string loaiMu;
            DataRow[] dr = null;
            sott = 0;
            for (int i=0;i<dtTP.Rows.Count;i++)
            {
                dr = null;
                loaiMu = dtTP.Rows[i][0].ToString();
                dr = dt.Select("LOAIMU = '"+loaiMu+"'");
                loaiMu = loaiMu.Substring(2, loaiMu.Length - 2);
                if(dr.Length>0)
                {
                    rptLoaiMu(dr.CopyToDataTable(), loaiMu, rpt);
                    
                }
            }
            
        }
        private void rptLoaiMu(DataTable dt, string loaiMu, rptBaoCao rpt)
        {
            
            DataTable dtBanh = bc.DSBanh();
            DataTable dtnew = null;
            DataRow[] dr = null;
            string banh;
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            for (int i = 0; i < dtBanh.Rows.Count; i++)
            {
                banh = dtBanh.Rows[i][0].ToString();
                dr = dt.Select("BANH = '" + banh + "'");
                if(dr.Length>0)
                {
                    dtnew = dr.CopyToDataTable();
                    sott++;
                    string trongLuong = dtnew.Compute("SUM(TLNHAP)", null).ToString();
                    //
                    cell = new XRTableCell();
                    cell.Text = stt+"."+sott;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    cell.Font = font2;
                    cell.WidthF = 100;
                    row.Cells.Add(cell);

                    cell = new XRTableCell();
                    cell.Text = loaiMu;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                    cell.Font = font2;
                    cell.WidthF = 150;
                    cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    row.Cells.Add(cell);

                    cell = new XRTableCell();
                    cell.WidthF = 100;
                    cell.Font = font2;
                    cell.Text = banh;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                    cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top) | (DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    row.Cells.Add(cell);

                    cell = new XRTableCell();
                    cell.Text = int.Parse(trongLuong).ToString("0,0", elGR);
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    cell.Font = font2;
                    cell.WidthF = 200;
                    cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    row.Cells.Add(cell);

                    cell = new XRTableCell();
                    cell.WidthF = 100;
                    cell.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top) | (DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    row.Cells.Add(cell);
                    row.HeightF = 35;
                    rpt.xrTable.Rows.Add(row);
                    //
                }
            }
        }
    }
}
