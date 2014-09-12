using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;


namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardsPresenter : BasePresenter<DashboardsViewModel>
    {
        public DashboardsPresenter(Dashboards view, DashboardsViewModel viewModel)
            : base(viewModel)
        {
            // should consider wiring UI elements from Dashboards
            // into this presenter instance in a more granular way
            View = view;
        }

        public Dashboards View { get; private set; }
    }
}
