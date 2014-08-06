namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;

    public partial class QuoteCollectionViewModel : QuoteCollectionViewModelBase, ISupportMap, ISupportCustomFilters {
        public QuoteCollectionViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
        public override void Refresh() {
            base.Refresh();
            RaiseReload();
        }
        public event EventHandler Reload;
        public event EventHandler CustomFilter;
        public event EventHandler CustomFiltersReset;
        [Command]
        public void ShowMap() {
            ShowDocument<QuoteMapViewModel>("MapView", null);
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
        public void ShowAllFolders() {
            RaiseShowAllFolders();
        }
        [Command]
        public void ResetCustomFilters() {
            RaiseCustomFiltersReset();
        }
        void RaiseShowAllFolders() {
            MainViewModel mainViewModel = ViewModelHelper.GetParentViewModel<MainViewModel>(this);
            if(mainViewModel != null)
                mainViewModel.RaiseShowAllFolders();
        }
        void RaisePrint(SalesReportType reportType) {
            MainViewModel mainViewModel = ViewModelHelper.GetParentViewModel<MainViewModel>(this);
            if(mainViewModel != null)
                mainViewModel.RaisePrint(reportType);
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
        protected override IQueryable<Quote> GetQuotes() {
            if(FilterExpression == null)
                return base.GetQuotes();
            return Repository.GetEntities().Where(FilterExpression);
        }
    }
}
