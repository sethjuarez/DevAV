namespace DevExpress.OutlookInspiredApp.Win.Presenters {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.DevAV;
    using DevExpress.OutlookInspiredApp.Win.ViewModel;
    using DevExpress.XtraMap;

    public class EmployeeRouteMapPresenter : RouteMapPresenter<Employee, EmployeeMapViewModel> {
        public EmployeeRouteMapPresenter(MapControl mapControl, EmployeeMapViewModel viewModel, Action<Employee> updateUIAction, Action<List<RoutePoint>> updateRouteList) :
            base(mapControl, viewModel, updateUIAction, updateRouteList) {
        }
        protected override void SubscribeViewModelEvents() {
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            base.SubscribeViewModelEvents();
        }
        protected override void UnsubscribeViewModelEvents() {
            base.UnsubscribeViewModelEvents();
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
        }
        protected override Employee GetViewModelEntity() {
            return ViewModel.Entity;
        }
    }
    public class OrderRouteMapPresenter : RouteMapPresenter<Order, OrderMapViewModel> {
        public OrderRouteMapPresenter(MapControl mapControl, OrderMapViewModel viewModel, Action<Order> updateUIAction, Action<List<RoutePoint>> updateRouteList) :
            base(mapControl, viewModel, updateUIAction, updateRouteList) {
        }
        protected override void SubscribeViewModelEvents() {
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            base.SubscribeViewModelEvents();
        }
        protected override void UnsubscribeViewModelEvents() {
            base.UnsubscribeViewModelEvents();
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
        }
        protected override Order GetViewModelEntity() {
            return ViewModel.Entity;
        }
    }
    //
    public class CustomerSalesMapPresenter : SalesMapPresenter<Customer, CustomerMapViewModel> {
        public CustomerSalesMapPresenter(MapControl mapControl, CustomerMapViewModel viewModel, Action<Customer> updateUIAction, Action<DevAV.ViewModels.Sales.MapItem> updateChartAction) :
            base(mapControl, viewModel, updateUIAction, updateChartAction) {
        }
        protected override void SubscribeViewModelEvents() {
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            base.SubscribeViewModelEvents();
        }
        protected override void UnsubscribeViewModelEvents() {
            base.UnsubscribeViewModelEvents();
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
        }
        protected override Customer GetViewModelEntity() {
            return ViewModel.Entity;
        }
        protected override void SetupColorizer() {
            PieChartColorizer.ColorIndexProvider = new PieSegmentColorProvider<ProductCategory>();
        }
        protected override void UpdateSales() {
            ZoomService.ZoomTo(ViewModel.GetSalesStores(ViewModel.Period).Select(s => s.Address));
            PieChartDataAdapter.DataSource = ViewModel.GetSales(ViewModel.Period).ToList();
        }
        #region Colorizer
        public class PieSegmentColorProvider<T> : PieSegmentToColorIndexProviderBase where T : struct {
            static T[] categories;
            static PieSegmentColorProvider() {
                categories = (T[])Enum.GetValues(typeof(T));
            }
            protected override int ConvertFromSegment(PieSegment segment) {
                return Array.IndexOf(categories, segment.Argument);
            }
            public static int Count { get { return categories.Length; } }
        }
        #endregion Colorizer
    }
    public class ProductSalesMapPresenter : SalesMapPresenter<Product, ProductMapViewModel> {
        public ProductSalesMapPresenter(MapControl mapControl, ProductMapViewModel viewModel, Action<Product> updateUIAction, Action<DevAV.ViewModels.Sales.MapItem> updateChartAction) :
            base(mapControl, viewModel, updateUIAction, updateChartAction) {
        }
        protected override void SubscribeViewModelEvents() {
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            base.SubscribeViewModelEvents();
        }
        protected override void UnsubscribeViewModelEvents() {
            base.UnsubscribeViewModelEvents();
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
        }
        protected override Product GetViewModelEntity() {
            return ViewModel.Entity;
        }
        protected override void SetupColorizer() {
            PieChartColorizer.ColorIndexProvider = new PieSegmentColorProvider();
        }
        protected override void UpdateSales() {
            ZoomService.ZoomTo(ViewModel.GetSalesStores(ViewModel.Period).Select(s => s.Address));
            PieChartDataAdapter.DataSource = ViewModel.GetSales(ViewModel.Period).ToList();
        }
        #region Colorizer
        public class PieSegmentColorProvider : PieSegmentToColorIndexProviderBase {
            static IList<string> arguments;
            static PieSegmentColorProvider() {
                arguments = new List<string>();
            }
            protected override int ConvertFromSegment(PieSegment segment) {
                string strArg = (string)segment.Argument;
                if(!arguments.Contains(strArg))
                    arguments.Add(strArg);
                return arguments.IndexOf(strArg);
            }
            public static int Count { get { return Math.Max(20, arguments.Count); } }
        }
        #endregion Colorizer
    }
}
