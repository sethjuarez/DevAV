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
                ViewModel.Refresh();

            switch (message.MessageType)
            {
                case DashboardMessageType.View:
                    ViewDashboard(message.Dashboard);
                    break;
                case DashboardMessageType.Edit:
                    ViewModel.Edit(message.Dashboard);
                    break;
                case DashboardMessageType.Save:
                    ViewModel.Save(message.Dashboard);
                    break;
                case DashboardMessageType.Refresh:
                    ViewModel.Refresh();
                    break;
            }

        }

        private void ViewDashboard(Dashboard dashboard)
        {
            // clean up stuff
            if(_viewer.Dashboard != null)
            {
                _viewer.Dashboard.Dispose();
                _viewer.Dashboard = null;
            }

            if (dashboard.DataSources.Count() == 0)
                dashboard.AddDataSource(DashboardsViewModel.DataSourceName, ViewModel.Orders);
            else if (dashboard.DataSources[0].Name == DashboardsViewModel.DataSourceName)
                dashboard.DataSources[0].Data = ViewModel.Orders;

            _viewer.Dashboard = dashboard;
        }

        public DashboardsViewModel ViewModel { get; private set; }

    }
}
