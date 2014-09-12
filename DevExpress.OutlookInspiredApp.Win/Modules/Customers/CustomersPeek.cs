namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class CustomersPeek : BaseModuleControl {
        CustomerPeekListPresenter presenterCore;
        public CustomersPeek()
            : base(CreateViewModel<CustomerCollectionViewModel>) {
            InitializeComponent();
            //
            gridControl.DataSource = ViewModel.Entities;
            presenterCore = CreatePresenter();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public CustomerCollectionViewModel ViewModel {
            get { return GetViewModel<CustomerCollectionViewModel>(); }
        }
        public CustomerPeekListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual CustomerPeekListPresenter CreatePresenter() {
            return new CustomerPeekListPresenter(gridView, ViewModel);
        }
    }
}
