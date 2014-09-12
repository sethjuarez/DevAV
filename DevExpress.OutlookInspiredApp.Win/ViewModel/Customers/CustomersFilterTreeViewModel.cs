namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class CustomersFilterTreeViewModel : FilterTreeViewModel<Customer, Guid, IDevAVDbUnitOfWork> {
        public CustomersFilterTreeViewModel()
            : base(null, null) {
        }
        public CustomersFilterTreeViewModel(CustomerCollectionViewModel collectionViewModel)
            : base(collectionViewModel, new CustomersFilterModelSettings()) {
        }
        protected new CustomerCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as CustomerCollectionViewModel; }
        }
    }
}
