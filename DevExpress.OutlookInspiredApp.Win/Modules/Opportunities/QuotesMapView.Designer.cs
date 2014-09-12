namespace DevExpress.OutlookInspiredApp.Win.Modules {
    partial class QuoteMapView {
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
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.ColorIndexColorizer colorIndexColorizer1 = new DevExpress.XtraMap.ColorIndexColorizer();
            DevExpress.XtraMap.BubbleGroupToColorIndexProvider bubbleGroupToColorIndexProvider1 = new DevExpress.XtraMap.BubbleGroupToColorIndexProvider();
            DevExpress.XtraMap.BubbleChartDataAdapter bubbleChartDataAdapter1 = new DevExpress.XtraMap.BubbleChartDataAdapter();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.MapItemStorage mapItemStorage1 = new DevExpress.XtraMap.MapItemStorage();
            DevExpress.XtraMap.MapCallout mapCallout1 = new DevExpress.XtraMap.MapCallout();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biSave = new DevExpress.XtraBars.BarButtonItem();
            this.biClose = new DevExpress.XtraBars.BarButtonItem();
            this.biSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biPrint = new DevExpress.XtraBars.BarButtonItem();
            this.biPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barExportItem = new DevExpress.XtraBars.BarButtonItem();
            this.biHigh = new DevExpress.XtraBars.BarCheckItem();
            this.biMedium = new DevExpress.XtraBars.BarCheckItem();
            this.biLow = new DevExpress.XtraBars.BarCheckItem();
            this.biUnlikely = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.moduleDataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.mapControl = new DevExpress.XtraMap.MapControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMap = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleDataLayout)).BeginInit();
            this.moduleDataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DevExpress.DevAV.ViewModels.Opportunities.MapItem);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biSave,
            this.biClose,
            this.biSaveAndClose,
            this.biDelete,
            this.biPrint,
            this.biPrintPreview,
            this.barExportItem,
            this.biHigh,
            this.biMedium,
            this.biLow,
            this.biUnlikely});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(1226, 121);
            // 
            // biSave
            // 
            this.biSave.Caption = "Save";
            this.biSave.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_save_16;
            this.biSave.Id = 1;
            this.biSave.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_save_32;
            this.biSave.Name = "biSave";
            // 
            // biClose
            // 
            this.biClose.Caption = "Close";
            this.biClose.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_close_16;
            this.biClose.Id = 2;
            this.biClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Escape);
            this.biClose.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_close_32;
            this.biClose.Name = "biClose";
            // 
            // biSaveAndClose
            // 
            this.biSaveAndClose.Caption = "Save && Close";
            this.biSaveAndClose.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_save_close_16;
            this.biSaveAndClose.Id = 3;
            this.biSaveAndClose.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_save_close_32;
            this.biSaveAndClose.Name = "biSaveAndClose";
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Delete";
            this.biDelete.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_delete_16;
            this.biDelete.Id = 4;
            this.biDelete.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_delete_32;
            this.biDelete.Name = "biDelete";
            // 
            // biPrint
            // 
            this.biPrint.Caption = "Print";
            this.biPrint.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_print_16;
            this.biPrint.Id = 8;
            this.biPrint.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_print_32;
            this.biPrint.Name = "biPrint";
            // 
            // biPrintPreview
            // 
            this.biPrintPreview.Caption = "Print Preview";
            this.biPrintPreview.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_print_preview_16;
            this.biPrintPreview.Id = 9;
            this.biPrintPreview.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_print_preview_32;
            this.biPrintPreview.Name = "biPrintPreview";
            // 
            // barExportItem
            // 
            this.barExportItem.Caption = "Export";
            this.barExportItem.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_export_16;
            this.barExportItem.Id = 11;
            this.barExportItem.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_export_32;
            this.barExportItem.LargeImageIndex = 50;
            this.barExportItem.Name = "barExportItem";
            // 
            // biHigh
            // 
            this.biHigh.Caption = "High";
            this.biHigh.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.biHigh.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_hight_16;
            this.biHigh.Id = 16;
            this.biHigh.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_hight_32;
            this.biHigh.Name = "biHigh";
            // 
            // biMedium
            // 
            this.biMedium.Caption = "Medium";
            this.biMedium.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.biMedium.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_medium_16;
            this.biMedium.Id = 17;
            this.biMedium.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_medium_32;
            this.biMedium.Name = "biMedium";
            // 
            // biLow
            // 
            this.biLow.Caption = "Low";
            this.biLow.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.biLow.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_low_16;
            this.biLow.Id = 18;
            this.biLow.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_low_32;
            this.biLow.Name = "biLow";
            // 
            // biUnlikely
            // 
            this.biUnlikely.Caption = "Unlikely";
            this.biUnlikely.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.biUnlikely.Glyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_unlike_16;
            this.biUnlikely.Id = 19;
            this.biUnlikely.LargeGlyph = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_opportunities_unlike_32;
            this.biUnlikely.Name = "biUnlikely";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "HOME";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.biSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.biSaveAndClose);
            this.ribbonPageGroup1.MergeOrder = 0;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.biDelete);
            this.ribbonPageGroup2.MergeOrder = 0;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Delete";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.AllowTextClipping = false;
            this.ribbonPageGroup5.ItemLinks.Add(this.biPrintPreview);
            this.ribbonPageGroup5.ItemLinks.Add(this.biPrint);
            this.ribbonPageGroup5.ItemLinks.Add(this.barExportItem);
            this.ribbonPageGroup5.MergeOrder = 0;
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            this.ribbonPageGroup5.Text = "Print and Export";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.biHigh);
            this.ribbonPageGroup4.ItemLinks.Add(this.biMedium);
            this.ribbonPageGroup4.ItemLinks.Add(this.biLow);
            this.ribbonPageGroup4.ItemLinks.Add(this.biUnlikely);
            this.ribbonPageGroup4.MergeOrder = 0;
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Opportunities";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.biClose);
            this.ribbonPageGroup3.MergeOrder = 0;
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Close";
            // 
            // moduleDataLayout
            // 
            this.moduleDataLayout.AllowCustomizationMenu = false;
            this.moduleDataLayout.Controls.Add(this.mapControl);
            this.moduleDataLayout.DataSource = this.bindingSource;
            this.moduleDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleDataLayout.Location = new System.Drawing.Point(0, 121);
            this.moduleDataLayout.Name = "moduleDataLayout";
            this.moduleDataLayout.Root = this.layoutControlGroup1;
            this.moduleDataLayout.Size = new System.Drawing.Size(1226, 641);
            this.moduleDataLayout.TabIndex = 2;
            this.moduleDataLayout.Text = "moduleDataLayout";
            // 
            // mapControl
            // 
            this.mapControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Default;
            bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Road;
            imageTilesLayer1.DataProvider = bingMapDataProvider1;
            colorIndexColorizer1.ColorIndexProvider = bubbleGroupToColorIndexProvider1;
            vectorItemsLayer1.Colorizer = colorIndexColorizer1;
            bubbleChartDataAdapter1.BubbleItemDataMember = "City";
            bubbleChartDataAdapter1.DataSource = this.bindingSource;
            bubbleChartDataAdapter1.Mappings.BubbleGroup = "Index";
            bubbleChartDataAdapter1.Mappings.Latitude = "Latitude";
            bubbleChartDataAdapter1.Mappings.Longitude = "Longitude";
            bubbleChartDataAdapter1.Mappings.Value = "Value";
            vectorItemsLayer1.Data = bubbleChartDataAdapter1;
            vectorItemsLayer1.ToolTipPattern = "City:%CI% Value:%CV%";
            mapCallout1.AllowHtmlText = true;
            mapCallout1.Text = "Test";
            mapItemStorage1.Items.Add(mapCallout1);
            vectorItemsLayer2.Data = mapItemStorage1;
            this.mapControl.Layers.Add(imageTilesLayer1);
            this.mapControl.Layers.Add(vectorItemsLayer1);
            this.mapControl.Layers.Add(vectorItemsLayer2);
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(1222, 641);
            this.mapControl.TabIndex = 18;
            this.mapControl.ZoomLevel = 8D;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMap,
            this.simpleSeparator1,
            this.simpleSeparator2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1226, 641);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForMap
            // 
            this.ItemForMap.Control = this.mapControl;
            this.ItemForMap.CustomizationFormText = "map";
            this.ItemForMap.Location = new System.Drawing.Point(0, 0);
            this.ItemForMap.Name = "layoutControlItem1";
            this.ItemForMap.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForMap.Size = new System.Drawing.Size(1222, 641);
            this.ItemForMap.Text = "map";
            this.ItemForMap.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForMap.TextToControlDistance = 0;
            this.ItemForMap.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(1224, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 641);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
            this.simpleSeparator2.Location = new System.Drawing.Point(1222, 0);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(2, 641);
            this.simpleSeparator2.Text = "simpleSeparator2";
            // 
            // QuoteMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moduleDataLayout);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "QuoteMapView";
            this.Size = new System.Drawing.Size(1226, 762);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moduleDataLayout)).EndInit();
            this.moduleDataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private XtraBars.Ribbon.RibbonControl ribbonControl;
        private XtraBars.BarButtonItem biSave;
        private XtraBars.BarButtonItem biClose;
        private XtraBars.BarButtonItem biSaveAndClose;
        private XtraBars.BarButtonItem biDelete;
        private XtraBars.BarButtonItem biPrint;
        private XtraBars.BarButtonItem biPrintPreview;
        private XtraBars.BarButtonItem barExportItem;
        private XtraBars.Ribbon.RibbonPage ribbonPage1;
        private XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private XtraDataLayout.DataLayoutControl moduleDataLayout;
        private XtraMap.MapControl mapControl;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private XtraLayout.LayoutControlItem ItemForMap;
        private XtraLayout.SimpleSeparator simpleSeparator1;
        private XtraLayout.SimpleSeparator simpleSeparator2;
        private XtraBars.BarCheckItem biHigh;
        private XtraBars.BarCheckItem biMedium;
        private XtraBars.BarCheckItem biLow;
        private XtraBars.BarCheckItem biUnlikely;
        private XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}
