namespace DevExpress.OutlookInspiredApp.Win.Presenters {
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraTreeList;

    public class EmployeeFilterTreeListPresenter : FilterTreeListPresenter<DevAV.Employee, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public EmployeeFilterTreeListPresenter(TreeList treeList, EmployeesFilterTreeViewModel viewModel)
            : base(treeList, viewModel) {
        }
        public new EmployeeCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as EmployeeCollectionViewModel; }
        }
        protected override void SubscribeCollectionViewModelEvents() {
            base.SubscribeCollectionViewModelEvents();
            CollectionViewModel.CustomFilter += CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup += CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection += CollectionViewModel_CustomGroupFromSelection;
        }
        protected override void UnsubscribeCollectionViewModelEvents() {
            CollectionViewModel.CustomFilter -= CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup -= CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection -= CollectionViewModel_CustomGroupFromSelection;
            base.UnsubscribeCollectionViewModelEvents();
        }
    }
    //
    public class CustomerFilterTreeListPresenter : FilterTreeListPresenter<DevAV.Customer, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public CustomerFilterTreeListPresenter(TreeList treeList, CustomersFilterTreeViewModel viewModel)
            : base(treeList, viewModel) {
        }
        public new CustomerCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as CustomerCollectionViewModel; }
        }
        protected override void SubscribeCollectionViewModelEvents() {
            base.SubscribeCollectionViewModelEvents();
            CollectionViewModel.CustomFilter += CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup += CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection += CollectionViewModel_CustomGroupFromSelection;
        }
        protected override void UnsubscribeCollectionViewModelEvents() {
            CollectionViewModel.CustomFilter -= CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup -= CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection -= CollectionViewModel_CustomGroupFromSelection;
            base.UnsubscribeCollectionViewModelEvents();
        }
    }
    //
    public class ProductFilterTreeListPresenter : FilterTreeListPresenter<DevAV.Product, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public ProductFilterTreeListPresenter(TreeList treeList, ProductsFilterTreeViewModel viewModel)
            : base(treeList, viewModel) {
        }
        public new ProductCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as ProductCollectionViewModel; }
        }
        protected override void SubscribeCollectionViewModelEvents() {
            base.SubscribeCollectionViewModelEvents();
            CollectionViewModel.CustomFilter += CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup += CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection += CollectionViewModel_CustomGroupFromSelection;
        }
        protected override void UnsubscribeCollectionViewModelEvents() {
            CollectionViewModel.CustomFilter -= CollectionViewModel_CustomFilter;
            CollectionViewModel.CustomGroup -= CollectionViewModel_CustomGroup;
            CollectionViewModel.CustomGroupFromSelection -= CollectionViewModel_CustomGroupFromSelection;
            base.UnsubscribeCollectionViewModelEvents();
        }
    }
    //
    public class OrderFilterTreeListPresenter : FilterTreeListPresenter<DevAV.Order, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public OrderFilterTreeListPresenter(TreeList treeList, OrdersFilterTreeViewModel viewModel)
            : base(treeList, viewModel) {
        }
        public new OrderCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as OrderCollectionViewModel; }
        }
        protected override void SubscribeCollectionViewModelEvents() {
            base.SubscribeCollectionViewModelEvents();
            CollectionViewModel.CustomFilter += CollectionViewModel_CustomFilter;
        }
        protected override void UnsubscribeCollectionViewModelEvents() {
            CollectionViewModel.CustomFilter -= CollectionViewModel_CustomFilter;
            base.UnsubscribeCollectionViewModelEvents();
        }
    }
    //
    public class QuoteFilterTreeListPresenter : FilterTreeListPresenter<DevAV.Quote, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public QuoteFilterTreeListPresenter(TreeList treeList, QuotesFilterTreeViewModel viewModel)
            : base(treeList, viewModel) {
        }
        public new QuoteCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as QuoteCollectionViewModel; }
        }
        protected override void SubscribeCollectionViewModelEvents() {
            base.SubscribeCollectionViewModelEvents();
            CollectionViewModel.CustomFilter += CollectionViewModel_CustomFilter;
        }
        protected override void UnsubscribeCollectionViewModelEvents() {
            CollectionViewModel.CustomFilter -= CollectionViewModel_CustomFilter;
            base.UnsubscribeCollectionViewModelEvents();
        }
    }
}
