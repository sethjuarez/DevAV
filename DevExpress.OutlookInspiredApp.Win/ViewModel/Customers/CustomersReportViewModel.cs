namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class CustomersReportViewModel :
        ReportViewModelBase<CustomerReportType, Customer, System.Guid, IDevAVDbUnitOfWork> {
        IDevAVDbUnitOfWork unitOfWork;
        public CustomersReportViewModel() {
            unitOfWork = DbUnitOfWorkFactory.Instance.CreateUnitOfWork();
        }
        public IList<CustomerEmployee> CustomerEmployees {
            get { return unitOfWork.CustomerEmployees.GetEntities().ToList(); }
        }
        public IList<CustomerStore> CustomerStores {
            get { return unitOfWork.CustomerStores.GetEntities().ToList(); }
        }
        public IList<Order> GetOrders(System.Guid customerId) {
            var orders = unitOfWork.Orders.GetEntities();
            var query = from o in orders
                        where o.CustomerId == customerId
                        select o;
            return query.ToList();
        }
        public IList<OrderItem> GetOrderItems(System.Guid customerId) {
            var orderItems = unitOfWork.OrderItems.GetEntities();
            var query = from oi in orderItems
                        where oi.Order.CustomerId == customerId
                        select oi;
            return query.ToList();
        }
    }
}
