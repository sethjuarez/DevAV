using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.Mvvm;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class Dashboards : BaseModuleControl, IRibbonModule
    {
        public Dashboards()
            : base(CreateViewModel<DashboardsViewModel>)
        {
            InitializeComponent();
            BindCommands();
        }

        protected override void OnInitServices(IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new DetailFormDocumentManagerService(ModuleType.DashboardsEditView));
        }

        public DashboardsViewModel ViewModel
        {
            get { return GetViewModel<DashboardsViewModel>(); }
        }

        private void BindCommands()
        {
            barButtonNewDashboard.BindCommand(() => ViewModel.ShowNewDashboard(), ViewModel);
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
    }


}
