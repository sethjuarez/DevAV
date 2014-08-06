namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class QuotesFilterTreeViewModel : FilterTreeViewModel<Quote, Guid, IDevAVDbUnitOfWork> {
        public QuotesFilterTreeViewModel()
            : base(null, null) {
        }
        public QuotesFilterTreeViewModel(QuoteCollectionViewModel collectionViewModel)
            : base(collectionViewModel, new QuotesFilterModelSettings()) {
        }
        protected new QuoteCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as QuoteCollectionViewModel; }
        }
        protected override bool EnableGroups {
            get { return false; }
        }
    }
}
