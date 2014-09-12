namespace DevExpress.OutlookInspiredApp.Win.Modules {
    partial class EmployeeView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeView));
            this.images = new DevExpress.Utils.ImageCollection(this.components);
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modueLayout = new DevExpress.XtraLayout.LayoutControl();
            this.gcEvaluations = new DevExpress.XtraGrid.GridControl();
            this.gvEvaluations = new DevExpress.OutlookInspiredApp.Win.TaskPreviewGridView();
            this.colCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbTasks = new DevExpress.XtraEditors.LabelControl();
            this.lbSeparator = new DevExpress.XtraEditors.LabelControl();
            this.lbEvaluations = new DevExpress.XtraEditors.LabelControl();
            this.gcTasks = new DevExpress.XtraGrid.GridControl();
            this.gvTasks = new DevExpress.OutlookInspiredApp.Win.TaskPreviewGridView();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.buttonImages = new System.Windows.Forms.ImageList(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPhoto = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciTasks = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.sliName = new DevExpress.XtraLayout.SimpleLabelItem();
            this.sliTitle = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciEvaluations = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modueLayout)).BeginInit();
            this.modueLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEvaluations)).BeginInit();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.InsertImage(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.glyph_message_16, "glyph_message_16", typeof(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources), 0);
            this.images.Images.SetKeyName(0, "glyph_message_16");
            this.images.InsertImage(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.glyph_phone_16, "glyph_phone_16", typeof(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources), 1);
            this.images.Images.SetKeyName(1, "glyph_phone_16");
            this.images.InsertImage(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.glyph_video_16, "glyph_video_16", typeof(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources), 2);
            this.images.Images.SetKeyName(2, "glyph_video_16");
            this.images.InsertImage(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.glyph_mail_16, "glyph_mail_16", typeof(global::DevExpress.OutlookInspiredApp.Win.Properties.Resources), 3);
            this.images.Images.SetKeyName(3, "glyph_mail_16");
            // 
            // pictureEdit
            // 
            this.pictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Photo", true));
            this.pictureEdit.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.AllowFocused = false;
            this.pictureEdit.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.pictureEdit.Properties.ReadOnly = true;
            this.pictureEdit.Properties.ShowMenu = false;
            this.pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit.Size = new System.Drawing.Size(130, 130);
            this.pictureEdit.StyleController = this.modueLayout;
            this.pictureEdit.TabIndex = 0;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DevExpress.DevAV.Employee);
            // 
            // modueLayout
            // 
            this.modueLayout.AllowCustomizationMenu = false;
            this.modueLayout.Controls.Add(this.gcEvaluations);
            this.modueLayout.Controls.Add(this.lbTasks);
            this.modueLayout.Controls.Add(this.lbSeparator);
            this.modueLayout.Controls.Add(this.lbEvaluations);
            this.modueLayout.Controls.Add(this.gcTasks);
            this.modueLayout.Controls.Add(this.buttonPanel);
            this.modueLayout.Controls.Add(this.pictureEdit);
            this.modueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modueLayout.Location = new System.Drawing.Point(0, 0);
            this.modueLayout.Name = "modueLayout";
            this.modueLayout.Root = this.layoutControlGroup1;
            this.modueLayout.Size = new System.Drawing.Size(578, 593);
            this.modueLayout.TabIndex = 1;
            this.modueLayout.Text = "modueLayout";
            // 
            // gcEvaluations
            // 
            this.gcEvaluations.Location = new System.Drawing.Point(289, 177);
            this.gcEvaluations.MainView = this.gvEvaluations;
            this.gcEvaluations.Name = "gcEvaluations";
            this.gcEvaluations.Size = new System.Drawing.Size(289, 416);
            this.gcEvaluations.TabIndex = 9;
            this.gcEvaluations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEvaluations});
            // 
            // gvEvaluations
            // 
            this.gvEvaluations.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedOn,
            this.colSubject1,
            this.colCreatedBy});
            this.gvEvaluations.GridControl = this.gcEvaluations;
            this.gvEvaluations.Name = "gvEvaluations";
            this.gvEvaluations.PreviewFieldName = "Details";
            this.gvEvaluations.PreviewIndent = 0;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedOn.AppearanceCell.Options.UseFont = true;
            this.colCreatedOn.Caption = "CREATED ON";
            this.colCreatedOn.FieldName = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.OptionsColumn.AllowEdit = false;
            this.colCreatedOn.OptionsColumn.AllowFocus = false;
            this.colCreatedOn.Visible = true;
            this.colCreatedOn.VisibleIndex = 0;
            this.colCreatedOn.Width = 90;
            // 
            // colSubject1
            // 
            this.colSubject1.Caption = "SUBJECT";
            this.colSubject1.FieldName = "Subject";
            this.colSubject1.Name = "colSubject1";
            this.colSubject1.OptionsColumn.AllowEdit = false;
            this.colSubject1.OptionsColumn.AllowFocus = false;
            this.colSubject1.Visible = true;
            this.colSubject1.VisibleIndex = 1;
            this.colSubject1.Width = 238;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "MANAGER";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.OptionsColumn.AllowFocus = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 2;
            this.colCreatedBy.Width = 228;
            // 
            // lbTasks
            // 
            this.lbTasks.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTasks.Location = new System.Drawing.Point(539, 158);
            this.lbTasks.Name = "lbTasks";
            this.lbTasks.Size = new System.Drawing.Size(37, 17);
            this.lbTasks.StyleController = this.modueLayout;
            this.lbTasks.TabIndex = 8;
            this.lbTasks.Text = "TASKS";
            // 
            // lbSeparator
            // 
            this.lbSeparator.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSeparator.Location = new System.Drawing.Point(528, 158);
            this.lbSeparator.Name = "lbSeparator";
            this.lbSeparator.Size = new System.Drawing.Size(3, 17);
            this.lbSeparator.StyleController = this.modueLayout;
            this.lbSeparator.TabIndex = 7;
            this.lbSeparator.Text = "|";
            // 
            // lbEvaluations
            // 
            this.lbEvaluations.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEvaluations.Location = new System.Drawing.Point(437, 158);
            this.lbEvaluations.Name = "lbEvaluations";
            this.lbEvaluations.Size = new System.Drawing.Size(83, 17);
            this.lbEvaluations.StyleController = this.modueLayout;
            this.lbEvaluations.TabIndex = 6;
            this.lbEvaluations.Text = "EVALUATIONS";
            // 
            // gcTasks
            // 
            this.gcTasks.Location = new System.Drawing.Point(0, 177);
            this.gcTasks.MainView = this.gvTasks;
            this.gcTasks.Name = "gcTasks";
            this.gcTasks.Size = new System.Drawing.Size(289, 416);
            this.gcTasks.TabIndex = 5;
            this.gcTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTasks});
            // 
            // gvTasks
            // 
            this.gvTasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDueDate,
            this.colSubject,
            this.colDescription});
            this.gvTasks.GridControl = this.gcTasks;
            this.gvTasks.Name = "gvTasks";
            this.gvTasks.PreviewFieldName = "Description";
            this.gvTasks.PreviewIndent = 0;
            // 
            // colDueDate
            // 
            this.colDueDate.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDueDate.AppearanceCell.Options.UseFont = true;
            this.colDueDate.Caption = "DUE DATE";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.OptionsColumn.AllowEdit = false;
            this.colDueDate.OptionsColumn.AllowFocus = false;
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 0;
            this.colDueDate.Width = 116;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "SUBJECT";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsColumn.AllowEdit = false;
            this.colSubject.OptionsColumn.AllowFocus = false;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;
            this.colSubject.Width = 221;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "DESCRIPTION";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.ShowInCustomizationForm = false;
            this.colDescription.OptionsFilter.AllowFilter = false;
            this.colDescription.Width = 504;
            // 
            // buttonPanel
            // 
            this.buttonPanel.ButtonBackgroundImages = this.buttonImages;
            this.buttonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", null, 0, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", null, 1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", null, 2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", null, 3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1)});
            this.buttonPanel.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPanel.Images = this.images;
            this.buttonPanel.Location = new System.Drawing.Point(144, 84);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(420, 28);
            this.buttonPanel.TabIndex = 4;
            this.buttonPanel.Text = "windowsUIButtonPanel1";
            // 
            // buttonImages
            // 
            this.buttonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonImages.ImageStream")));
            this.buttonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.buttonImages.Images.SetKeyName(0, "glyph-backg-normal.png");
            this.buttonImages.Images.SetKeyName(1, "glyph-backg-hover.png");
            this.buttonImages.Images.SetKeyName(2, "glyph-backg-pressed.png");
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPhoto,
            this.simpleSeparator1,
            this.emptySpaceItem2,
            this.lciTasks,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlGroup2,
            this.lciEvaluations});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(578, 593);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForPhoto
            // 
            this.ItemForPhoto.Control = this.pictureEdit;
            this.ItemForPhoto.CustomizationFormText = "ItemForPhoto";
            this.ItemForPhoto.Location = new System.Drawing.Point(0, 0);
            this.ItemForPhoto.MaxSize = new System.Drawing.Size(130, 130);
            this.ItemForPhoto.MinSize = new System.Drawing.Size(130, 130);
            this.ItemForPhoto.Name = "ItemForPhoto";
            this.ItemForPhoto.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForPhoto.Size = new System.Drawing.Size(130, 136);
            this.ItemForPhoto.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForPhoto.Text = "ItemForPhoto";
            this.ItemForPhoto.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPhoto.TextToControlDistance = 0;
            this.ItemForPhoto.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 146);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 10);
            this.simpleSeparator1.Size = new System.Drawing.Size(578, 2);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 136);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(578, 10);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciTasks
            // 
            this.lciTasks.Control = this.gcTasks;
            this.lciTasks.CustomizationFormText = "lciTasks";
            this.lciTasks.Location = new System.Drawing.Point(0, 177);
            this.lciTasks.Name = "lciTasks";
            this.lciTasks.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciTasks.Size = new System.Drawing.Size(289, 416);
            this.lciTasks.Text = "lciTasks";
            this.lciTasks.TextSize = new System.Drawing.Size(0, 0);
            this.lciTasks.TextToControlDistance = 0;
            this.lciTasks.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 148);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(435, 29);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lbEvaluations;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(435, 148);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(87, 29);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lbSeparator;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(522, 148);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 10, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(15, 29);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lbTasks;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(537, 148);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(41, 29);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.sliName,
            this.sliTitle,
            this.layoutControlItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(130, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(448, 136);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            // 
            // sliName
            // 
            this.sliName.AllowHotTrack = false;
            this.sliName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sliName.AppearanceItemCaption.Options.UseFont = true;
            this.sliName.CustomizationFormText = "Name";
            this.sliName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FullNameBindable", true));
            this.sliName.Location = new System.Drawing.Point(0, 0);
            this.sliName.Name = "sliName";
            this.sliName.Size = new System.Drawing.Size(424, 41);
            this.sliName.Text = "Name";
            this.sliName.TextSize = new System.Drawing.Size(71, 37);
            // 
            // sliTitle
            // 
            this.sliTitle.AllowHotTrack = false;
            this.sliTitle.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sliTitle.AppearanceItemCaption.Options.UseFont = true;
            this.sliTitle.CustomizationFormText = "Title";
            this.sliTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Title", true));
            this.sliTitle.Location = new System.Drawing.Point(0, 41);
            this.sliTitle.Name = "sliTitle";
            this.sliTitle.Size = new System.Drawing.Size(424, 29);
            this.sliTitle.Text = "Title";
            this.sliTitle.TextSize = new System.Drawing.Size(71, 25);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonPanel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 70);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(1, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(424, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(424, 10);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciEvaluations
            // 
            this.lciEvaluations.Control = this.gcEvaluations;
            this.lciEvaluations.CustomizationFormText = "lciEvaluations";
            this.lciEvaluations.Location = new System.Drawing.Point(289, 177);
            this.lciEvaluations.Name = "lciEvaluations";
            this.lciEvaluations.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciEvaluations.Size = new System.Drawing.Size(289, 416);
            this.lciEvaluations.Text = "lciEvaluations";
            this.lciEvaluations.TextSize = new System.Drawing.Size(0, 0);
            this.lciEvaluations.TextToControlDistance = 0;
            this.lciEvaluations.TextVisible = false;
            this.lciEvaluations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modueLayout);
            this.Name = "EmployeeView";
            this.Size = new System.Drawing.Size(578, 593);
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modueLayout)).EndInit();
            this.modueLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEvaluations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        private System.Windows.Forms.BindingSource bindingSource;
        private XtraLayout.LayoutControl modueLayout;
        private XtraBars.Docking2010.WindowsUIButtonPanel buttonPanel;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private XtraLayout.LayoutControlItem ItemForPhoto;
        private XtraLayout.SimpleLabelItem sliName;
        private XtraLayout.SimpleLabelItem sliTitle;
        private XtraLayout.LayoutControlItem layoutControlItem2;
        private XtraLayout.SimpleSeparator simpleSeparator1;
        private XtraLayout.EmptySpaceItem emptySpaceItem2;
        private XtraGrid.GridControl gcTasks;
        private XtraGrid.Columns.GridColumn colDueDate;
        private XtraGrid.Columns.GridColumn colSubject;
        private XtraLayout.LayoutControlItem lciTasks;
        private TaskPreviewGridView gvTasks;
        private XtraEditors.LabelControl lbTasks;
        private XtraEditors.LabelControl lbSeparator;
        private XtraEditors.LabelControl lbEvaluations;
        private XtraLayout.EmptySpaceItem emptySpaceItem1;
        private XtraLayout.LayoutControlItem layoutControlItem4;
        private XtraLayout.LayoutControlItem layoutControlItem5;
        private XtraLayout.LayoutControlItem layoutControlItem6;
        private XtraGrid.GridControl gcEvaluations;
        private XtraLayout.LayoutControlItem lciEvaluations;
        private XtraGrid.Columns.GridColumn colCreatedOn;
        private XtraGrid.Columns.GridColumn colSubject1;
        private XtraGrid.Columns.GridColumn colCreatedBy;
        private TaskPreviewGridView gvEvaluations;
        private DevExpress.Utils.ImageCollection images;
        private XtraLayout.LayoutControlGroup layoutControlGroup2;
        private XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.ImageList buttonImages;
        private XtraGrid.Columns.GridColumn colDescription;
    }
}
