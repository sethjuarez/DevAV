using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.OutlookInspiredApp.Win.Modules;
using DevExpress.OutlookInspiredApp.Win.ViewModel;
using DevExpress.DashboardWin;
using DevExpress.Mvvm;
using DevExpress.DashboardCommon;


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
            Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);
        }

        private void OnDashboardMessage(DashboardMessage message)
        {
            if (message.MessageType == DashboardMessageType.View)
                BindDashboard();
            else if (message.MessageType == DashboardMessageType.Save)
                ViewModel.Save(message.Dashboard);
        }



        private void BindDashboard()
        {
            if (ViewModel.CurrentDashboard != string.Empty)
                View.Dashboard = ViewModel.GetCurrentDashboard();
        }

        public DashboardViewer View { get; private set; }
    }
}
