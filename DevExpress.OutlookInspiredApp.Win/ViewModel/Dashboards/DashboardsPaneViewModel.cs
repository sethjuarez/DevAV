using System;
using System.Linq;
using DevExpress.Mvvm;
using System.Collections.Generic;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsPaneViewModel
    {
        public DashboardsPaneViewModel()
        {

        }

        public DashboardsPaneViewModel(DashboardsViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }


        public DashboardsViewModel ParentViewModel { get; set; }
    }
}
