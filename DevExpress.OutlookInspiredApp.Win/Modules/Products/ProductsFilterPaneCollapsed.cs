namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class ProductsFilterPaneCollapsed : BaseModuleControl, ISupportCompactLayout {
        ProductFilterPanePresenter presenterCore;
        public ProductsFilterPaneCollapsed(ProductCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new ProductsFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public ProductsFilterTreeViewModel ViewModel {
            get { return GetViewModel<ProductsFilterTreeViewModel>(); }
        }
        public ProductFilterPanePresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual ProductFilterPanePresenter CreatePresenter() {
            return new ProductFilterPanePresenter(navigationBar, ViewModel);
        }
        protected virtual void BindCommands() {
            btnNew.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
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
            btnNewLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
