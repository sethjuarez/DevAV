using System;
using System.Linq;
using DevExpress.XtraBars.Ribbon;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsEditView : BaseModuleControl, IRibbonModule
    {
        private readonly DashboardEditViewPresenter presenterCore;

        public DashboardsEditView()
            : base(CreateViewModel<DashboardsEditViewViewModel>)
        {
            InitializeComponent();
            presenterCore = CreatePresenter();
            BindCommands();
        }

        protected override void OnParentViewModelAttached()
        {
            // once the view model is constructed
            // completely, we can bind the dashboard
            Presenter.BindDashboard();
        }

        
        private void BindCommands()
        {
            barButtonSave.BindCommand(() => ViewModel.SaveDashboard(), ViewModel);
        }

        public DashboardsEditViewViewModel ViewModel
        {
            get { return GetViewModel<DashboardsEditViewViewModel>(); }
        }

        public DashboardEditViewPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardEditViewPresenter CreatePresenter()
        {
            return new DashboardEditViewPresenter(dashboardDesigner1, ViewModel);
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
    }
}
