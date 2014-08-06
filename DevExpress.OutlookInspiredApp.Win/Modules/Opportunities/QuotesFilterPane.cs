namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class QuotesFilterPane : BaseModuleControl, ISupportCompactLayout {
        QuoteFilterTreeListPresenter presenterCore;
        public QuotesFilterPane(QuoteCollectionViewModel collectionViewModel)
            : base(() => CreateViewModel(() => new QuotesFilterTreeViewModel(collectionViewModel))) {
            InitializeComponent();
            FiltersTreeListAppearances.Apply(treeList);
            this.presenterCore = CreatePresenter();
            BindCommands();
        }
        protected override void OnDisposing() {
            Presenter.Dispose();
            base.OnDisposing();
        }
        public QuotesFilterTreeViewModel ViewModel {
            get { return GetViewModel<QuotesFilterTreeViewModel>(); }
        }
        public QuoteFilterTreeListPresenter Presenter {
            get { return presenterCore; }
        }
        protected virtual QuoteFilterTreeListPresenter CreatePresenter() {
            return new QuoteFilterTreeListPresenter(treeList, ViewModel);
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService("Custom Filter", new FilterDialogDocumentManagerService(ModuleType.QuotesCustomFilter));
        }
        protected virtual void BindCommands() {
            btnNewQuote.BindCommand(() => Presenter.CollectionViewModel.New(), Presenter.CollectionViewModel);
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
            btnNewQuoteLayoutControlItem.Visibility = compactLayout ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        #endregion
    }
}
