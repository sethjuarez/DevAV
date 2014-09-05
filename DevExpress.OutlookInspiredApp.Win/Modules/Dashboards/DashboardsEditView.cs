using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.OutlookInspiredApp.Win.ViewModel;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsEditView : BaseModuleControl, IRibbonModule
    {
        public DashboardsEditView()
            : base(CreateViewModel<DashboardsEditViewViewModel>)
        {
            InitializeComponent();
            dashboardDesigner1.Dashboard = new DashboardCommon.Dashboard();
            dashboardDesigner1.Dashboard.AddDataSource("Opportunities", ViewModel.Orders);
            BindCommands();
        }

        private void BindCommands()
        {
            
        }

        public DashboardsEditViewViewModel ViewModel
        {
            get { return GetViewModel<DashboardsEditViewViewModel>(); }
        }

        public XtraBars.Ribbon.RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
    }
}
