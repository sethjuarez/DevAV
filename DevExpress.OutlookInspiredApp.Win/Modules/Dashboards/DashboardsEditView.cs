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
            ViewModel.Dashboard = new DashboardCommon.Dashboard();
            ViewModel.Dashboard.AddDataSource("Opportunities", ViewModel.Orders);
            dashboardDesigner1.Dashboard = ViewModel.Dashboard;
            BindCommands();
        }

        private void BindCommands()
        {
            barButtonSave.BindCommand(() => ViewModel.SaveDashboard(), ViewModel);
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
