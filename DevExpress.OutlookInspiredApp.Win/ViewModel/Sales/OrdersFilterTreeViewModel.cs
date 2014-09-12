namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class OrdersFilterTreeViewModel : FilterTreeViewModel<Order, Guid, IDevAVDbUnitOfWork> {
        public OrdersFilterTreeViewModel()
            : base(null, null) {
        }
        public OrdersFilterTreeViewModel(OrderCollectionViewModel collectionViewModel)
            : base(collectionViewModel, new OrdersFilterModelSettings()) {
        }
        protected new OrderCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as OrderCollectionViewModel; }
        }
        protected override bool EnableGroups {
            get { return false; }
        }
    }
}
