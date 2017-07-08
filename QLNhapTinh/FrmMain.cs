
using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;

namespace QLNhapTinh
{
    public partial class FrmMain : RibbonForm
    {
        System.DateTime date = System.DateTime.Now;
        ReadConfig readConfig;
        Form frm;
        public FrmMain()
        {
            InitializeComponent();
            readConfig = new ReadConfig();
            

        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            readConfig.Read();
            labelControlNgayLamViec.Text = "Ngày làm việc: " + date.ToShortDateString();
            lblNhaMay.Text = "NMCB "+AppConfig.Nhamay+" - DC MỦ TINH";
            FrmNhapKhoChiTiet.NHAMAY = AppConfig.Nhamay;
            frm = new FrmNhapKhoChiTiet();
        }

        private void barButtonItemNhapLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm.ShowDialog();
        }

        private void barButtonItemBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = new FrmBaoCao();
            frm.ShowDialog();
        }
    }
}
