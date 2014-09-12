using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.DashboardWin;


namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardsPresenter : BasePresenter<DashboardsViewModel>
    {
        public DashboardsPresenter(DashboardViewer view, DashboardsViewModel viewModel)
            : base(viewModel)
        {
            // should consider wiring UI elements from Dashboards
            // into this presenter instance in a more granular way
            View = view;
            BindDashboard();
        }

        private void BindDashboard()
        {
            if (ViewModel.CurrentDashboard != string.Empty)
                View.Dashboard = ViewModel.GetCurrentDashboard();
        }

        public DashboardViewer View { get; private set; }
    }
}
