namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System;
    using System.Collections.Generic;
    using DevExpress.DevAV;
    using DevExpress.OutlookInspiredApp.Win.Presenters;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraBars.Docking2010;

    public partial class OrderMapView : BaseModuleControl, IRibbonModule {
        public OrderMapView()
            : base(CreateViewModel<OrderMapViewModel>) {
            InitializeComponent();
            //
            Presenter = CreatePresenter();
            //
            BindCommands();
            BindEditors();
            UpdateColors();
            LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }
        protected override void OnDisposing() {
            LookAndFeel.StyleChanged -= LookAndFeel_StyleChanged;
            Presenter.Dispose();
            base.OnDisposing();
        }
        public OrderMapViewModel ViewModel {
            get { return GetViewModel<OrderMapViewModel>(); }
        }
        protected OrderRouteMapPresenter Presenter {
            get;
            private set;
        }
        protected virtual OrderRouteMapPresenter CreatePresenter() {
            return new OrderRouteMapPresenter(mapControl, ViewModel, UpdateUI, UpdateRouteList);
        }
        protected virtual void BindCommands() {
            //Save & Close
            biSave.BindCommand(() => ViewModel.Save(), ViewModel);
            biClose.BindCommand(() => ViewModel.Close(), ViewModel);
            biSaveAndClose.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            //Delete
            biDelete.BindCommand(() => ViewModel.Delete(), ViewModel);
            //
            biDriving.BindCommand(() => ViewModel.SetDrivingTravelMode(), ViewModel);
            biWalking.BindCommand(() => ViewModel.SetWalkingTravelMode(), ViewModel);
            //
            ((WindowsUIButton)routeButtons.Buttons[0]).BindCommand(() => ViewModel.SetWalkingTravelMode(), ViewModel);
            ((WindowsUIButton)routeButtons.Buttons[1]).BindCommand(() => ViewModel.SetDrivingTravelMode(), ViewModel);
            ((WindowsUIButton)swapRouteButtons.Buttons[0]).BindCommand(() => ViewModel.SwapRoutePoints(), ViewModel);
            //
            biPrint.ItemClick += (s, e) => mapControl.Print();
            biPrintPreview.ItemClick += (s, e) => mapControl.ShowRibbonPrintPreview();
            barExportItem.ItemClick += (s, e) => mapControl.Export("Sales.Map.png");
        }
        protected virtual void BindEditors() {
            bindingSource.DataSource = ViewModel;
            colManeuver.ColumnEdit = EditorHelpers.CreateManeuverImageComboBox();
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e) {
            UpdateColors();
        }
        void UpdateColors() {
            routeResultLabel.Appearance.BackColor = GridHelper.GetRowBackColor(gridControl);
            routeResultLabel.Appearance.ForeColor = GridHelper.GetRowForeColor(gridControl);
            ItemForAddressLine1.AppearanceItemCaption.ForeColor = ColorHelper.DisabledTextColor;
            ItemForAddressLine1.AppearanceItemCaption.Options.UseForeColor = true;
        }
        void UpdateUI(Order order) {
            ribbonControl.ApplicationDocumentCaption = order.Customer.Name;
        }
        void UpdateRouteList(List<RoutePoint> routePoints) {
            gridControl.DataSource = routePoints;
        }
        #region IRibbonModule
        XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon {
            get { return ribbonControl; }
        }
        #endregion
    }
}
