namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    partial class DashboardsFilterPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewDashboard = new DevExpress.XtraEditors.SimpleButton();
            this.moduleLayout = new DevExpress.XtraLayout.LayoutControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.treeListLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnNewDashboardLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).BeginInit();
            this.moduleLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewDashboardLayoutControlItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewDashboard
            // 
            this.btnNewDashboard.Image = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_new_employee_16;
            this.btnNewDashboard.Location = new System.Drawing.Point(14, 14);
            this.btnNewDashboard.MaximumSize = new System.Drawing.Size(150, 0);
            this.btnNewDashboard.MinimumSize = new System.Drawing.Size(150, 0);
            this.btnNewDashboard.Name = "btnNewDashboard";
            this.btnNewDashboard.Size = new System.Drawing.Size(150, 22);
            this.btnNewDashboard.StyleController = this.moduleLayout;
            this.btnNewDashboard.TabIndex = 0;
            this.btnNewDashboard.Text = "New Dashboard";
            // 
            // moduleLayout
            // 
            this.moduleLayout.Controls.Add(this.btnNewDashboard);
            this.moduleLayout.Controls.Add(this.treeList);
            this.moduleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleLayout.Location = new System.Drawing.Point(0, 0);
            this.moduleLayout.Name = "moduleLayout";
            this.moduleLayout.Root = this.Root;
            this.moduleLayout.Size = new System.Drawing.Size(239, 455);
            this.moduleLayout.TabIndex = 3;
            // 
            // treeList
            // 
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Location = new System.Drawing.Point(12, 54);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.DragNodes = true;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.Size = new System.Drawing.Size(215, 389);
            this.treeList.TabIndex = 1;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.treeListLayoutControlItem,
            this.btnNewDashboardLayoutControlItem});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 6;
            this.Root.Size = new System.Drawing.Size(239, 455);
            this.Root.Text = "Root";
            // 
            // treeListLayoutControlItem
            // 
            this.treeListLayoutControlItem.Control = this.treeList;
            this.treeListLayoutControlItem.CustomizationFormText = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.Location = new System.Drawing.Point(0, 42);
            this.treeListLayoutControlItem.Name = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.Size = new System.Drawing.Size(219, 393);
            this.treeListLayoutControlItem.Text = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.treeListLayoutControlItem.TextToControlDistance = 0;
            this.treeListLayoutControlItem.TextVisible = false;
            // 
            // btnNewDashboardLayoutControlItem
            // 
            this.btnNewDashboardLayoutControlItem.Control = this.btnNewDashboard;
            this.btnNewDashboardLayoutControlItem.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDashboardLayoutControlItem.CustomizationFormText = "btnNewDashboardLayoutControlItem";
            this.btnNewDashboardLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.btnNewDashboardLayoutControlItem.Name = "btnNewDashboardLayoutControlItem";
            this.btnNewDashboardLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 16);
            this.btnNewDashboardLayoutControlItem.Size = new System.Drawing.Size(219, 42);
            this.btnNewDashboardLayoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.btnNewDashboardLayoutControlItem.Text = "btnNewDashboardLayoutControlItem";
            this.btnNewDashboardLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.btnNewDashboardLayoutControlItem.TextToControlDistance = 0;
            this.btnNewDashboardLayoutControlItem.TextVisible = false;
            this.btnNewDashboardLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // DashboardsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moduleLayout);
            this.Name = "DashboardsPanel";
            this.Size = new System.Drawing.Size(239, 455);
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).EndInit();
            this.moduleLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewDashboardLayoutControlItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraEditors.SimpleButton btnNewDashboard;
        private XtraLayout.LayoutControl moduleLayout;
        private XtraTreeList.TreeList treeList;
        private XtraLayout.LayoutControlGroup Root;
        private XtraLayout.LayoutControlItem treeListLayoutControlItem;
        private XtraLayout.LayoutControlItem btnNewDashboardLayoutControlItem;

    }
}
