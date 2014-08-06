namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.Spreadsheet;

    public partial class ProductAnalysis : BaseModuleControl, IRibbonModule {
        public ProductAnalysis()
            : base(CreateViewModel<ProductAnalysisViewModel>) {
            InitializeComponent();
            BindCommands();
            LoadTemplate();
        }
        public ProductAnalysisViewModel ViewModel {
            get { return GetViewModel<ProductAnalysisViewModel>(); }
        }
        public ProductCollectionViewModel CollectionViewModel {
            get { return GetParentViewModel<ProductCollectionViewModel>(); }
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
            using(var stream = AnalysisTemplatesHelper.GetAnalysisTemplate(AnalysisTemplate.ProductSales))
                spreadsheetControl.LoadDocument(stream, DocumentFormat.Xlsm);
        }
        void LoadAnalysisData() {
            spreadsheetControl.Document.BeginUpdate();
            var financialReportWorksheet = spreadsheetControl.Document.Worksheets["Financial Report"];
            var financialReportItems = ViewModel.GetFinancialReport().ToList(); // materialize
            var frProducts = financialReportItems
                .Select(i => i.ProductName)
                .Distinct()
                .OrderBy(i => i).ToList();
            financialReportWorksheet.Import(frProducts, 17, 1, true);
            foreach(var item in financialReportItems) {
                int rowOffset = frProducts.IndexOf(item.ProductName);
                int columnOffset = AnalysisPeriod.MonthOffsetFromStart(item.Date) / 12;
                if(rowOffset < 0 || columnOffset < 0) continue;
                financialReportWorksheet.Cells[17 + rowOffset, 3 + columnOffset * 2].SetValue(item.Total);
            }
            var financialDataWorksheet = spreadsheetControl.Document.Worksheets["Financial Data"];
            var financialDataItems = ViewModel.GetFinancialData().ToList(); // materialize
            foreach(var item in financialDataItems) {
                int rowOffset = AnalysisPeriod.MonthOffsetFromStart(item.Date);
                int columnOffset = GetColumnIndex(item.ProductCategory);
                if(rowOffset < 0 || columnOffset < 0) continue;
                financialDataWorksheet.Cells[6 + rowOffset, 3 + columnOffset].SetValue(item.Total);
            }
            spreadsheetControl.Document.Worksheets.ActiveWorksheet = financialReportWorksheet;
            spreadsheetControl.Document.EndUpdate();
        }
        int GetColumnIndex(ProductCategory category) {
            switch(category) {
                case ProductCategory.Televisions:
                    return 0;
                case ProductCategory.Monitors:
                    return 1;
                case ProductCategory.VideoPlayers:
                    return 2;
                case ProductCategory.Automation:
                    return 3;
                default:
                    return -1;
            }
        }
        #region
        XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion
    }
}
