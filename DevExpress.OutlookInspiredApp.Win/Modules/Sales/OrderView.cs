namespace DevExpress.OutlookInspiredApp.Win.Modules {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraBars.Docking2010;

    public partial class OrderView : BaseModuleControl {
        public OrderView()
            : base(CreateViewModel<SynchronizedOrderViewModel>) {
            InitializeComponent();
            BindCommands();
            TitleLabel.Appearance.ForeColor = ColorHelper.DisabledTextColor;
            ItemForTitle.AppearanceItemCaption.ForeColor = ColorHelper.DisabledTextColor;
            ItemForTitle.AppearanceItemCaption.Options.UseForeColor = true;
            modueLayout.Visible = false;
            snapControl.BackColor = ColorHelper.GetControlColor(LookAndFeel);
            LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;

            ViewModel.EntityChanged += ViewModel_EntityChanged;
            ViewModel.CustomizeFilter += ViewModel_CustomizeFilter;
            snapControl.ZoomChanged += snapControl_ZoomChanged;
            UpdateDocumentUI();
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e) {
            snapControl.BackColor = ColorHelper.GetControlColor(LookAndFeel);
        }
        protected override void OnDisposing() {
            ViewModel.CustomizeFilter -= ViewModel_CustomizeFilter;
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public OrderViewModel ViewModel {
            get { return GetViewModel<OrderViewModel>(); }
        }
        void BindCommands() {
            ((WindowsUIButton)buttons.Buttons[0]).BindCommand(() => ViewModel.Customize(), ViewModel);
        }
        void ViewModel_EntityChanged(object sender, System.EventArgs e) {
            QueueUIUpdate();
        }
        void ViewModel_CustomizeFilter(object sender, EventArgs e) {
            this.snapControl.ReadOnly = !this.snapControl.ReadOnly;
            UpdateDocumentUI();
        }
        void UpdateDocumentUI() {
            ((WindowsUIButton)buttons.Buttons[0]).Image = snapControl.ReadOnly ? Properties.Resources.icon_edit_16 : Properties.Resources.icon_close_16;
        }
        protected override int GetUIUpdateDelay() {
            return 500;
        }
        protected override void OnDelayedUIUpdate() {
            base.OnDelayedUIUpdate();
            UpdateUI(ViewModel.Entity);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            LoadOrderTemplate();
            UpdateUI(ViewModel.Entity);
        }
        void LoadOrderTemplate() {
            if(!snapControl.Document.IsEmpty) return;
            using(var stream = MailMergeTemplatesHelper.GetTemplateStream("Order.snx"))
                snapControl.LoadDocumentTemplate(stream, DevExpress.Snap.Core.API.SnapDocumentFormat.Snap);
            snapControl.Paint += snapControl_Paint;
        }
        void snapControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            snapControl.Paint -= snapControl_Paint;
            snapControl.ActiveView.FitToPage();
        }
        void snapControl_ZoomChanged(object sender, EventArgs e) {
            RaiseZoomLevelChanged();
        }
        void UpdateUI(Order order) {
            if(order != null) {
                if(!object.Equals(bindingSource.DataSource, order))
                    bindingSource.DataSource = order;
                else
                    bindingSource.ResetBindings(false);
                snapControl.Document.Fields.Update();
            }
            modueLayout.Visible = (order != null);
        }
        public int ZoomLevel {
            get { return (int)System.Math.Ceiling(snapControl.ActiveView.ZoomFactor * 100.0f); }
            set {
                if(ZoomLevel == value) return;
                snapControl.ActiveView.ZoomFactor = ((float)value) / 100.0f;
            }
        }
        public event EventHandler ZoomLevelChanged;
        void RaiseZoomLevelChanged() {
            EventHandler handler = ZoomLevelChanged;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
