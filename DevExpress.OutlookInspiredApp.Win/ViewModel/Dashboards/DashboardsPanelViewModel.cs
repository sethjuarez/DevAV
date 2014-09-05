using System;
using System.Linq;
using DevExpress.Mvvm;
using System.Collections.Generic;
using DevExpress.DashboardCommon;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsFilterPaneViewModel
    {
        private readonly DashboardsViewModel _parentViewModel;
        public DashboardsFilterPaneViewModel()
            : this(null)
        {
            
        }

        public DashboardsFilterPaneViewModel(DashboardsViewModel parentViewModel)
        {
            _parentViewModel = parentViewModel;
        }

        protected void OnSelectedDashboardChanged()
        {
            Dashboard d = new Dashboard();
            d.LoadFromXml(SelectedDashboard);
            var message = new DashboardMessage(d, DashboardMessageType.View);
            Messenger.Default.Send<DashboardMessage>(message);
        }

        public virtual string SelectedDashboard { get; set; }

        public DashboardsViewModel ParentViewModel
        {
            get
            {
                return _parentViewModel;
            }
        }
    }
}
