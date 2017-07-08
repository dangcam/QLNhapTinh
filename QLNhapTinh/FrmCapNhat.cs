using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using QLNhapTinh.DAO;
using QLNhapTinh.VO;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace QLNhapTinh
{
    public partial class FrmCapNhat : RibbonForm
    {
        BackgroundWorker m_oWorker;
        NhapKho_NetWorkDAO nk_n = null;
        NhapKhoChiTietDAO nkct = null;
        NhapKhoDAO nk = null;
        DataTable dt1,dt2 = null;
        NhapKhoVO nhapkho = null;
        NhapKhoChiTietVO nhapkhochitiet = null;
        public FrmCapNhat()
        {
            InitializeComponent();
            nk_n = new NhapKho_NetWorkDAO();
            nk = new NhapKhoDAO();
            nkct = new NhapKhoChiTietDAO();
            nhapkho = new NhapKhoVO();
            nhapkhochitiet = new NhapKhoChiTietVO();
            //
            m_oWorker = new BackgroundWorker();

            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }
        private void capNhat()
        {
            int t = 0, d = 0;
            try
            {
                dt1 = nk.DSCapNhatNhapKho();
                dt2 = nkct.DSCapNhatNhapKhoChiTiet();
                d = 0;
                string err = "";
                t = dt1.Rows.Count + dt2.Rows.Count;
                progressBarControl.Properties.Maximum = t;
                progressBarControl.Properties.Step = 1;
                progressBarControl.Properties.Minimum = 0;
                foreach (DataRow dr in dt1.Rows)
                {
                    nhapkho.ID = int.Parse(dr[0].ToString());
                    nhapkho.NHAMAY = dr[1].ToString();
                    nhapkho.NGAYNHAP = DateTime.Parse(DateTime.Parse(dr[2].ToString()).ToShortDateString());
                    nhapkho.Tinhtrang = true;
                    if (nk_n.CapNhatNhapKho(ref err, nhapkho))
                    {
                        d++;
                        nk.SuaNhapKho(ref err, nhapkho);
                        progressBarControl.Position = d;
                    }
                    else
                    {
                        XtraMessageBox.Show("Không cập nhật nhập kho ngày: " + nhapkho.NGAYNHAP + "." + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                foreach (DataRow dr in dt2.Rows)
                {
                    nhapkhochitiet.Id = int.Parse(dr[0].ToString());
                    nhapkhochitiet.Tt = int.Parse(dr[1].ToString());
                    nhapkhochitiet.Loso = int.Parse(dr[2].ToString());
                    nhapkhochitiet.Nguon = dr[3].ToString();
                    nhapkhochitiet.Loaimu = dr[4].ToString();
                    nhapkhochitiet.Banh = dr[5].ToString();
                    nhapkhochitiet.Thung = dr[6].ToString();
                    nhapkhochitiet.Tubanh = int.Parse(dr[7].ToString());
                    nhapkhochitiet.Denbanh = int.Parse(dr[8].ToString());
                    nhapkhochitiet.Sobanh = int.Parse(dr[9].ToString());
                    nhapkhochitiet.Tlnhap = int.Parse(dr[10].ToString());
                    nhapkhochitiet.Sopnhap = int.Parse(dr[11].ToString());
                    nhapkhochitiet.Nguyenlieu = dr[12].ToString();
                    nhapkhochitiet.Somaucat = int.Parse(dr[13].ToString());
                    nhapkhochitiet.Trangthai = dr[14].ToString();
                    nhapkhochitiet.Baope = dr[15].ToString();
                    nhapkhochitiet.Baobi = dr[16].ToString();
                    nhapkhochitiet.Casx = dr[17].ToString();
                    nhapkhochitiet.Catruong = dr[18].ToString();
                    nhapkhochitiet.Congnhan = dr[19].ToString();
                    nhapkhochitiet.Ghichu = dr[20].ToString();
                    nhapkhochitiet.Capnhat = true;
                    if (nk_n.ThemNhapKhoChiTiet(ref err, nhapkhochitiet))
                    {
                        d++;
                        nkct.SuaNhapKhoChiTiet(ref err, nhapkhochitiet);
                        progressBarControl.Position = d;
                    }
                    else
                    {
                        XtraMessageBox.Show("Không cập nhật được lô: " + nhapkhochitiet.Loso + "." + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
            XtraMessageBox.Show("Cập nhật xong! " + t + "/" + d, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void FrmCapNhat_Load(object sender, EventArgs e)
        {
            var thread = new Thread(capNhat);
            thread.Start();
            this.Close();
        }
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                //lblStatus.Text = "Task Cancelled.";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                //lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                // Everything completed normally.
                //lblStatus.Text = "Task Completed...";
            }
        }
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // Update the progressBar with the integer supplied to us from the

            // ReportProgress() function.  

            //progressBar1.Value = e.ProgressPercentage;
            //lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // The sender is the BackgroundWorker object we need it to
            // report progress and check for cancellation.
            //NOTE : Never play with the UI thread here...
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);

                // Periodically report progress to the main thread so that it can
                // update the UI.  In most cases you'll just need to send an
                // integer that will update a ProgressBar                    
                m_oWorker.ReportProgress(i);
                // Periodically check if a cancellation request is pending.
                // If the user clicks cancel the line
                // m_AsyncWorker.CancelAsync(); if ran above.  This
                // sets the CancellationPending to true.
                // You must check this flag in here and react to it.
                // We react to it by setting e.Cancel to true and leaving
                if (m_oWorker.CancellationPending)
                {
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }
            }

            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }
        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {


            // Kickoff the worker thread to begin it's DoWork function.
            m_oWorker.RunWorkerAsync();
        }

    }
}
