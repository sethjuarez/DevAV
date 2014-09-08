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
        internal const string DataSourceDirectory = "Dashboards";
        public virtual IEnumerable<OrderEntity> Orders
        {
            get
            {
                return _orders;
            }
        }

        public DashboardsViewModel()
        {
            DashboardDirectory = Path.Combine(Environment.CurrentDirectory, DataSourceDirectory);
            Refresh();
        }

        public string DashboardDirectory { get; private set; }
        public string[] Dashboards { get; private set; }
        public string CurrentDashboardPath { get; set; }

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
            RefreshData();
            RefreshDashboards();
        }

        [Command]
        public void EditDashboard()
        {
            var dashboard = FromPath(CurrentDashboardPath);
            Edit(dashboard);
        }

        internal void RefreshData()
        {
            var viewModel = DevExpress.Mvvm.POCO.ViewModelSource.Create<OrderCollectionViewModel>();
            _orders = OrderEntity.Map(viewModel.Entities).ToList();
        }

        internal void RefreshDashboards()
        {
            if (!Directory.Exists(DashboardDirectory))
                Directory.CreateDirectory(DashboardDirectory);

            Dashboards = Directory.EnumerateFiles(DashboardDirectory, "*.xml").ToArray();
        }

        public void Save(Dashboard dashboard)
        {
            dashboard.SaveToXml(DashboardPath(dashboard));
            RefreshDashboards();
        }

        public void Edit(Dashboard dashboard)
        {
            var document = DocumentManagerService.CreateDocument("DashboardEditor", dashboard, this);
            if (document != null)
                document.Show();
        }

        public string DashboardPath(Dashboard dashboard)
        {
            return string.Format("{0}\\{1}.xml", DashboardDirectory, dashboard.Title.Text);
        }

        public Dashboard FromPath(string path)
        {
            var dashboard = new Dashboard();
            dashboard.LoadFromXml(path);
            return BindDashboard(dashboard);
        }

        public Dashboard BindDashboard(Dashboard dashboard)
        {
            if (dashboard.DataSources.Count() == 0)
                dashboard.AddDataSource(DashboardsViewModel.DataSourceName, Orders);
            else if (dashboard.DataSources[0].Name == DashboardsViewModel.DataSourceName)
                dashboard.DataSources[0].Data = Orders;

            return dashboard;
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
        Save,
        Refresh
    }

    public class DashboardMessage
    {
        public static DashboardMessage Refresh() { return new DashboardMessage(DashboardMessageType.Refresh); }
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
