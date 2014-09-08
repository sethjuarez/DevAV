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
using DevExpress.OutlookInspiredApp.Win.Presenters;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class Dashboards : BaseModuleControl, IRibbonModule
    {
        private readonly DashboardViewPresenter presenterCore;
        public Dashboards()
            : base(CreateViewModel<DashboardsViewModel>)
        {
            InitializeComponent();
            presenterCore = CreatePresenter();
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

        public DashboardViewPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardViewPresenter CreatePresenter()
        {
            return new DashboardViewPresenter(dashboardViewer1, ViewModel);
        }

        private void BindCommands()
        {
            barButtonNewDashboard.BindCommand(() => ViewModel.ShowNewDashboard(), ViewModel);
            barButtonEdit.BindCommand(() => ViewModel.EditDashboard(), ViewModel);
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
    }


}
