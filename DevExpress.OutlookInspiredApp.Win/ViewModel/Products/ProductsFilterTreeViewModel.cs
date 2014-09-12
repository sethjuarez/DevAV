namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class ProductsFilterTreeViewModel : FilterTreeViewModel<Product, Guid, IDevAVDbUnitOfWork> {
        public ProductsFilterTreeViewModel()
            : base(null, null) {
        }
        public ProductsFilterTreeViewModel(ProductCollectionViewModel collectionViewModel)
            : base(collectionViewModel, new ProductsFilterModelSettings()) {
        }
        protected new ProductCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as ProductCollectionViewModel; }
        }
    }
}
