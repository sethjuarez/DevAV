namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class ProductsPeek : BaseModuleControl {
        ProductPeekListPresenter presenterCore;
        public ProductsPeek()
            : base(CreateViewModel<ProductCollectionViewModel>) {
            InitializeComponent();
            //
            gridControl.DataSource = ViewModel.Entities;
            presenterCore = CreatePresenter();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public ProductCollectionViewModel ViewModel {
            get { return GetViewModel<ProductCollectionViewModel>(); }
        }
        public ProductPeekListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual ProductPeekListPresenter CreatePresenter() {
            return new ProductPeekListPresenter(gridView, ViewModel);
        }
    }
}
