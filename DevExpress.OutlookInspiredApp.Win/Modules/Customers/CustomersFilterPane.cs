namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class CustomersFilterPane : BaseModuleControl, ISupportCompactLayout {
        CustomerFilterTreeListPresenter presenterCore;
        public CustomersFilterPane(CustomerCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new CustomersFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            this.presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public CustomersFilterTreeViewModel ViewModel {
            get { return GetViewModel<CustomersFilterTreeViewModel>(); }
        }
        public CustomerFilterTreeListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual CustomerFilterTreeListPresenter CreatePresenter() {
            return new CustomerFilterTreeListPresenter(treeList, ViewModel);
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            serviceContainer.RegisterService("Custom Filter", new FilterDialogDocumentManagerService(ModuleType.CustomersCustomFilter));
            serviceContainer.RegisterService("Group Filter", new FilterDialogDocumentManagerService(ModuleType.CustomersGroupFilter));
        }
        protected virtual void BindCommands() {
            btnNewCustomer.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
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
            btnNewCustomerLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
