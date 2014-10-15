using System;
<<<<<<< HEAD
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
=======
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.OutlookInspiredApp.Win.Presenters;
using DevExpress.Mvvm;

>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8

namespace DevExpress.OutlookInspiredApp.Win.Modules
{
    public partial class Dashboards : BaseModuleControl, IRibbonModule
    {
<<<<<<< HEAD
        private readonly DashboardViewPresenter presenterCore;
=======
        private readonly DashboardsPresenter presenterCore;
>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8
        public Dashboards()
            : base(CreateViewModel<DashboardsViewModel>)
        {
            InitializeComponent();
            presenterCore = CreatePresenter();
            BindCommands();
        }

<<<<<<< HEAD
        protected override void OnInitServices(IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new DetailFormDocumentManagerService(ModuleType.DashboardsEditView));
        }
=======
         protected override void OnInitServices(IServiceContainer serviceContainer)
         {
        		base.OnInitServices(serviceContainer);
        		serviceContainer.RegisterService(new DetailFormDocumentManagerService(ModuleType.DashboardsEdit));
         }
>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8

        public DashboardsViewModel ViewModel
        {
            get { return GetViewModel<DashboardsViewModel>(); }
        }

<<<<<<< HEAD
        public DashboardViewPresenter Presenter
=======
        public DashboardsPresenter Presenter
>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8
        {
            get { return presenterCore; }
        }

<<<<<<< HEAD
        protected virtual DashboardViewPresenter CreatePresenter()
        {
            return new DashboardViewPresenter(dashboardViewer1, ViewModel);
        }

        private void BindCommands()
        {
            barButtonNewDashboard.BindCommand(() => ViewModel.ShowNewDashboard(), ViewModel);
            barButtonEdit.BindCommand(() => ViewModel.EditDashboard(), ViewModel);
=======
        protected virtual DashboardsPresenter CreatePresenter()
        {
            return new DashboardsPresenter(dashboardViewer1, ViewModel);
>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8
        }

        public RibbonControl Ribbon
        {
            get { return ribbonControl1; }
        }
<<<<<<< HEAD
    }


=======


        private void BindCommands()
        {
            barButtonNew.BindCommand(() => ViewModel.NewDashboard(), ViewModel);
            barButtonEdit.BindCommand(() => ViewModel.EditDashboard(), ViewModel);
        }
    }
>>>>>>> 58d5963b05133ab1068392b2084d015cb969dfb8
}
