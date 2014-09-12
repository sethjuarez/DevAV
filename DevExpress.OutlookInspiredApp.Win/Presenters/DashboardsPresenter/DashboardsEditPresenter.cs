using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;


namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardsEditPresenter : BasePresenter<DashboardsEditViewModel>
    {
        public DashboardsEditPresenter(DashboardsEdit view, DashboardsEditViewModel viewModel)
            : base(viewModel)
        {
            // should consider wiring UI elements from DashboardsEdit
            // into this presenter instance in a more granular way
            View = view;
        }

        public DashboardsEdit View { get; private set; }
    }
}
