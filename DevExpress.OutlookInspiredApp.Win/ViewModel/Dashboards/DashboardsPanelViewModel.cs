using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsFilterPaneViewModel
    {
        private readonly DashboardsViewModel _viewModel;
        public DashboardsFilterPaneViewModel()
            : this(null)
        {
        }

        public DashboardsFilterPaneViewModel(DashboardsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected void OnSelectedDashboardChanged()
        {
            Messenger.Default.Send<DashboardMessage>(new DashboardMessage(SelectedDashboard));
        }

        public virtual string SelectedDashboard { get; set; }

        public DashboardsViewModel ParentViewModel
        {
            get
            {
                return _viewModel;
            }
        }
    }

    public class DashboardMessage
    {

        private readonly string _dashboard;
        public DashboardMessage(string dashboard)
        {
            _dashboard = dashboard;            
        }

        public string Dashboard
        {
            get
            {
                return _dashboard;
            }
        }
    }
}
