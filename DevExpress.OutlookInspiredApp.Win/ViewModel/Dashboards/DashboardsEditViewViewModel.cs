using DevExpress.DevAV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsEditViewViewModel
    {
        private readonly OrderCollectionViewModel _ordersViewModel;
        private IEnumerable<OrderEntity> _orders;
        public DashboardsEditViewViewModel()
        {
            _ordersViewModel = DevExpress.Mvvm.POCO.ViewModelSource.Create<OrderCollectionViewModel>();
            _orders = Map(_ordersViewModel.Entities).ToList();
        }

        public void SaveDashboard(DevExpress.DashboardCommon.Dashboard dashboard)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<OrderEntity> Map(IList<DevAV.Order> orders)
        {
            foreach (var order in orders)
            {
                yield return new OrderEntity()
                {
                    InvoiceNumber = order.InvoiceNumber,
                    PONumber = order.PONumber,
                    OrderTerms = order.OrderTerms,
                    OrderDate = order.OrderDate,
                    ShipDate = order.ShipDate,
                    SalesAmount = order.SaleAmount,
                    ShippingAmount = order.ShippingAmount,
                    TotalAmount = order.TotalAmount,
                    CrestCity = order.Store.CrestCity,
                    Employee = order.Employee.FullName,
                    Customer = order.Customer.Name,
                    StoreLocation = order.Store.Location,
                    StoreState = order.Store.State.ToString(),
                    CustomerLat = order.Customer.BillingAddress.Latitude,
                    CustomerLong = order.Customer.BillingAddress.Longitude
                };
            }
        }

        public virtual IEnumerable<OrderEntity> Orders
        {
            get
            {
                return _orders;
            }
        }
    }


    public class OrderEntity
    {
        public string InvoiceNumber { get; set; }
        public string PONumber { get; set; }
        public string OrderTerms { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string CrestCity { get; set; }
        public string Employee { get; set; }
        public string Customer { get; set; }
        public string StoreLocation { get; set; }
        public string StoreState { get; set; }
        public double CustomerLat { get; set; }
        public double CustomerLong { get; set; }
    }
}
