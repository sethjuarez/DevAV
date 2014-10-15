namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    partial class DashboardsPane
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
            this.btnNewDashboards = new DevExpress.XtraEditors.SimpleButton();
            this.moduleLayout = new DevExpress.XtraLayout.LayoutControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.treeListLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnNewDashboardsLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).BeginInit();
            this.moduleLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewDashboardsLayoutControlItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewDashboards
            // 
            this.btnNewDashboards.Image = global::DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_new_employee_16;
            this.btnNewDashboards.Location = new System.Drawing.Point(14, 14);
            this.btnNewDashboards.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewDashboards.MaximumSize = new System.Drawing.Size(225, 0);
            this.btnNewDashboards.MinimumSize = new System.Drawing.Size(225, 0);
            this.btnNewDashboards.Name = "btnNewDashboards";
            this.btnNewDashboards.Size = new System.Drawing.Size(225, 26);
            this.btnNewDashboards.StyleController = this.moduleLayout;
            this.btnNewDashboards.TabIndex = 0;
            this.btnNewDashboards.Text = "New Dashboards";
            // 
            // moduleLayout
            // 
            this.moduleLayout.Controls.Add(this.btnNewDashboards);
            this.moduleLayout.Controls.Add(this.treeList);
            this.moduleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moduleLayout.Location = new System.Drawing.Point(0, 0);
            this.moduleLayout.Margin = new System.Windows.Forms.Padding(4);
            this.moduleLayout.Name = "moduleLayout";
            this.moduleLayout.Root = this.Root;
            this.moduleLayout.Size = new System.Drawing.Size(358, 665);
            this.moduleLayout.TabIndex = 3;
            // 
            // treeList
            // 
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Location = new System.Drawing.Point(12, 58);
            this.treeList.Margin = new System.Windows.Forms.Padding(4);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.DragNodes = true;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowFocusedFrame = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.OptionsSelection.UseIndicatorForSelection = false;
            this.treeList.Size = new System.Drawing.Size(334, 595);
            this.treeList.TabIndex = 1;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.treeListLayoutControlItem,
			this.btnNewDashboardsLayoutControlItem});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 6;
            this.Root.Size = new System.Drawing.Size(358, 665);
            this.Root.Text = "Root";
            // 
            // treeListLayoutControlItem
            // 
            this.treeListLayoutControlItem.Control = this.treeList;
            this.treeListLayoutControlItem.CustomizationFormText = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.Location = new System.Drawing.Point(0, 46);
            this.treeListLayoutControlItem.Name = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.Size = new System.Drawing.Size(338, 599);
            this.treeListLayoutControlItem.Text = "treeListLayoutControlItem";
            this.treeListLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.treeListLayoutControlItem.TextToControlDistance = 0;
            this.treeListLayoutControlItem.TextVisible = false;
            // 
            // btnNewDashboardsLayoutControlItem
            // 
            this.btnNewDashboardsLayoutControlItem.Control = this.btnNewDashboards;
            this.btnNewDashboardsLayoutControlItem.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDashboardsLayoutControlItem.CustomizationFormText = "btnNewDashboardsLayoutControlItem";
            this.btnNewDashboardsLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.btnNewDashboardsLayoutControlItem.Name = "btnNewDashboardsLayoutControlItem";
            this.btnNewDashboardsLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 16);
            this.btnNewDashboardsLayoutControlItem.Size = new System.Drawing.Size(338, 46);
            this.btnNewDashboardsLayoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.btnNewDashboardsLayoutControlItem.Text = "btnNewDashboardsLayoutControlItem";
            this.btnNewDashboardsLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.btnNewDashboardsLayoutControlItem.TextToControlDistance = 0;
            this.btnNewDashboardsLayoutControlItem.TextVisible = false;
            this.btnNewDashboardsLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // DashboardsFilterPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moduleLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardsFilterPane";
            this.Size = new System.Drawing.Size(358, 665);
            ((System.ComponentModel.ISupportInitialize)(this.moduleLayout)).EndInit();
            this.moduleLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewDashboardsLayoutControlItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraEditors.SimpleButton btnNewDashboards;
        private XtraLayout.LayoutControl moduleLayout;
        private XtraTreeList.TreeList treeList;
        private XtraLayout.LayoutControlGroup Root;
        private XtraLayout.LayoutControlItem treeListLayoutControlItem;
        private XtraLayout.LayoutControlItem btnNewDashboardsLayoutControlItem;

    }
}
