using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsFilterPaneViewModel
    {
        private readonly DashboardsViewModel _viewModel;
        public DashboardsFilterPaneViewModel(DashboardsViewModel viewModel)
        {
            _viewModel = viewModel;      
        }
    }
}
