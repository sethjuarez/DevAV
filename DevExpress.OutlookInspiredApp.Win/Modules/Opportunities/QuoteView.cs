namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System.Collections.Generic;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;

    public partial class QuoteView : BaseModuleControl {
        public QuoteView()
            : base(CreateViewModel<synchronizedQuoteViewModel>) {
            InitializeComponent();
        }
        public QuoteViewModel ViewModel {
            get { return GetViewModel<QuoteViewModel>(); }
        }
        public IList<Opportunities.MapItem> DataSource {
            get { return chartControl.DataSource as IList<Opportunities.MapItem>; }
            set {
                chartControl.DataSource = value;
                if(value != null) {
                    chartControl.Series[0].ArgumentDataMember = "Name";
                    chartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
                }
            }
        }
        protected internal System.Drawing.Color GetStageColor(Opportunities.Stage stage) {
            var values = System.Enum.GetValues(typeof(Opportunities.Stage));
            var entries = chartControl.GetPaletteEntries(values.Length);
            return entries[System.Array.IndexOf(values, stage)].Color;
        }
    }
}
