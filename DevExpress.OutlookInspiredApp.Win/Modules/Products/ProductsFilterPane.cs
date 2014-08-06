namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class ProductsFilterPane : BaseModuleControl, ISupportCompactLayout {
        ProductFilterTreeListPresenter presenterCore;
        public ProductsFilterPane(ProductCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new ProductsFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            this.presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public ProductsFilterTreeViewModel ViewModel {
            get { return GetViewModel<ProductsFilterTreeViewModel>(); }
        }
        public ProductFilterTreeListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual ProductFilterTreeListPresenter CreatePresenter() {
            return new ProductFilterTreeListPresenter(treeList, ViewModel);
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            serviceContainer.RegisterService("Custom Filter", new FilterDialogDocumentManagerService(ModuleType.ProductsCustomFilter));
            serviceContainer.RegisterService("Group Filter", new FilterDialogDocumentManagerService(ModuleType.ProductsGroupFilter));
        }
        protected virtual void BindCommands() {
            btnNewProduct.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
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
            btnNewProductLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
