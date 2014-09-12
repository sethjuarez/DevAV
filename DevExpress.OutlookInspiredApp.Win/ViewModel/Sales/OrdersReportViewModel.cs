namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV.DevAVDbDataModel;
    using System.Collections.Generic;

    public class OrdersReportViewModel :
        ReportViewModelBase<SalesReportType, Order, Guid, IDevAVDbUnitOfWork> {
        IDevAVDbUnitOfWork unitOfWork;
        public OrdersReportViewModel() {
            unitOfWork = DbUnitOfWorkFactory.Instance.CreateUnitOfWork();
        }
        public IList<OrderItem> GetOrderItems() {
            return unitOfWork.OrderItems.GetEntities().ToList();
        }
    }
}
