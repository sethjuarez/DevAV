using System;
using System.Linq;
using DevExpress.DashboardWin;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.Mvvm;

namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardEditViewPresenter
    {
        private readonly DashboardDesigner _designer;
        private readonly DashboardsEditViewViewModel _viewModel;

        public DashboardEditViewPresenter(DashboardDesigner designer, DashboardsEditViewViewModel viewModel)
        {
            _viewModel = viewModel;
            _designer = designer;
            _designer.DashboardClosing += designer_DashboardClosing;
        }

        void designer_DashboardClosing(object sender, DashboardClosingEventArgs e)
        {
            e.IsDashboardModified = false;
        }

        public void BindDashboard()
        {
            _designer.Dashboard = ViewModel.Dashboard;
        }

        public DashboardsEditViewViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }
    }
}
