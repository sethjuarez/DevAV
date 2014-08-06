namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class OrdersFilterPane : BaseModuleControl, ISupportCompactLayout {
        OrderFilterTreeListPresenter presenterCore;
        public OrdersFilterPane(OrderCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new OrdersFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            this.presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public OrdersFilterTreeViewModel ViewModel {
            get { return GetViewModel<OrdersFilterTreeViewModel>(); }
        }
        public OrderFilterTreeListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual OrderFilterTreeListPresenter CreatePresenter() {
            return new OrderFilterTreeListPresenter(treeList, ViewModel);
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService("Custom Filter", new FilterDialogDocumentManagerService(ModuleType.OrdersCustomFilter));
        }
        protected virtual void BindCommands() {
            btnNewOrder.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
        }
        #region ISupportCompactLayout Members
        bool compactLayout = true;
        bool ISupportCompactLayout.Compact {
            get { return compactLayout; }
            set {
                if(compactLayout == value) return;
                compactLayout = value;
                UpdateCompactLayout();
            }
        }
        void UpdateCompactLayout() {
            btnNewOrderLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
