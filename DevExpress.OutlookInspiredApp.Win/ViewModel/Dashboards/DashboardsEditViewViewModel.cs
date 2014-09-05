using System;
using System.IO;
using System.Linq;
using DevExpress.Mvvm;
using System.Collections.Generic;
using DevExpress.DashboardCommon;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsEditViewViewModel : ISupportParameter, IDisposable
    {
        [Command]
        public void SaveDashboard()
        {
            // let's tell everyone we want to save this dashboard
            var message = new DashboardMessage(Dashboard, DashboardMessageType.Save);
            Messenger.Default.Send<DashboardMessage>(message);
        }

        public Dashboard Dashboard
        {
            get
            {
                return Parameter is Dashboard ? Parameter as Dashboard : null;
            }
        }

        public virtual object Parameter { get; set; }

        public void Dispose()
        {
            if (Parameter is Dashboard)
            {
                var dashboard = (Dashboard)Parameter;
                if (dashboard != null)
                {
                    dashboard.Dispose();
                    dashboard = null;
                }
            }
        }
    }
}
