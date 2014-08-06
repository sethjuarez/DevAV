namespace DevExpress.OutlookInspiredApp.Win.Presenters {
    using System.Collections.Generic;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Layout.Events;

    public class EmployeeCollectionPresenter : CollectionPresenter<DevAV.Employee, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public EmployeeCollectionPresenter(GridControl gridControl, EmployeeCollectionViewModel viewModel, System.Action<int> updateUIAction)
            : base(gridControl, viewModel, updateUIAction) {
        }
        protected new EmployeeCollectionViewModel ViewModel {
            get { return base.ViewModel as EmployeeCollectionViewModel; }
        }
        protected override void SubscribeViewModelEvents() {
            base.SubscribeViewModelEvents();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            ViewModel.Reload += ViewModel_Reload;
        }
        protected override void UnsubscribeViewModelEvents() {
            ViewModel.Reload -= ViewModel_Reload;
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.UnsubscribeViewModelEvents();
        }
        protected override void InitMouseClickBehavior() {
            base.InitMouseClickBehavior();
            GridView.RowCellClick += GridView_RowCellClick;
            LayoutView.FieldValueClick += LayoutView_FieldValueClick;
        }
        protected override void ReleaseMouseClickBehavior() {
            GridView.RowCellClick -= GridView_RowCellClick;
            LayoutView.FieldValueClick -= LayoutView_FieldValueClick;
            base.ReleaseMouseClickBehavior();
        }
        protected override void SetSelection(IEnumerable<DevAV.Employee> selection) {
            ViewModel.Selection = selection;
        }
        protected override System.Guid GetKey(DevAV.Employee entity) {
            return entity.Id;
        }
        void GridView_RowCellClick(object sender, RowCellClickEventArgs e) {
            MailTo(e.RowHandle, e.Column, e.CellValue);
        }
        void LayoutView_FieldValueClick(object sender, FieldValueClickEventArgs e) {
            MailTo(e.RowHandle, e.Column, e.FieldValue);
        }
        void MailTo(int rowHandle, GridColumn column, object value) {
            if(rowHandle > -1 && column.FieldName == "Email")
                EmployeeContactsViewModel.ExecuteMailTo(GetService<DevExpress.Mvvm.IMessageBoxService>(), (string)value);
        }
    }
    public class CustomerCollectionPresenter : CollectionPresenter<DevAV.Customer, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public CustomerCollectionPresenter(GridControl gridControl, CustomerCollectionViewModel viewModel, System.Action<int> updateUIAction)
            : base(gridControl, viewModel, updateUIAction) {
        }
        protected new CustomerCollectionViewModel ViewModel {
            get { return base.ViewModel as CustomerCollectionViewModel; }
        }
        protected override void SubscribeViewModelEvents() {
            base.SubscribeViewModelEvents();
            ViewModel.Reload += ViewModel_Reload;
        }
        protected override void UnsubscribeViewModelEvents() {
            ViewModel.Reload -= ViewModel_Reload;
            base.UnsubscribeViewModelEvents();
        }
        protected override void SetSelection(IEnumerable<DevAV.Customer> selection) {
            ViewModel.Selection = selection;
        }
        protected override System.Guid GetKey(DevAV.Customer entity) {
            return entity.Id;
        }
    }
    public class ProductCollectionPresenter : CollectionPresenter<DevAV.Product, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public ProductCollectionPresenter(GridControl gridControl, ProductCollectionViewModel viewModel, System.Action<int> updateUIAction)
            : base(gridControl, viewModel, updateUIAction) {
        }
        protected new ProductCollectionViewModel ViewModel {
            get { return base.ViewModel as ProductCollectionViewModel; }
        }
        protected override void SubscribeViewModelEvents() {
            base.SubscribeViewModelEvents();
            ViewModel.Reload += ViewModel_Reload;
        }
        protected override void UnsubscribeViewModelEvents() {
            ViewModel.Reload -= ViewModel_Reload;
            base.UnsubscribeViewModelEvents();
        }
        protected override void SetSelection(IEnumerable<DevAV.Product> selection) {
            ViewModel.Selection = selection;
        }
        protected override System.Guid GetKey(DevAV.Product entity) {
            return entity.Id;
        }
    }
    public class OrderCollectionPresenter : CollectionPresenter<DevAV.Order, System.Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public OrderCollectionPresenter(GridControl gridControl, OrderCollectionViewModel viewModel, System.Action<int> updateUIAction)
            : base(gridControl, viewModel, updateUIAction) {
        }
        protected new OrderCollectionViewModel ViewModel {
            get { return base.ViewModel as OrderCollectionViewModel; }
        }
        protected override void SubscribeViewModelEvents() {
            base.SubscribeViewModelEvents();
            ViewModel.Reload += ViewModel_Reload;
        }
        protected override void UnsubscribeViewModelEvents() {
            ViewModel.Reload -= ViewModel_Reload;
            base.UnsubscribeViewModelEvents();
        }
        protected override void SetSelection(IEnumerable<DevAV.Order> selection) {
            /* do nothing */
        }
        protected override System.Guid GetKey(DevAV.Order entity) {
            return entity.Id;
        }
    }
}
