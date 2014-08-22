namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.DataAnnotations;
    using DevExpress.Mvvm.POCO;

    public partial class OrderViewModel : OrderViewModelBase {
        public OrderViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
        public event EventHandler EntityChanged;
        protected override void OnEntityChanged() {
            base.OnEntityChanged();
            this.RaiseCanExecuteChanged(x => x.Customize());
            RaiseEntityChanged();
        }
        public event EventHandler CustomizeFilter;
        [Command]
        public void Customize() {
            RaiseCustomizeFilter();
        }
        public bool CanCustomize() {
            return Entity != null;
        }
        void RaiseEntityChanged() {
            EventHandler handler = EntityChanged;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        void RaiseCustomizeFilter() {
            EventHandler handler = CustomizeFilter;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
    }
    public partial class SynchronizedOrderViewModel : OrderViewModel {
        protected override bool EnableSelectedItemSynchronization {
            get { return true; }
        }
        protected override bool EnableEntityChangedSynchronization {
            get { return true; }
        }
    }
}
