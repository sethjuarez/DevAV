namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public partial class OrderCollectionViewModel : OrderCollectionViewModelBase, ISupportMap, ISupportCustomFilters {
        public OrderCollectionViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
        public override void Refresh() {
            base.Refresh();
            RaiseReload();
        }
        protected override void OnSelectedEntityChanged() {
            base.OnSelectedEntityChanged();
            this.RaiseCanExecuteChanged(x => x.ShowMap());
            this.RaiseCanExecuteChanged(x => x.PrintInvoice());
            this.RaiseCanExecuteChanged(x => x.QuickReport(SalesReportType.Invoice));
        }
        public event EventHandler Reload;
        public event EventHandler CustomFilter;
        public event EventHandler CustomFiltersReset;
        [Command]
        public void ShowMap() {
            ShowMapCore(SelectedEntity);
        }
        public bool CanShowMap() {
            return CanShowMapCore(SelectedEntity);
        }
        protected internal void ShowMapCore(Order order) {
            ShowDocument<OrderMapViewModel>("MapView", order.Id);
        }
        protected internal bool CanShowMapCore(Order order) {
            return order != null;
        }
        [Command]
        public void ShowViewSettings() {
            var dms = ((DevExpress.Mvvm.ISupportServices)this).ServiceContainer.GetService<DevExpress.Mvvm.IDocumentManagerService>("View Settings");
            if(dms != null) {
                var document = dms.Documents.FirstOrDefault(d => d.Content is ViewSettingsViewModel);
                if(document == null)
                    document = dms.CreateDocument("View Settings", null, null, this);
                document.Show();
            }
        }
        [Command]
        public void NewCustomFilter() {
            RaiseCustomFilter();
        }
        [Command]
        public void PrintSalesReport() {
            RaisePrint(SalesReportType.SalesReport);
        }
        [Command]
        public void PrintSalesByStore() {
            RaisePrint(SalesReportType.SalesByStore);
        }
        [Command(UseCommandManager = false, CanExecuteMethodName = "CanPrint")]
        public void PrintInvoice() {
            RaisePrint(SalesReportType.Invoice);
        }
        public bool CanPrint() {
            return SelectedEntity != null;
        }
        [Command]
        public void QuickReport(SalesReportType reportType) {
            QuickReportCore(SelectedEntity, reportType);
        }
        public bool CanQuickReport(SalesReportType reportType) {
            return CanQuickReportCore(SelectedEntity, reportType);
        }
        protected internal void QuickReportCore(Order order, SalesReportType reportTemplate) {
            ShowDocument<OrderMailMergeViewModel>("MailMerge", reportTemplate);
        }
        protected internal bool CanQuickReportCore(Order order, SalesReportType reportTemplate) {
            return order != null;
        }
        [Command]
        public void ShowAllFolders() {
            RaiseShowAllFolders();
        }
        [Command]
        public void ResetCustomFilters() {
            RaiseCustomFiltersReset();
        }
        void RaisePrint(SalesReportType reportType) {
            MainViewModel mainViewModel = ViewModelHelper.GetParentViewModel<MainViewModel>(this);
            if(mainViewModel != null)
                mainViewModel.RaisePrint(reportType);
        }
        void RaiseShowAllFolders() {
            MainViewModel mainViewModel = ViewModelHelper.GetParentViewModel<MainViewModel>(this);
            if(mainViewModel != null)
                mainViewModel.RaiseShowAllFolders();
        }
        void RaiseReload() {
            EventHandler handler = Reload;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        void RaiseCustomFilter() {
            EventHandler handler = CustomFilter;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        void RaiseCustomFiltersReset() {
            EventHandler handler = CustomFiltersReset;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        void ShowDocument<TViewModel>(string documentType, object parameter) {
            var document = FindEntityDocument<TViewModel>();
            if(parameter is Guid)
                document = FindEntityDocument<TViewModel>((Guid)parameter);
            if(document == null)
                document = DocumentManagerService.CreateDocument(documentType, null, parameter, this);
            else
                ViewModelHelper.EnsureViewModel(document.Content, this, parameter);
            document.Show();
        }
    }
}
