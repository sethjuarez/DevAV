namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class EmployeesPeek : BaseModuleControl {
        EmployeePeekListPresenter presenterCore;
        public EmployeesPeek()
            : base(CreateViewModel<EmployeeCollectionViewModel>) {
            InitializeComponent();
            //
            gridControl.DataSource = ViewModel.Entities;
            presenterCore = CreatePresenter();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public EmployeeCollectionViewModel ViewModel {
            get { return GetViewModel<EmployeeCollectionViewModel>(); }
        }
        public EmployeePeekListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual EmployeePeekListPresenter CreatePresenter() {
            return new EmployeePeekListPresenter(gridView, ViewModel);
        }
    }
}
