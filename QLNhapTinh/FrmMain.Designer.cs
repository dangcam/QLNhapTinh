namespace QLNhapTinh
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemCauHinh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNhapLieu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXemQKKiemPham = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupChucNang = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.labelControlNgayLamViec = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblNhaMay = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barButtonItemCauHinh,
            this.barButtonItemNhapLieu,
            this.barButtonItemBaoCao,
            this.barButtonItemXemQKKiemPham});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHeThong});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowCategoryInCaption = false;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(854, 143);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItemCauHinh
            // 
            this.barButtonItemCauHinh.Caption = "Cấu Hình";
            this.barButtonItemCauHinh.Id = 1;
            this.barButtonItemCauHinh.LargeGlyph = global::QLNhapTinh.Properties.Resources.Aroche_Delta_Settings;
            this.barButtonItemCauHinh.Name = "barButtonItemCauHinh";
            // 
            // barButtonItemNhapLieu
            // 
            this.barButtonItemNhapLieu.Caption = "Nhập Liệu";
            this.barButtonItemNhapLieu.Id = 2;
            this.barButtonItemNhapLieu.LargeGlyph = global::QLNhapTinh.Properties.Resources.document_edit;
            this.barButtonItemNhapLieu.Name = "barButtonItemNhapLieu";
            this.barButtonItemNhapLieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNhapLieu_ItemClick);
            // 
            // barButtonItemBaoCao
            // 
            this.barButtonItemBaoCao.Caption = "Báo Cáo";
            this.barButtonItemBaoCao.Id = 3;
            this.barButtonItemBaoCao.LargeGlyph = global::QLNhapTinh.Properties.Resources.Reports;
            this.barButtonItemBaoCao.Name = "barButtonItemBaoCao";
            this.barButtonItemBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBaoCao_ItemClick);
            // 
            // barButtonItemXemQKKiemPham
            // 
            this.barButtonItemXemQKKiemPham.Caption = "Xem Kết Quả Kiểm Phẩm";
            this.barButtonItemXemQKKiemPham.Id = 4;
            this.barButtonItemXemQKKiemPham.LargeGlyph = global::QLNhapTinh.Properties.Resources.view_pim_notes;
            this.barButtonItemXemQKKiemPham.Name = "barButtonItemXemQKKiemPham";
            // 
            // ribbonPageHeThong
            // 
            this.ribbonPageHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupChucNang});
            this.ribbonPageHeThong.Name = "ribbonPageHeThong";
            this.ribbonPageHeThong.Text = "Hệ Thống";
            // 
            // ribbonPageGroupChucNang
            // 
            this.ribbonPageGroupChucNang.ItemLinks.Add(this.barButtonItemNhapLieu);
            this.ribbonPageGroupChucNang.ItemLinks.Add(this.barButtonItemBaoCao);
            this.ribbonPageGroupChucNang.ItemLinks.Add(this.barButtonItemXemQKKiemPham);
            this.ribbonPageGroupChucNang.Name = "ribbonPageGroupChucNang";
            this.ribbonPageGroupChucNang.ShowCaptionButton = false;
            // 
            // labelControlNgayLamViec
            // 
            this.labelControlNgayLamViec.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControlNgayLamViec.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelControlNgayLamViec.Location = new System.Drawing.Point(638, 375);
            this.labelControlNgayLamViec.Name = "labelControlNgayLamViec";
            this.labelControlNgayLamViec.Size = new System.Drawing.Size(154, 16);
            this.labelControlNgayLamViec.TabIndex = 9;
            this.labelControlNgayLamViec.Text = "Ngày làm việc: 18/01/2016";
            // 
            // picLogo
            // 
            this.picLogo.EditValue = global::QLNhapTinh.Properties.Resources.phurieng_logo;
            this.picLogo.Location = new System.Drawing.Point(69, 167);
            this.picLogo.MenuManager = this.ribbonControl;
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogo.Size = new System.Drawing.Size(131, 128);
            this.picLogo.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(290, 257);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(266, 48);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "CHƯƠNG TRÌNH QUẢN LÝ\r\nNHẬP KHO THÀNH PHẨM";
            // 
            // lblNhaMay
            // 
            this.lblNhaMay.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhaMay.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNhaMay.Location = new System.Drawing.Point(291, 190);
            this.lblNhaMay.Name = "lblNhaMay";
            this.lblNhaMay.Size = new System.Drawing.Size(263, 19);
            this.lblNhaMay.TabIndex = 6;
            this.lblNhaMay.Text = "NMCB TRUNG TÂM - DC MỦ TINH";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(267, 165);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(302, 19);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "CÔNG TY TNHH MTV CAO SU PHÚ RIỀNG";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 453);
            this.Controls.Add(this.labelControlNgayLamViec);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblNhaMay);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công Ty Cao Su Phú Riềng";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHeThong;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCauHinh;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNhapLieu;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBaoCao;
        private DevExpress.XtraBars.BarButtonItem barButtonItemXemQKKiemPham;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupChucNang;
        private DevExpress.XtraEditors.LabelControl labelControlNgayLamViec;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblNhaMay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

