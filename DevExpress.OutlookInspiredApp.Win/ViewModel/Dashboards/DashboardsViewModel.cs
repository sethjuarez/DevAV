using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsViewModel
    {
        public DashboardsViewModel()
        {
            Messenger.Default.Register<DashboardMessage>(this, OnDashboardMessage);
        }

        [ServiceProperty]
        public virtual IDocumentManagerService DocumentManagerService
        {
            get
            {
                return null;
            }
        }

       [Command]
        public void ShowNewDashboard()
        {
            var document = DocumentManagerService.CreateDocument("DashboardEditor", null, this);
            if (document != null)
                document.Show();
        }

        private void OnDashboardMessage(DashboardMessage message)
        {
            // do dashboard wiring
        }
    }
}
