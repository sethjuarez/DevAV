using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DashboardCommon;
using System.IO;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsViewModel
    {
        private IEnumerable<OrderEntity> _orders;
        internal const string DataSourceName = "Opportunities";
        public virtual IEnumerable<OrderEntity> Orders
        {
            get
            {
                return _orders;
            }
        }

        [ServiceProperty]
        public virtual IDocumentManagerService DocumentManagerService
        {
            get
            {
                return null;
            }
        }

        [Command]
        public void ShowNewDashboard()
        {
            var dashboard = new Dashboard();
            dashboard.AddDataSource(DataSourceName, Orders);
            Edit(dashboard);
        }

        [Command]
        public void Refresh()
        {
            var viewModel = DevExpress.Mvvm.POCO.ViewModelSource.Create<OrderCollectionViewModel>();
            _orders = OrderEntity.Map(viewModel.Entities).ToList();

        }

        public void Save(Dashboard dashboard)
        {
            var path = string.Format("{0}\\{1}.xml", DashboardDirectory, dashboard.Title.Text);
            dashboard.SaveToXml(path);
        }

        public void Edit(Dashboard dashboard)
        {
            var document = DocumentManagerService.CreateDocument("DashboardEditor", dashboard, this);
            if (document != null)
                document.Show();
        }


        private string _dashboardDirectory;
        public string DashboardDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_dashboardDirectory))
                    _dashboardDirectory = Path.Combine(Environment.CurrentDirectory, "Dashboards");

                return _dashboardDirectory;
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
        public string StoreCity { get; set; }
        public string Employee { get; set; }
        public string Customer { get; set; }
        public string StoreLocation { get; set; }
        public string StoreState { get; set; }
        public double CustomerLat { get; set; }
        public double CustomerLong { get; set; }

        public static IEnumerable<OrderEntity> Map(IList<DevAV.Order> orders)
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
                    StoreCity = order.Store.CrestCity,
                    Employee = order.Employee.FullName,
                    Customer = order.Customer.Name,
                    StoreLocation = order.Store.Location,
                    StoreState = order.Store.State.ToString(),
                    CustomerLat = order.Customer.BillingAddress.Latitude,
                    CustomerLong = order.Customer.BillingAddress.Longitude
                };
            }
        }
    }

    public enum DashboardMessageType
    {
        View,
        Edit,
        Save,
        Refresh
    }

    public class DashboardMessage
    {
        public DashboardMessage(DashboardMessageType messageType)
        {
            MessageType = messageType;
        }

        public DashboardMessage(Dashboard dashboard, DashboardMessageType messageType)
        {
            Dashboard = dashboard;
            MessageType = messageType;
        }

        public Dashboard Dashboard { get; private set; }
        public DashboardMessageType MessageType { get; private set; }
    }
}
