using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;


namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class DashboardsEdit : BaseModuleControl, IRibbonModule
    {
        private readonly DashboardsEditPresenter presenterCore;
        public DashboardsEdit()
            : base(CreateViewModel<DashboardsEditViewModel>)
        {
            InitializeComponent();
            presenterCore = CreatePresenter();
            BindCommands();
        }

        public DashboardsEditViewModel ViewModel
        {
            get { return GetViewModel<DashboardsEditViewModel>(); }
        }

        public DashboardsEditPresenter Presenter
        {
            get { return presenterCore; }
        }

        protected virtual DashboardsEditPresenter CreatePresenter()
        {
            return new DashboardsEditPresenter(this, ViewModel);
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }


        private void BindCommands()
        {
            // bind commands to DashboardsEditViewModel here

        }
    }
}
