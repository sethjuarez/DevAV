using DevExpress.DevAV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsEditViewViewModel
    {
        private IList<DevExpress.DevAV.Quote> _entities;
        private readonly QuoteCollectionViewModel _quotes;
        public DashboardsEditViewViewModel()
        {
            _quotes = DevExpress.Mvvm.POCO.ViewModelSource.Create<QuoteCollectionViewModel>();
            _entities = _quotes.Entities;
        }


        public virtual IList<DevExpress.DevAV.Quote> Entities
        {
            get
            {
                return _entities;
            }
        }
        


    }
}
