namespace DevExpress.OutlookInspiredApp.Services {
    public interface IModuleResourceProvider {
        string GetCaption(ModuleType moduleType);
        object GetModuleImage(ModuleType moduleType);
    }
    public class ModuleResourceProvider : IModuleResourceProvider {
        public string GetCaption(ModuleType moduleType) {
            switch(moduleType) {
                case ModuleType.Unknown:
                    return null;
                case ModuleType.EmployeesPeek:
                case ModuleType.EmployeesFilterPane:
                    return "Employees";
                case ModuleType.CustomersPeek:
                case ModuleType.CustomersFilterPane:
                    return "Customers";
                case ModuleType.ProductsPeek:
                case ModuleType.ProductsFilterPane:
                    return "Products";
                case ModuleType.Orders:
                case ModuleType.OrdersFilterPane:
                    return "Sales";
                case ModuleType.Quotes:
                case ModuleType.QuotesFilterPane:
                    return "Opportunities";
                case ModuleType.Dashboards:
                case ModuleType.DashboardsPane:
                case ModuleType.DashboardsEdit:
                    return "Dashboards";
                default:
                    return moduleType.ToString();
            }
        }
        public virtual object GetModuleImage(ModuleType moduleType) {
            return null;
        }
    }
}
namespace DevExpress.OutlookInspiredApp.Services.Win {
    public class ModuleResourceProvider : DevExpress.OutlookInspiredApp.Services.ModuleResourceProvider {
        public override object GetModuleImage(ModuleType moduleType) {
            switch(moduleType) {
                case ModuleType.Employees:
                case ModuleType.EmployeesFilterPane:
                    return DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_nav_employees_32;
                case ModuleType.Customers:
                case ModuleType.CustomersFilterPane:
                    return DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_nav_customers_32;
                case ModuleType.Products:
                case ModuleType.ProductsFilterPane:
                    return DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_nav_products_32;
                case ModuleType.Orders:
                case ModuleType.OrdersFilterPane:
                    return DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_nav_sales_32;
                case ModuleType.Quotes:
                case ModuleType.QuotesFilterPane:
                    return DevExpress.OutlookInspiredApp.Win.Properties.Resources.icon_nav_opportunities_32;
                case ModuleType.Unknown:
                default:
                    return null;
            }
        }
    }
}
