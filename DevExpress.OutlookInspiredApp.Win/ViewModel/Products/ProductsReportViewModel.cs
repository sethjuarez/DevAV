namespace DevExpress.OutlookInspiredApp.Win.ViewModel {
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;

    public class ProductsReportViewModel :
        ReportViewModelBase<ProductReportType, Product, System.Guid, IDevAVDbUnitOfWork> {
        IDevAVDbUnitOfWork unitOfWork;
        public ProductsReportViewModel() {
            unitOfWork = DbUnitOfWorkFactory.Instance.CreateUnitOfWork();
        }
        public IList<OrderItem> GetOrderItems(System.Guid productId) {
            var orderItems = unitOfWork.OrderItems.GetEntities();
            var query = from oi in orderItems
                        where oi.ProductId == productId
                        select oi;
            return query.ToList();
        }
        public IList<State> GetStates() {
            return unitOfWork.States.GetEntities().ToList();
        }
    }
}
