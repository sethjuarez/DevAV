namespace DevExpress.OutlookInspiredApp.Win.Modules {
    partial class OrderView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.Snap.Core.API.DataSourceInfo dataSourceInfo1 = new DevExpress.Snap.Core.API.DataSourceInfo();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modueLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.buttons = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.snapControl = new DevExpress.Snap.SnapControl();
            this.TitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.ItemForDocument = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForButtons = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modueLayout)).BeginInit();
            this.modueLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DevExpress.DevAV.Order);
            // 
            // modueLayout
            // 
            this.modueLayout.AllowCustomizationMenu = false;
            this.modueLayout.Controls.Add(this.buttons);
            this.modueLayout.Controls.Add(this.snapControl);
            this.modueLayout.Controls.Add(this.TitleLabel);
            this.modueLayout.DataSource = this.bindingSource;
            this.modueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modueLayout.Location = new System.Drawing.Point(0, 0);
            this.modueLayout.Margin = new System.Windows.Forms.Padding(2);
            this.modueLayout.Name = "modueLayout";
            this.modueLayout.Root = this.Root;
            this.modueLayout.Size = new System.Drawing.Size(400, 600);
            this.modueLayout.TabIndex = 0;
            // 
            // buttons
            // 
            this.buttons.AllowGlyphSkinning = false;
            this.buttons.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton(null, global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_edit_16, -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, null, -1, false, false)});
            this.buttons.ContentAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.buttons.Location = new System.Drawing.Point(298, 2);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(100, 33);
            this.buttons.TabIndex = 32;
            this.buttons.UseButtonBackgroundImages = false;
            // 
            // snapControl
            // 
            this.snapControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dataSourceInfo1.DataSource = this.bindingSource;
            dataSourceInfo1.DataSourceName = "";
            this.snapControl.DataSources.Add(dataSourceInfo1);
            this.snapControl.EnableToolTips = true;
            this.snapControl.Location = new System.Drawing.Point(0, 47);
            this.snapControl.Modified = true;
            this.snapControl.Name = "snapControl";
            this.snapControl.Options.CopyPaste.MaintainDocumentSectionSettings = false;
            this.snapControl.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.snapControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.snapControl.Options.SnapMailMergeVisualOptions.DataSourceName = "Employee";
            this.snapControl.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.snapControl.ReadOnly = true;
            this.snapControl.Size = new System.Drawing.Size(400, 553);
            this.snapControl.TabIndex = 19;
            this.snapControl.Views.PrintLayoutView.MaxHorizontalPageCount = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "InvoiceNumber", true));
            this.TitleLabel.Location = new System.Drawing.Point(131, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(124, 37);
            this.TitleLabel.StyleController = this.modueLayout;
            this.TitleLabel.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 6;
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(400, 600);
            this.Root.Text = "Root";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTitle,
            this.simpleSeparator1,
            this.ItemForDocument,
            this.ItemForButtons,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Size = new System.Drawing.Size(400, 600);
            this.layoutControlGroup1.Text = "autoGeneratedGroup0";
            // 
            // ItemForTitle
            // 
            this.ItemForTitle.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.ItemForTitle.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForTitle.Control = this.TitleLabel;
            this.ItemForTitle.CustomizationFormText = "Title";
            this.ItemForTitle.Location = new System.Drawing.Point(0, 0);
            this.ItemForTitle.Name = "ItemForTitle";
            this.ItemForTitle.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForTitle.Size = new System.Drawing.Size(255, 37);
            this.ItemForTitle.Text = "INVOICE #";
            this.ItemForTitle.TextSize = new System.Drawing.Size(125, 37);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 37);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(400, 10);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 8, 0);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // ItemForDocument
            // 
            this.ItemForDocument.Control = this.snapControl;
            this.ItemForDocument.CustomizationFormText = "ItemForDocument";
            this.ItemForDocument.Location = new System.Drawing.Point(0, 47);
            this.ItemForDocument.Name = "ItemForDocument";
            this.ItemForDocument.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForDocument.Size = new System.Drawing.Size(400, 553);
            this.ItemForDocument.Text = "ItemForDocument";
            this.ItemForDocument.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForDocument.TextToControlDistance = 0;
            this.ItemForDocument.TextVisible = false;
            // 
            // ItemForButtons
            // 
            this.ItemForButtons.Control = this.buttons;
            this.ItemForButtons.CustomizationFormText = "ItemForButtons";
            this.ItemForButtons.Location = new System.Drawing.Point(296, 0);
            this.ItemForButtons.MaxSize = new System.Drawing.Size(104, 0);
            this.ItemForButtons.MinSize = new System.Drawing.Size(104, 24);
            this.ItemForButtons.Name = "ItemForButtons";
            this.ItemForButtons.Size = new System.Drawing.Size(104, 37);
            this.ItemForButtons.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForButtons.Text = "ItemForButtons";
            this.ItemForButtons.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForButtons.TextToControlDistance = 0;
            this.ItemForButtons.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(255, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(41, 37);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modueLayout);
            this.Name = "OrderView";
            this.Size = new System.Drawing.Size(400, 600);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modueLayout)).EndInit();
            this.modueLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl modueLayout;
        private XtraEditors.LabelControl TitleLabel;
        private XtraLayout.LayoutControlGroup Root;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private XtraLayout.LayoutControlItem ItemForTitle;
        private XtraLayout.SimpleSeparator simpleSeparator1;
        private Snap.SnapControl snapControl;
        private XtraLayout.LayoutControlItem ItemForDocument;
        private XtraBars.Docking2010.WindowsUIButtonPanel buttons;
        private XtraLayout.LayoutControlItem ItemForButtons;
        private XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
