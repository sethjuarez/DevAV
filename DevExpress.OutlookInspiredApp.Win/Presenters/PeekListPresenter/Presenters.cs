namespace DevExpress.OutlookInspiredApp.Win.Presenters {
    using System;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraGrid.Views.Grid;

    public class EmployeePeekListPresenter : PeekListPresenter<DevAV.Employee, Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public EmployeePeekListPresenter(GridView gridView, EmployeeCollectionViewModel viewModel)
            : base(gridView, viewModel) {
        }
        protected override ModuleType GetMainModuleType() {
            return ModuleType.Employees;
        }
    }
    public class CustomerPeekListPresenter : PeekListPresenter<DevAV.Customer, Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public CustomerPeekListPresenter(GridView gridView, CustomerCollectionViewModel viewModel)
            : base(gridView, viewModel) {
        }
        protected override ModuleType GetMainModuleType() {
            return ModuleType.Customers;
        }
    }
    public class ProductPeekListPresenter : PeekListPresenter<DevAV.Product, Guid, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork> {
        public ProductPeekListPresenter(GridView gridView, ProductCollectionViewModel viewModel)
            : base(gridView, viewModel) {
        }
        protected override ModuleType GetMainModuleType() {
            return ModuleType.Products;
        }
    }
}
