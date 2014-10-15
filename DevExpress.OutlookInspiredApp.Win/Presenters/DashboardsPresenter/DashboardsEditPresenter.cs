using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.DashboardWin;
using DevExpress.DashboardCommon;


namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardsEditPresenter : BasePresenter<DashboardsEditViewModel>
    {
        public DashboardsEditPresenter(DashboardDesigner view, DashboardsEditViewModel viewModel)
            : base(viewModel)
        {
            // should consider wiring UI elements from DashboardsEdit
            // into this presenter instance in a more granular way
            View = view;
            View.DashboardClosing += View_DashboardClosing;
        }

        void View_DashboardClosing(object sender, DashboardClosingEventArgs e)
        {
            e.IsDashboardModified = false;
        }

        public void BindDashboard()
        {
            View.Dashboard = ViewModel.Parameter as Dashboard;
        }

        public DashboardDesigner View { get; private set; }
    }
}
