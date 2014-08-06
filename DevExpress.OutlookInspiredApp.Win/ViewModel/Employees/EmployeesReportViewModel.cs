namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.POCO;

    public class EmployeesReportViewModel :
        ReportViewModelBase<EmployeeReportType, Employee, Guid, IDevAVDbUnitOfWork> {
        IDevAVDbUnitOfWork unitOfWork;
        public EmployeesReportViewModel() {
            unitOfWork = DbUnitOfWorkFactory.Instance.CreateUnitOfWork();
        }
        public IList<EmployeeTask> Tasks {
            get { return unitOfWork.Tasks.GetEntities().ToList(); }
        }
    }
}
