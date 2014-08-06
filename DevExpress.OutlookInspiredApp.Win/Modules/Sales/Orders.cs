namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System.Windows.Forms;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm;
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraLayout.Utils;

    public partial class Orders : BaseModuleControl, IRibbonModule, ISupportZoom {
        public Orders()
            : base(CreateViewModel<OrderCollectionViewModel>) {
            InitializeComponent();
            GalleryItemAppearances.Apply(galleryQuickReports);
            //
            CollectionUIViewModel = DevExpress.Mvvm.POCO.ViewModelSource.Create<CollectionUIViewModel>();
            CollectionPresenter = CreateCollectionPresenter();
            CollectionPresenter.ReloadEntities();
            //
            BindCommands();
            //
            InitViewKind();
            InitViewLayout();
        }
        protected override void OnDisposing() {
            CollectionPresenter.Dispose();
            UnsubscribeOrderViewEvents();
            base.OnDisposing();
        }
        public OrderCollectionViewModel ViewModel {
            get { return GetViewModel<OrderCollectionViewModel>(); }
        }
        protected OrderCollectionPresenter CollectionPresenter {
            get;
            private set;
        }
        protected virtual OrderCollectionPresenter CreateCollectionPresenter() {
            return new OrderCollectionPresenter(gridControl, ViewModel, UpdateEntitiesCountRelatedUI);
        }
        protected override void OnInitServices(IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService("View Settings", new ViewSettingsDialogDocumentManagerService(() => CollectionUIViewModel));
            serviceContainer.RegisterService(new NotImplementedDetailFormDocumentManagerService(ModuleType.OrderEditView));
        }
        void BindCommands() {
            //New
            biNewOrder.BindCommand(() => ViewModel.New(), ViewModel);
            biNewGroup.Enabled = false;
            bmiNewOrder.BindCommand(() => ViewModel.New(), ViewModel);
            bmiNewGroup.Enabled = false;
            //Edit & Delete
            biEdit.BindCommand((e) => ViewModel.Edit(e), ViewModel, () => ViewModel.SelectedEntity);
            biDelete.BindCommand((e) => ViewModel.Delete(e), ViewModel, () => ViewModel.SelectedEntity);
            //Map
            biMap.BindCommand(() => ViewModel.ShowMap(), ViewModel);
            //Filter
            biNewCustomFilter.BindCommand(() => ViewModel.NewCustomFilter(), ViewModel);
            //Print
            bmiPrintInvoice.BindCommand(() => ViewModel.PrintInvoice(), ViewModel);
            bmiPrintSalesSummary.BindCommand(() => ViewModel.PrintSalesReport(), ViewModel);
            bmiPrintSalesAnalysis.BindCommand(() => ViewModel.PrintSalesByStore(), ViewModel);
            //Quick Reports
            BindGalleryQuickReportsItem(0, SalesReportType.SalesReport);
            BindGalleryQuickReportsItem(1, SalesReportType.ThankYou);
            BindGalleryQuickReportsItem(2, SalesReportType.SalesByStore);
            BindGalleryQuickReportsItem(3, SalesReportType.Invoice);
            //Settings
            biViewSettings.BindCommand(() => ViewModel.ShowViewSettings(), ViewModel);
        }
        void BindGalleryQuickReportsItem(int index, SalesReportType parameter) {
            galleryQuickReports.Gallery.Groups[0].Items[index].BindCommand(() => ViewModel.QuickReport(parameter), ViewModel, () => parameter);
        }
        void UpdateEntitiesCountRelatedUI(int count) {
            hiItemsCount.Caption = string.Format("RECORDS: {0}", count);
            UpdateAdditionalButtons(count > 0);
        }
        void UpdateAdditionalButtons(bool hasRecords) {
            biReverseSort.Enabled = hasRecords;
            biAddColumns.Enabled = biExpandCollapse.Enabled = hasRecords && (CollectionUIViewModel.ViewKind == CollectionViewKind.ListView);
        }
        void biExpandCollapse_ItemClick(object sender, XtraBars.ItemClickEventArgs e) {
            CollectionPresenter.ExpandCollapseMasterRows();
        }
        void biAddColumns_ItemCheckedChanged(object sender, XtraBars.ItemClickEventArgs e) {
            CollectionPresenter.AddColumns(biAddColumns);
        }
        void biReverseSort_ItemClick(object sender, XtraBars.ItemClickEventArgs e) {
            CollectionPresenter.ReverseSort(gridView, colOrderDate);
        }
        OrderView orderView;
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            UnsubscribeOrderViewEvents();
            var moduleLocator = GetService<Services.IModuleLocator>();
            orderView = moduleLocator.GetModule(ModuleType.OrderView) as OrderView;
            SubscribeOrderViewEvents();
            ViewModelHelper.EnsureModuleViewModel(orderView, ViewModel, ViewModel.SelectedEntityKey);
            orderView.Dock = DockStyle.Fill;
            orderView.Parent = pnlView;
            gridView.ExpandMasterRow(0);
        }
        void UnsubscribeOrderViewEvents() {
            if(orderView != null)
                orderView.ZoomLevelChanged -= orderView_ZoomLevelChanged;
        }
        void SubscribeOrderViewEvents() {
            if(orderView != null)
                orderView.ZoomLevelChanged += orderView_ZoomLevelChanged;
        }
        #region ViewKind
        protected CollectionUIViewModel CollectionUIViewModel { get; private set; }
        void InitViewKind() {
            CollectionUIViewModel.ViewKindChanged += ViewModel_ViewKindChanged;
            biShowList.BindCommand(() => CollectionUIViewModel.ShowList(), CollectionUIViewModel);
            bmiShowList.BindCommand(() => CollectionUIViewModel.ShowList(), CollectionUIViewModel);
            biResetView.BindCommand(() => CollectionUIViewModel.ResetView(), CollectionUIViewModel);
        }
        void ViewModel_ViewKindChanged(object sender, System.EventArgs e) {
            if(CollectionUIViewModel.ViewKind == CollectionViewKind.ListView) gridControl.MainView = gridView;
            UpdateAdditionalButtons(ViewModel.Entities.Count > 0);
            GridHelper.SetFindControlImages(gridControl);
        }
        #endregion
        #region ViewLayout
        void InitViewLayout() {
            CollectionUIViewModel.ViewLayoutChanged += ViewModel_ViewLayoutChanged;
            bmiHorizontalLayout.BindCommand(() => CollectionUIViewModel.ShowHorizontalLayout(), CollectionUIViewModel);
            bmiVerticalLayout.BindCommand(() => CollectionUIViewModel.ShowVerticalLayout(), CollectionUIViewModel);
            bmiHideDetail.BindCommand(() => CollectionUIViewModel.HideDetail(), CollectionUIViewModel);
        }
        void ViewModel_ViewLayoutChanged(object sender, System.EventArgs e) {
            bool detailHidden = CollectionUIViewModel.IsDetailHidden;
            splitterItem.Visibility = detailHidden ? LayoutVisibility.Never : LayoutVisibility.Always;
            masterItem.Visibility = detailHidden ? LayoutVisibility.Never : LayoutVisibility.Always;
            if(!detailHidden) {
                if(splitterItem.IsVertical != CollectionUIViewModel.IsHorizontalLayout)
                    layoutControlGroup1.RotateLayout();
            }
        }
        #endregion
        #region ISupportZoom Members
        int ISupportZoom.ZoomLevel {
            get { return (orderView != null) ? orderView.ZoomLevel : 100; }
            set {
                if(orderView != null)
                    orderView.ZoomLevel = value;
            }
        }
        static readonly object zoomLevelChanged = new object();
        event System.EventHandler ISupportZoom.ZoomChanged {
            add { Events.AddHandler(zoomLevelChanged, value); }
            remove { Events.RemoveHandler(zoomLevelChanged, value); }
        }
        void orderView_ZoomLevelChanged(object sender, System.EventArgs e) {
            RaiseZoomLevelChanged();
        }
        void RaiseZoomLevelChanged() {
            var handler = Events[zoomLevelChanged] as System.EventHandler;
            if(handler != null) handler(this, System.EventArgs.Empty);
        }
        #endregion
        #region
        XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion
    }
}
