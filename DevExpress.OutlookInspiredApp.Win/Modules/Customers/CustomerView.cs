namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.DevAV;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class CustomerView : BaseModuleControl {
        public CustomerView()
            : base(CreateViewModel<synchronizedCustomerViewModel>) {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            ItemForHomeOffice.AppearanceItemCaption.ForeColor = ColorHelper.DisabledTextColor;
            ItemForHomeOffice.AppearanceItemCaption.Options.UseForeColor = true;
        }
        public CustomerViewModel ViewModel {
            get { return GetViewModel<CustomerViewModel>(); }
        }
        protected override void OnDisposing() {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public bool IsHorizontalLayout {
            get { return winExplorerView.OptionsView.Style == XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large; }
            set {
                winExplorerView.OptionsView.Style = value ?
                    XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large : XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium;
            }
        }
        void ViewModel_EntityChanged(object sender, System.EventArgs e) {
            UpdateUI(ViewModel.Entity);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            UpdateUI(ViewModel.Entity);
        }
        void UpdateUI(Customer customer) {
            if(customer != null) {
                if(!object.Equals(bindingSource.DataSource, customer))
                    bindingSource.DataSource = customer;
                else
                    bindingSource.ResetBindings(false);
                gridControl.DataSource = customer.CustomerStores;
            }
            moduleLayout.Visible = (customer != null);
        }
    }
}
