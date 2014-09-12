namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System.Linq;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.Spreadsheet;

    public partial class CustomerAnalysis : BaseModuleControl, IRibbonModule {
        public CustomerAnalysis()
            : base(CreateViewModel<CustomerAnalysisViewModel>) {
            InitializeComponent();
            BindCommands();
            LoadTemplate();
        }
        public CustomerAnalysisViewModel ViewModel {
            get { return GetViewModel<CustomerAnalysisViewModel>(); }
        }
        public CustomerCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<CustomerCollectionViewModel>(); }
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            QueueUIUpdate();
        }
        protected override void OnDelayedUIUpdate() {
            LoadAnalysisData();
        }
        void BindCommands() {
            biClose.BindCommand(() => ViewModel.Close(), ViewModel);
        }
        void LoadTemplate() {
            using(var stream = AnalysisTemplatesHelper.GetAnalysisTemplate(AnalysisTemplate.CustomerSales))
                spreadsheetControl.LoadDocument(stream, DocumentFormat.Xlsm);
        }
        void LoadAnalysisData() {
            spreadsheetControl.Document.BeginUpdate();
            var salesReportWorksheet = spreadsheetControl.Document.Worksheets["Sales Report"];
            var salesReportItems = ViewModel.GetSalesReport().ToList(); // materialize
            var frCustomers = salesReportItems
                .Select(i => i.CustomerName)
                .Distinct()
                .OrderBy(i => i).ToList();
            salesReportWorksheet.Import(frCustomers, 14, 1, true);
            foreach(var item in salesReportItems) {
                int rowOffset = frCustomers.IndexOf(item.CustomerName);
                int columnOffset = AnalysisPeriod.MonthOffsetFromStart(item.Date) / 12;
                if(rowOffset < 0 || columnOffset < 0) continue;
                salesReportWorksheet.Cells[14 + rowOffset, 3 + columnOffset * 2].SetValue(item.Total);
            }
            var salesDataWorksheet = spreadsheetControl.Document.Worksheets["Sales Data"];
            var salesDataItems = ViewModel.GetSalesData().ToList(); // materialize
            var states = salesDataItems.Select(i => i.State).Distinct().OrderBy(i => i).ToList();

            salesDataWorksheet.Import(ViewModel.GetStates(states), 5, 3, false);
            foreach(var item in salesDataItems) {
                int rowOffset = AnalysisPeriod.MonthOffsetFromStart(item.Date);
                int columnOffset = states.IndexOf(item.State);
                if(rowOffset < 0 || columnOffset < 0) continue;
                salesDataWorksheet.Cells[6 + rowOffset, 3 + columnOffset].SetValue(item.Total);
            }
            spreadsheetControl.Document.Worksheets.ActiveWorksheet = salesReportWorksheet;
            spreadsheetControl.Document.EndUpdate();
        }
        #region
        XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon {
            get { return ribbonControl; }
        }
        #endregion
    }
}
