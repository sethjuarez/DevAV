using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;
using DevExpress.Mvvm;


namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class Dashboards : BaseModuleControl, IRibbonModule
    {
        private readonly DashboardsPresenter presenterCore;
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
        		serviceContainer.RegisterService(new DetailFormDocumentManagerService(ModuleType.DashboardsEdit));
         }

        public DashboardsViewModel ViewModel
        {
            get { return GetViewModel<DashboardsViewModel>(); }
        }

        public DashboardsPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardsPresenter CreatePresenter()
        {
            return new DashboardsPresenter(dashboardViewer1, ViewModel);
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }


        private void BindCommands()
        {
            barButtonNew.BindCommand(() => ViewModel.NewDashboard(), ViewModel);
            barButtonEdit.BindCommand(() => ViewModel.EditDashboard(), ViewModel);
        }
    }
}
