using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DashboardWin;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.Mvvm;
using DevExpress.DashboardCommon;

namespace DevExpress.OutlookInspiredApp.Win.Presenters
{
    public class DashboardViewPresenter
    {
        private readonly DashboardViewer _viewer;
        public DashboardViewPresenter(DashboardViewer viewer, DashboardsViewModel viewModel)
        {
            ViewModel = viewModel;
            _viewer = viewer;
            Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);
        }

        private void OnDashboardMessage(DashboardMessage message)
        {
            // make sure there is data
            if (ViewModel.Orders == null || ViewModel.Orders.Count() == 0)
                ViewModel.RefreshData();

            switch (message.MessageType)
            {
                case DashboardMessageType.View:
                    View(message.Dashboard);
                    break;
                case DashboardMessageType.Save:
                    Save(message.Dashboard);
                    break;
                case DashboardMessageType.Refresh:
                    // nothing to do here
                    break;
            }

        }

        private void Save(Dashboard dashboard)
        {
            ViewModel.Save(dashboard);
            View(dashboard);
            Messenger.Default.Send<DashboardMessage>(DashboardMessage.Refresh());
        }

        private void View(Dashboard dashboard)
        {
            Clean();
            ViewModel.CurrentDashboardPath = ViewModel.DashboardPath(dashboard);
            _viewer.Dashboard = ViewModel.BindDashboard(dashboard);
        }

        private void Clean()
        {
            // clean up stuff
            if (_viewer.Dashboard != null)
            {
                _viewer.Dashboard.Dispose();
                _viewer.Dashboard = null;
            }
        }

        public DashboardsViewModel ViewModel { get; private set; }

    }
}
