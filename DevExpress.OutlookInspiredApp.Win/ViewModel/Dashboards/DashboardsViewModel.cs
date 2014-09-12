using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DevExpress.DashboardCommon;

namespace DevExpress.OutlookInspiredApp.Win.ViewModel
{
    public class DashboardsViewModel
    {
        // name of dashboard datasource
        internal const string DataSourceName = "Opportunities";
        // name of dashboard directory
        internal const string DataSourceDirectory = "Dashboards";
        // path to dashboard directory
        public string DashboardDirectory { get; private set; }
        // available dashboards
        public string[] Dashboards { get; private set; }
        // current dashboard
        public virtual string CurrentDashboard { get; set; }
        // datasource for dashboards
        public IEnumerable<OrderEntity> Orders { get; private set; }

        public DashboardsViewModel()
        {
            DashboardDirectory = Path.Combine(Environment.CurrentDirectory, DataSourceDirectory);
            CurrentDashboard = string.Empty;
            Refresh();
        }

        /// <summary>
        /// Refresh Opportunities data source and list of dashboards
        /// </summary>
        public void Refresh()
        {
            // refresh datashboard source data
            Orders = OrderEntity.Get().ToList();

            // refresh list of dashboards
            if (!Directory.Exists(DashboardDirectory))
                Directory.CreateDirectory(DashboardDirectory);
            Dashboards = Directory.EnumerateFiles(DashboardDirectory, "*.xml").ToArray();

            if (Dashboards.Length > 0)
                CurrentDashboard = Dashboards[0];
        }

        /// <summary>
        /// Gets current dashboard
        /// </summary>
        /// <returns>Dashboard object</returns>
        public Dashboard GetCurrentDashboard()
        {
            var dashboard = new Dashboard();
            dashboard.LoadFromXml(CurrentDashboard);
            return BindDashboard(dashboard);
        }

        /// <summary>
        /// Bind dashboard object to Opportunities data source
        /// </summary>
        /// <param name="dashboard">Dashboard to bind</param>
        /// <returns>Bound dashboard</returns>
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

        public static IEnumerable<OrderEntity> Get()
        {
            var viewModel = DevExpress.Mvvm.POCO.ViewModelSource.Create<OrderCollectionViewModel>();
            foreach (var order in viewModel.Entities)
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
        public static DashboardMessage View() { return new DashboardMessage(DashboardMessageType.View); }

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
