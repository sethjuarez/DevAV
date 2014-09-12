namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.DevAV;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class CustomersCustomFilter : BaseModuleControl {
        public CustomersCustomFilter(CustomFilterViewModel customFilterViewModel)
            : base(() => customFilterViewModel) {
            InitializeComponent();
            ViewModel.QueryFilterCriteria += ViewModel_QueryFilterCriteria;
            bindingSource.DataSource = customFilterViewModel;
            BuildFilterColumns();
            BindEditors();
            BindCommands();
        }
        protected override void OnDisposing() {
            ViewModel.QueryFilterCriteria -= ViewModel_QueryFilterCriteria;
            base.OnDisposing();
        }
        protected override void OnLoad(System.EventArgs ea) {
            base.OnLoad(ea);
            filterControl.FilterCriteria = ViewModel.FilterCriteria;
        }
        void ViewModel_QueryFilterCriteria(object sender, QueryFilterCriteriaEventArgs e) {
            e.FilterCriteria = filterControl.FilterCriteria;
        }
        public CustomFilterViewModel ViewModel {
            get { return GetViewModel<CustomFilterViewModel>(); }
        }
        public CustomerCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<CustomerCollectionViewModel>(); }
        }
        void BuildFilterColumns() {
            var builder = new FilterColumnCollectionBuilder<Customer>(filterControl.FilterColumns);
            builder
                .AddColumn(c => c.Name)
                .AddColumn(c => c.Phone)
                .AddColumn(c => c.Fax)
                .AddColumn(c => c.Website)
                .AddColumn(c => c.TotalEmployees)
                .AddColumn(c => c.TotalStores)
                .AddLookupColumn(c => c.Status)
                .AddLookupColumn(c => c.HomeOffice.State);
        }
        void BindEditors() {
            var errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            errorProvider.ContainerControl = this;
            errorProvider.DataSource = bindingSource;
        }
        void BindCommands() {
            this.okBtn.BindCommand(() => ViewModel.OK(), ViewModel);
            this.cancelBtn.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }
    }
}
