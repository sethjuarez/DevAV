namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class EmployeesFilterPane : BaseModuleControl, ISupportCompactLayout {
        EmployeeFilterTreeListPresenter presenterCore;
        public EmployeesFilterPane(EmployeeCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new EmployeesFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            this.presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public EmployeesFilterTreeViewModel ViewModel {
            get { return GetViewModel<EmployeesFilterTreeViewModel>(); }
        }
        public EmployeeFilterTreeListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual EmployeeFilterTreeListPresenter CreatePresenter() {
            return new EmployeeFilterTreeListPresenter(treeList, ViewModel);
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            serviceContainer.RegisterService("Custom Filter", new FilterDialogDocumentManagerService(ModuleType.EmployeesCustomFilter));
            serviceContainer.RegisterService("Group Filter", new FilterDialogDocumentManagerService(ModuleType.EmployeesGroupFilter));
        }
        protected virtual void BindCommands() {
            btnNewEmployee.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
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
            btnNewEmployeeLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
