namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class EmployeesFilterTreeViewModel : FilterTreeViewModel<Employee, Guid, IDevAVDbUnitOfWork> {
        public EmployeesFilterTreeViewModel()
            : base(null, null) {
        }
        public EmployeesFilterTreeViewModel(EmployeeCollectionViewModel collectionViewModel)
            : base(collectionViewModel, new EmployeesFilterModelSettings()) {
        }
        protected new EmployeeCollectionViewModel CollectionViewModel {
            get { return base.CollectionViewModel as EmployeeCollectionViewModel; }
        }
    }
}
