namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public partial class QuoteViewModel : QuoteViewModelBase {
        public QuoteViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
    }
    public partial class synchronizedQuoteViewModel : QuoteViewModel {
        protected override bool EnableSelectedItemSynchronization {
            get { return true; }
        }
        protected override bool EnableEntityChangedSynchronization {
            get { return true; }
        }
    }
}
